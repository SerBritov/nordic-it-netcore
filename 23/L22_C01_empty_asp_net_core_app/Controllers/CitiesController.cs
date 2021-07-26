using System.Collections.Generic;
using System.Linq;
//using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using L22_C01_empty_asp_net_core_app.DataStore;
using L22_C01_empty_asp_net_core_app.Models;
using Microsoft.Extensions.Logging;

namespace L22_C01_empty_asp_net_core_app.Controllers
{
	[Route("/api/cities")]
	public class CitiesController : Controller
	{
		private ILogger<CitiesController> _logger;
		private ICitiesDataStore _dataStore;

		public CitiesController(
			ILogger<CitiesController> logger,
			ICitiesDataStore dataStore)
		{
			_logger = logger;
			_dataStore = dataStore;
		}

		[HttpGet]
		public IActionResult GetCities()
		{
			_logger.LogInformation($"{nameof(GetCities)} called");

			List<City> cities = _dataStore.Cities;
			if (cities == null)
				return NotFound();

			List<GetCityModel> models = cities
				.Select(c => new GetCityModel(
					c.Id,
					c.Name,
					c.Description,
					c.NumberOfPoi))
				.ToList();

			return Ok(models);
		}

		[HttpGet("{id}")]
		public IActionResult GetCity(int id)
		{
			City city = _dataStore
				.Cities
				.FirstOrDefault(c => c.Id == id);

			if (city == null)
				return NotFound();

			var model = new GetCityModel(
				city.Id,
				city.Name,
				city.Description,
				city.NumberOfPoi);

			return Ok(model);
		}

		[HttpPost]
		public IActionResult AddCity([FromBody] AddCityModel addCityModel)
		{
			if (addCityModel == null)
				return BadRequest();

			if (_dataStore.Cities.FirstOrDefault(c => c.Name == addCityModel.Name) != null)
				return Conflict("The city with name specified already exists");

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			int newId = _dataStore.GetNewId();

			var city = new City(
				newId,
				addCityModel.Name,
				addCityModel.Description,
				addCityModel.NumberOfPoi);

			_dataStore.Cities.Add(city);

			var getCityModel = new GetCityModel(
				newId,
				addCityModel.Name,
				addCityModel.Description,
				addCityModel.NumberOfPoi);

			return CreatedAtAction(
				"GetCity",
				new {id = newId},
				getCityModel);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateCity(int id, [FromBody] UpdateCityModel updateCityModel)
		{
			if (updateCityModel == null)
				return BadRequest();

			City city = _dataStore
				.Cities
				.FirstOrDefault(c => c.Id == id);

			if (city == null)
				return NotFound();

			city.Name = updateCityModel.Name;
			city.Description = updateCityModel.Description;
			city.NumberOfPoi = updateCityModel.NumberOfPoi;

			return NoContent();
		}

		// Patch
		[HttpPatch("{id}")]
		//public IActionResult PatchCity(
		//	int id,
		//	[FromBody] JsonPatchDocument<UpdateCityModel> patchCityDoc)
		//{
		//	if (patchCityDoc == null)
		//		return BadRequest();

		//	City city = _dataStore
		//		.Cities
		//		.FirstOrDefault(c => c.Id == id);

		//	if (city == null)
		//		return NotFound();

		//	var updateCityModel = new UpdateCityModel(city.Name, city.Description, city.NumberOfPoi);
		//	patchCityDoc.ApplyTo(updateCityModel);

		//	// reflect changes from model back to data

		//	if (city.Name != updateCityModel.Name)
		//		city.Name = updateCityModel.Name;

		//	if (city.Description != updateCityModel.Description)
		//		city.Description = updateCityModel.Description;

		//	if (city.NumberOfPoi != updateCityModel.NumberOfPoi)
		//		city.NumberOfPoi = updateCityModel.NumberOfPoi;

		//	return NoContent();
		//}

		[HttpDelete("{id}")]
		public IActionResult DeleteCity(int id)
		{
			City city = _dataStore
				.Cities
				.FirstOrDefault(c => c.Id == id);

			if (city == null)
				return NotFound();

			_dataStore.Cities.Remove(city);

			return NoContent();
		}
	}
}
