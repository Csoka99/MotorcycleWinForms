using Motorcycle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Motorcycle.Model.States;

namespace Motorcycle.Persistence
{
	public interface IDataAccess
	{
		Task<(int, int, int, int, FieldState[,])> LoadGameAsync(string path);
		public Task<bool> SaveGameAsync(string path, MotorcycleModel model);
	}
}
