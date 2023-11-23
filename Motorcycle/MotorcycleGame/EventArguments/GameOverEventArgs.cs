using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle.EventArguments
{
	public class GameOverEventArgs
	{
		public int Time { get; set; }

		public GameOverEventArgs(int time)
		{
			Time = time;
		}
	}
}
