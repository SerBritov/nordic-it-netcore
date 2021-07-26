namespace L22_C02_empty_asp_net_core_app_final.Models
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
