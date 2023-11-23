﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Motorcycle.Model.States;

namespace Motorcycle.EventArguments
{
	public class FieldChangedEventArgs
	{
		public int Row { get; set; }
		public int Column { get; set; }

		public FieldState NewState { get; set; }

		public FieldChangedEventArgs(int row, int column, FieldState newState)
		{
			Row = row;
			Column = column;
			NewState = newState;
		}
	}
}
