using System.Linq;
using Microsoft.AspNetCore.Mvc;
using L22_C02_empty_asp_net_core_app_final.Models;

namespace L22_C02_empty_asp_net_core_app_final.Controllers
{
	[ApiController]
	[Route("cities")]
	public class CitiesController : ControllerBase
	{
		private readonly CitiesDataStore _store;

		public CitiesController()
		{
			_store = CitiesDataStore.GetInstance();
		}

		[HttpGet()]
		public IActionResult GetCities()
		{
			if (_store.Cities == null)
				return NotFound();

			return Ok(_store.Cities);
		}

		[HttpGet("{id}", Name = "GetCity")]
		public IActionResult GetCity(int id)
		{
			var city = _store.Cities.FirstOrDefault(x => x.Id == id);

			if (city != null)
			{
				// 200 OK
				return Ok(city);
			}

			// 404 Not Found
			return NotFound("404 Not Found");
		}

		[HttpPost]
		public IActionResult AddCity([FromBody] City city)
		{
			if (_store.Cities.FirstOrDefault(
					x => x.Id == city.Id
						 || x.Name == city.Name) != null)
			{
				return Conflict();
			}

			_store.Cities.Add(city);

			return CreatedAtRoute("GetCity", new { id = city.Id }, city);
		}
	}
}