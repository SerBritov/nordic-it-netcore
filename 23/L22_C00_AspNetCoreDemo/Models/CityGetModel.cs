using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L22_C00_AspNetCoreDemo.Models
{
	public class CityGetModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public int NumberOfPoi { get; set; }

		public CityGetModel() { }

		public CityGetModel(int id, string name, string description, int numberOfPoi)
		{
			Id = id;
			Name = name;
			Description = description;
			NumberOfPoi = numberOfPoi;
		}
	}
}
