using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Storage.WebApi.Controllers
{
	[ApiController]
	[Route("api/reminders")]
	public class RemindersController : ControllerBase
	{
		private readonly ILogger<RemindersController> _logger;
		private readonly IReminderStorage _storage;

		public RemindersController(ILogger<RemindersController> logger, IReminderStorage storage)
		{
			_logger = logger;
			_storage = storage;
		}

		[HttpGet("{id}", Name = "GetReminderItemById")]
		public IActionResult Get(Guid id)
		{
			ReminderItem reminderItem = _storage.Get(id);
			if (reminderItem == null)
				return NotFound();

			return Ok(new ReminderItemGetModel(reminderItem));
		}

		[HttpPost]
		public IActionResult Add([FromBody]ReminderItemAddModel reminderItemAddModel)
		{
			if (reminderItemAddModel == null)
				return BadRequest();

			ReminderItemRestricted reminderItemRestricted = reminderItemAddModel.ToReminderItemRestricted();
			Guid id = _storage.Add(reminderItemRestricted);

			return CreatedAtRoute(
				"GetReminderItemById",
				new { id },
				new ReminderItemGetModel(reminderItemRestricted.ToReminderItem(id)));
		}

		[HttpGet]
		public IActionResult GetList([FromQuery(Name = "status")] ReminderItemStatus status)
		{
			List<ReminderItemGetModel> list = _storage
				.GetList(status)
				.Select(ri => new ReminderItemGetModel(ri))
				.ToList();

			return Ok(list);
		}

		[HttpPut("{id}")]
		public IActionResult Update(Guid id, [FromBody]ReminderItemAddModel reminderItemAddModel)
		{
			ReminderItem reminderItem = _storage.Get(id);
			if (reminderItem == null)
				return NotFound();

			reminderItem.ContactId = reminderItemAddModel.ContactId;
			reminderItem.Date = reminderItemAddModel.Date;
			reminderItem.Message = reminderItemAddModel.Message;
			reminderItem.Status = reminderItemAddModel.Status;

			_storage.Update(reminderItem);

			return Ok();
		}
	}
}
