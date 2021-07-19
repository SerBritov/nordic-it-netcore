using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L22_C01_empty_asp_net_core_app.DataStore
{
	public interface ICitiesDataStore
	{
		List<City> Cities { get; }

		int GetNewId();
	}
}
