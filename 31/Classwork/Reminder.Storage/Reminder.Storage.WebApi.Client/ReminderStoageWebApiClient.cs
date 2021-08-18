using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;

namespace Reminder.Storage.WebApi.Client
{
	public class ReminderStoageWebApiClient : IReminderStorage
	{
		private readonly HttpClient _httpClient;
		private readonly string _baseWebApiUrl;

		public ReminderStoageWebApiClient(string baseWebApiUrl)
		{
			if(baseWebApiUrl == null)
			{
				throw new ArgumentNullException(nameof(baseWebApiUrl));
			}

			_baseWebApiUrl = baseWebApiUrl.TrimEnd('/');

			_httpClient = new HttpClient();
		}

		public Guid Add(ReminderItemRestricted reminderItemRestricted)
		{
			HttpResponseMessage httpResponseMessage = GetResponseAfterSending(
				HttpMethod.Post,
				_baseWebApiUrl,
				JsonConvert.SerializeObject(new ReminderItemAddModel(reminderItemRestricted)));

			if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.Created)
				ThrowException(httpResponseMessage);

			string responceContent = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			ReminderItemGetModel reminderItemGetModel =
				JsonConvert.DeserializeObject<ReminderItemGetModel>(responceContent);

			return reminderItemGetModel.Id;
		}

		public ReminderItem Get(Guid id)
		{
			HttpResponseMessage httpResponseMessage = GetResponseAfterSending(
				HttpMethod.Get,
				_baseWebApiUrl + $"/{id}");

			if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK)
				ThrowException(httpResponseMessage);
			
			string responceContent = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			ReminderItemGetModel reminderItemGetModel =
				JsonConvert.DeserializeObject<ReminderItemGetModel>(responceContent);

			return reminderItemGetModel.ToReminderItem();
		}

		private static void ThrowException(HttpResponseMessage httpResponseMessage)
		{
			throw new Exception(
				$"Error: { httpResponseMessage.StatusCode }" +
				$"Content: {httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult()}");
		}

		public List<ReminderItem> GetList(ReminderItemStatus status)
		{
			HttpResponseMessage httpResponseMessage = GetResponseAfterSending(
				HttpMethod.Get,
				_baseWebApiUrl + $"?status={status}");

			if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK)
				ThrowException(httpResponseMessage);

			string responceContent = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			List<ReminderItemGetModel> reminderItemGetModels =
				JsonConvert.DeserializeObject<List<ReminderItemGetModel>>(responceContent);

			return reminderItemGetModels
				.Select(rigm => rigm.ToReminderItem())
				.ToList();
		}

		public void Update(ReminderItem reminderItem)
		{
			HttpResponseMessage httpResponseMessage = GetResponseAfterSending(
				HttpMethod.Put,
				_baseWebApiUrl + $"/{reminderItem.Id}",
				JsonConvert.SerializeObject(new ReminderItemAddModel(reminderItem)));

			if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK)
				ThrowException(httpResponseMessage);
		}

		private HttpResponseMessage GetResponseAfterSending(HttpMethod httpMethod, string url, string content = null)
		{
			var httpRequestMessage = new HttpRequestMessage(httpMethod, url);
			if (content != null)
				httpRequestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");

			return _httpClient.SendAsync(httpRequestMessage).GetAwaiter().GetResult();
		}
	}
}
