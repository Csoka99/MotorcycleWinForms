namespace MotorcycleGame
{
	partial class MotorcycleWindow
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			buttonTableLayout = new TableLayoutPanel();
			menuStrip1 = new MenuStrip();
			newGameToolStripMenuItem = new ToolStripMenuItem();
			startMenuStrip = new ToolStripMenuItem();
			pauseMenuStrip = new ToolStripMenuItem();
			saveMenuStrip = new ToolStripMenuItem();
			loadMenuStrip = new ToolStripMenuItem();
			timeLabel = new Label();
			fuelLabel = new Label();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// buttonTableLayout
			// 
			buttonTableLayout.ColumnCount = 2;
			buttonTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			buttonTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			buttonTableLayout.Location = new Point(8, 161);
			buttonTableLayout.Name = "buttonTableLayout";
			buttonTableLayout.RowCount = 2;
			buttonTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			buttonTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			buttonTableLayout.Size = new Size(563, 563);
			buttonTableLayout.TabIndex = 0;
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(24, 24);
			menuStrip1.Items.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, startMenuStrip, pauseMenuStrip, saveMenuStrip, loadMenuStrip });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(583, 33);
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			// 
			// newGameToolStripMenuItem
			// 
			newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
			newGameToolStripMenuItem.Size = new Size(114, 29);
			newGameToolStripMenuItem.Text = "New Game";
			newGameToolStripMenuItem.Click += onNewGameMenuClicked;
			// 
			// startMenuStrip
			// 
			startMenuStrip.Enabled = false;
			startMenuStrip.Name = "startMenuStrip";
			startMenuStrip.Size = new Size(64, 29);
			startMenuStrip.Text = "Start";
			startMenuStrip.Click += onStartMenuClicked;
			// 
			// pauseMenuStrip
			// 
			pauseMenuStrip.Name = "pauseMenuStrip";
			pauseMenuStrip.Size = new Size(73, 29);
			pauseMenuStrip.Text = "Pause";
			pauseMenuStrip.Click += onPauseMenuClicked;
			// 
			// saveMenuStrip
			// 
			saveMenuStrip.Enabled = false;
			saveMenuStrip.Name = "saveMenuStrip";
			saveMenuStrip.Size = new Size(65, 29);
			saveMenuStrip.Text = "Save";
			saveMenuStrip.Click += onSaveMenuClicked;
			// 
			// loadMenuStrip
			// 
			loadMenuStrip.Enabled = false;
			loadMenuStrip.Name = "loadMenuStrip";
			loadMenuStrip.Size = new Size(67, 29);
			loadMenuStrip.Text = "Load";
			loadMenuStrip.Click += onLoadMenuClicked;
			// 
			// timeLabel
			// 
			timeLabel.AutoSize = true;
			timeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			timeLabel.Location = new Point(8, 53);
			timeLabel.Name = "timeLabel";
			timeLabel.Size = new Size(123, 32);
			timeLabel.TabIndex = 2;
			timeLabel.Text = "Eltelt idő:";
			// 
			// fuelLabel
			// 
			fuelLabel.AutoSize = true;
			fuelLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			fuelLabel.Location = new Point(8, 96);
			fuelLabel.Name = "fuelLabel";
			fuelLabel.Size = new Size(285, 32);
			fuelLabel.TabIndex = 3;
			fuelLabel.Text = "Üzemanyag mennyiség:";
			// 
			// MotorcycleWindow
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(583, 736);
			Controls.Add(fuelLabel);
			Controls.Add(timeLabel);
			Controls.Add(buttonTableLayout);
			Controls.Add(menuStrip1);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MainMenuStrip = menuStrip1;
			Name = "MotorcycleWindow";
			Text = "Motorcycle";
			KeyDown += onKeyDown;
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TableLayoutPanel buttonTableLayout;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem newGameToolStripMenuItem;
		private ToolStripMenuItem startMenuStrip;
		private ToolStripMenuItem pauseMenuStrip;
		private ToolStripMenuItem saveMenuStrip;
		private ToolStripMenuItem loadMenuStrip;
		private Label timeLabel;
		private Label fuelLabel;
	}
}