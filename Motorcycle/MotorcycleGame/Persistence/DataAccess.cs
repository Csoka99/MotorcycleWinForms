﻿using Motorcycle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Motorcycle.Model.States;

namespace Motorcycle.Persistence
{
	public class DataAccess : IDataAccess
	{
		public async Task<(int, int, int, int, FieldState[,])> LoadGameAsync(string path)
		{
			try
			{
				using (StreamReader reader = new StreamReader(path))
				{

					string line = await reader.ReadLineAsync() ?? String.Empty;
					
					int size = int.Parse(line);

					line = await reader.ReadLineAsync() ?? String.Empty;
					int time = int.Parse(line);

					line = await reader.ReadLineAsync() ?? String.Empty;
					int fuelTank = int.Parse(line);

					line = await reader.ReadLineAsync() ?? String.Empty;
					int speed = int.Parse(line);

					FieldState[,] board = new FieldState[size, size];

					for (int i = 0; i < size; i++)
					{
						for (int j = 0; j < size; j++)
						{
							line = await reader.ReadLineAsync() ?? String.Empty;

							if (line == "Empty")
							{
								board[i, j] = FieldState.Empty;
							}
							if (line == "Fuel")
							{
								board[i, j] = FieldState.Fuel;
							}
							if (line == "Motor")
							{
								board[i, j] = FieldState.Motor;
							}

						}
					}

					return (size, time, fuelTank, speed, board);
				}

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				FieldState[,] board = new FieldState[0, 0];
				return (0, 0, 0, 0, board);

			}
		}
		public async Task<bool> SaveGameAsync(string path, MotorcycleModel model)
		{
			try
			{
				using (StreamWriter writer = new StreamWriter(path))
				{
					writer.WriteLine(model.Size);
					writer.WriteLine(model.Time);
					writer.WriteLine(model.FuelTank);
					writer.WriteLine(model.Speed);
					for (int i = 0; i < model.Size; i++)
					{
						for (int j = 0; j < model.Size; j++)
						{
							await writer.WriteAsync(model.Board?[i, j] + "\n");
						}
					}

				}
				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return false;
			}
		}
	}
}
