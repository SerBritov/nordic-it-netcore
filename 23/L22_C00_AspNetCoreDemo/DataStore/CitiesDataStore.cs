using System.Collections.Generic;
using L22_C00_AspNetCoreDemo.Models;
using System.Linq;

namespace L22_C00_AspNetCoreDemo.DataStore
{
	public class CitiesDataStore: ICitiesDataStore
	{
		
		public List<City> Cities { get; set; }

		public CitiesDataStore()
		{
			Cities = new List<City>
			{
				new City(1, "Moscow", "Capital of Russia", 99),
				new City(2, "St.-Petersburg", "One of the biggest culture centers", 100),
				new City(3, "New-York", "City I would visit", 98)
			};
		}

		
		public int GetNextId()
		{
			return Cities
				.Select(c => c.Id)
				.Max()+1;
		}
	}
}
