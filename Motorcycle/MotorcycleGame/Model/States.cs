﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle.Model
{
	public class States
	{
		public enum FieldState
		{
			Empty, Motor, Fuel
		}

		public enum KeyState
		{
			Right, Left, Invalid
		}
	}
}
