using System.ComponentModel.DataAnnotations;

namespace L22_C01_empty_asp_net_core_app.Models
{
	public class AddCityModel
	{
		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(255, ErrorMessage = "Error")]
		public string Description { get; set; }

		[Range(0, 100)]
		public int NumberOfPoi { get; set; }

		public AddCityModel()
		{
		}

		public AddCityModel(string name, string desc, int numberOfPoi)
		{
			Name = name;
			Description = desc;
			NumberOfPoi = numberOfPoi;
		}
	}
}
