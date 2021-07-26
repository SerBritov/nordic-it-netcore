using System.Collections.Generic;
using System.Linq;
using L22_C01_empty_asp_net_core_app.Models;

namespace L22_C01_empty_asp_net_core_app.DataStore
{
	public class CitiesDataStore: ICitiesDataStore
	{
		public List<City> Cities { get; }

		public CitiesDataStore()
		{
			Cities = new List<City>
			{
				new City(1, "Moscow", "The city I live in", 99),
				new City(2, "St. Petersburg", "The city I live in", 100),
				new City(3, "New-York", "The city I want to visit", 98)
			};
		}

		public int GetNewId()
		{
			return Cities
				.Select(c => c.Id)
				.Max() + 1;
		}
	}
}
