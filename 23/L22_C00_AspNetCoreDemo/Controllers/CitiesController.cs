using System.Linq;
using Microsoft.AspNetCore.Mvc;
using L22_C00_AspNetCoreDemo.DataStore;
using L22_C00_AspNetCoreDemo.Models;
using System;

namespace L22_C00_AspNetCoreDemo.Controllers
{
	[ApiController]
	[Route("api/cities")]
	public class CitiesController : Controller
	{
		private readonly ICitiesDataStore _store;
		public CitiesController(ICitiesDataStore store)
		{
			_store = store;
		}
		[HttpGet]
		public IActionResult GetCities()
		{
			
			var cities = _store.Cities;
			var models = cities
				.Select(c => new CityGetModel(c.Id, c.Name, c.Description, c.NumberOfPoi))
				.ToList();

			var result = Ok(models);
			return result;
		}

		[HttpGet("{id}", Name = "GetCity")] //по адресу /{id} , где id -- номер города, будет возвращена информация о городе
		public IActionResult GetCity(int id)
		{

			var city = _store.Cities
				.Where(c => c.Id == id)
				.FirstOrDefault();

			if (city == null)
				return NotFound();

			return Ok(new CityGetModel(city.Id, city.Name, city.Description, city.NumberOfPoi));
		}

		[HttpPost]
		public IActionResult AddCity([FromBody] CityAddModel cityAddModel)  //[FromBody] --
		{
			if (cityAddModel == null)
				return BadRequest();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (_store.Cities.FirstOrDefault(x => cityAddModel.Name == x.Name) != null)
				return Conflict();

			int id = _store.GetNextId();
			City city = cityAddModel.ToCity(id);
			_store.Cities.Add(city);
			return CreatedAtRoute("GetCity", new
			{
				id
			}, city);
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteCity(int id)
		{
			if (_store.Cities.FirstOrDefault(x => id == x.Id) == null)
			{
				return NotFound();
			}
			_store.Cities.Remove(_store.Cities
				.Where(c => c.Id == id)
				.FirstOrDefault());
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult UpdateCity(int id, [FromBody] CityUpdateModel cityUpdateModel)
		{
			City existingCity = _store.Cities
				.Where(c => c.Id == id)
				.FirstOrDefault();

			if (existingCity == null)
				return NotFound();

			cityUpdateModel.UpdateCity(existingCity);
			return Ok();
		}
	}
}
