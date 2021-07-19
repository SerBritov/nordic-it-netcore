using System.Collections.Generic;
using L22_C02_empty_asp_net_core_app_final.Models;

namespace L22_C02_empty_asp_net_core_app_final
{
	public class CitiesDataStore
	{
		private static CitiesDataStore _store;

		public List<City> Cities { get; }

		private CitiesDataStore()
		{
			Cities = new List<City>
			{
				new City(1, "Moscow"),
				new City(2, "Saint-Petersburg"),
				new City(3, "New-York")
			};
		}

		public static CitiesDataStore GetInstance()
		{
			// the code below can be changed with the single line:
			// return _store ??= new CitiesDataStore();

			if (_store == null)
				_store = new CitiesDataStore();

			return _store;
		}
	}
}
