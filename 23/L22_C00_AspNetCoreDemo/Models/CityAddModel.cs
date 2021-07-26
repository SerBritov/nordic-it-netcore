using L22_C00_AspNetCoreDemo.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using L22_C00_AspNetCoreDemo.Validation;

namespace L22_C00_AspNetCoreDemo.Models
{
	public class CityAddModel
	{
		[Required]
		[MaxLength(100)]
		public string Name { get; set; }
		[MaxLength(255)]
		[Different("Name")]
		public string Description { get; set; }
		[Range(0, 100)]
		public int NumberOfPoi { get; set; }
		
		public CityAddModel() { }

		public CityAddModel(string name, string description, int numberOfPoi)
		{
			Name = name;
			Description = description;
			NumberOfPoi = numberOfPoi;
		}
		
		public City ToCity(int id)
		{
			return new City(
				id,
				Name,
				Description,
				NumberOfPoi);
		}
	}
}
