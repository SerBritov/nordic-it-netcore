using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L22_C00_AspNetCoreDemo.DataStore
{
	public class City
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public int NumberOfPoi { get; set; }

		public City() { }

		public City(int id, string name, string description, int numberOfPoi)
		{
			Id = id;
			Name = name;
			Description = description;
			NumberOfPoi = numberOfPoi;
		}
	}
}
