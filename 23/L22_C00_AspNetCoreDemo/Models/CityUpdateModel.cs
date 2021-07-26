using L22_C00_AspNetCoreDemo.DataStore;

namespace L22_C00_AspNetCoreDemo.Controllers
{
	public class CityUpdateModel
	{
		public string? Name  { get; set; }

		public string? Description { get; set; }

		public int? NumberOfPoi { get; set; }

		public void UpdateCity(City city)
		{
			if (!string.IsNullOrEmpty(Name))
				city.Name = Name;
			if (!string.IsNullOrEmpty(Description))
				city.Description = Description;
			if (NumberOfPoi != null)
				city.NumberOfPoi = (int)NumberOfPoi;
		}

	}
}