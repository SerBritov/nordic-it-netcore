using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace L22_C00_AspNetCoreDemo.DataStore
{
	public interface ICitiesDataStore
	{
		public List<City> Cities { get; set; }
		public int GetNextId();
	}
}
