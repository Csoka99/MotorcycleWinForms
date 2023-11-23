using Motorcycle.EventArguments;
using Motorcycle.Model;
using Motorcycle.Persistence;
using System.Reflection;
using static Motorcycle.Model.States;
using Timer = System.Windows.Forms.Timer;

namespace MotorcycleGame
{
	public partial class MotorcycleWindow : Form
	{

		MotorcycleModel model;
		private Timer _speed;
		public MotorcycleWindow()
		{
			InitializeComponent();

			model = new MotorcycleModel(new DataAccess());
			_speed = new Timer();
			_speed.Interval = 1000;
			_speed.Tick += onTimerTicked;
			model.GameStarted += onGameStarted;
			model.FieldChanged += onFieldChanged;
			model.GameOver += onGameOver;

			model.StartNewGame(13);
		}

		private void onGameOver(object? sender, GameOverEventArgs e)
		{
			_speed.Stop();
			loadMenuStrip.Enabled = true;
			saveMenuStrip.Enabled = false;
			startMenuStrip.Enabled = false;
			pauseMenuStrip.Enabled = false;
			MessageBox.Show(
					$"Game over! Collapsed time: {model.IntToTime(e.Time)}",
					"Game over",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
		}

		private void onFieldChanged(object? sender, FieldChangedEventArgs e)
		{
			var button = (Button) buttonTableLayout.GetControlFromPosition(e.Column, e.Row);
			setButtonColor(button, e.NewState);
			timeLabel.Text = $"Eltelt idõ: {model.IntToTime(model.Time)}";
			fuelLabel.Text = $"Üzemanyag mennyiség: {model.FuelTank} l";
			_speed.Interval = model.Speed;
		}

		private void onTimerTicked(object? sender, EventArgs e)
		{
			model.TimerTicked();
			timeLabel.Text = $"Eltelt idõ: {model.IntToTime(model.Time)}";
			fuelLabel.Text = $"Üzemanyag mennyiség: {model.FuelTank} l";
			_speed.Interval = model.Speed;
		}

		private void onGameStarted(object? sender, GameStartedEventArgs e)
		{
			var size = e.BoardSize;
			var board = e.Board;

			loadMenuStrip.Enabled = true;
			saveMenuStrip.Enabled = true;
			startMenuStrip.Enabled = true;
			pauseMenuStrip.Enabled = false;

			buttonTableLayout.RowCount = size + 1;
			buttonTableLayout.ColumnCount = size + 1;
			buttonTableLayout.Controls.Clear();

			buttonTableLayout.RowStyles.Clear();
			buttonTableLayout.ColumnStyles.Clear();

			for (int i = 0; i < size; i++)
			{
				buttonTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 1 / Convert.ToSingle(size)));
				buttonTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1 / Convert.ToSingle(size)));
			}

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					var button = new Button();
					button.FlatStyle = FlatStyle.Flat;
					button.Margin = new Padding(0, 0, 0, 0);
					button.AutoSize = true;
					button.Dock = DockStyle.Fill;
					setButtonColor(button, board[i, j]);
					buttonTableLayout.Controls.Add(button, j, i);
				}
			}
		}

		private void setButtonColor(Button b, FieldState state)
		{
			switch (state)
			{
				case FieldState.Empty:
					b.BackColor = Color.White;
					b.Enabled = false;
					break;
				case FieldState.Motor:
					b.BackColor = Color.Black;
					b.Enabled = false;
					break;
				case FieldState.Fuel:
					b.BackColor = Color.Red;
					b.Enabled = false;
					break;
			}
		}

		private async void onLoadMenuClicked(object sender, EventArgs e)
		{
			var openFileDialog = new OpenFileDialog();
			var result = openFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				string path = openFileDialog.FileName;
				await model.LoadGame(path);
			}
		}

		private void onPauseMenuClicked(object sender, EventArgs e)
		{
			_speed.Stop();
			loadMenuStrip.Enabled = true;
			saveMenuStrip.Enabled = true;
			startMenuStrip.Enabled = true;
			pauseMenuStrip.Enabled = false;
		}

		private void onStartMenuClicked(object sender, EventArgs e)
		{
			_speed.Start();
			loadMenuStrip.Enabled = false;
			saveMenuStrip.Enabled = false;
			startMenuStrip.Enabled = false;
			pauseMenuStrip.Enabled = true;
		}

		private void onKeyDown(object sender, KeyEventArgs e)
		{
			if (_speed.Enabled)
			{
				KeyState key;
				switch (e.KeyCode){
					case Keys.Right:
						key = KeyState.Right;
						break;
					case Keys.Left:
						key = KeyState.Left;
						break;
					default:
						key = KeyState.Invalid;
						break;
				}
				model.KeyPressed(key);
			}
		}

		private void onNewGameMenuClicked(object sender, EventArgs e)
		{
			timeLabel.Text = $"Eltelt idõ:";
			fuelLabel.Text = $"Üzemanyag mennyiség: ";
			model.StartNewGame(13);
		}

		private async void onSaveMenuClicked(object sender, EventArgs e)
		{
			var saveFileDialog = new SaveFileDialog();

			var result = saveFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				string path = saveFileDialog.FileName;
				await model.SaveGame(path);
			}
		}
	}
}