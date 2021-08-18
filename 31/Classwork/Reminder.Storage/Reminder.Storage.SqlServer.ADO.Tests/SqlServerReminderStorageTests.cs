using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using Reminder.Storage.SqlServer.ADO.Tests.Properties;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace Reminder.Storage.SqlServer.ADO.Tests
{
    [TestClass]
    public class SqlServerReminderStorageTests
    {
        private static string _connectionString;
        
        [ClassInitialize]  //запускается единожды на сессию тестов
        public static void ClassInitialize(TestContext context)
        {
            _connectionString = new ConfigurationBuilder()
                .AddJsonFile("AppSettings.json")
                .Build()
                .GetConnectionString("DefaultConnection");
        }

        [TestInitialize]  //запускается перед каждым тестом
        public void TestInitialize()
        {
            RunSqlScript(Properties.Resources.Schema);
            RunSqlScript(Properties.Resources.SPs);            
            // run Schema.sql on SQL server
        }

        [TestMethod]
        public void Add_Returns_Non_Empty_Guid()
        {
            var storage = new SqlServerReminderStorage(_connectionString);
            var item = new ReminderItemRestricted(
                DateTimeOffset.MinValue,
                "message",
                "contactId",
                ReminderItemStatus.ReadyToSend);

            Guid actual = storage.Add(item);
            Assert.AreNotEqual(Guid.Empty, actual);
        }

        [TestMethod]
        public void Get_Returns_ReminderItem()
        {
            var storage = new SqlServerReminderStorage(_connectionString);
            var item = new ReminderItemRestricted(
                DateTimeOffset.MinValue,
                "message",
                "contactId",
                ReminderItemStatus.ReadyToSend);

            Guid actualId = storage.Add(item);
            var testedItem = storage.Get(actualId);
            Assert.AreEqual(item.Status, testedItem.Status);
            Assert.AreEqual(item.ContactId, testedItem.ContactId);
            Assert.AreEqual(item.Message, testedItem.Message);
            Assert.AreEqual(item.Date, testedItem.Date);
        }
        public void RunSqlScript(object script)
        {
            using SqlConnection sqlConnection = GetOpenedSqlConnection();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            string[] sqlInstructions = Regex.Split(script.ToString(), @"\bGO\b");

            foreach(string sqlInstruction in sqlInstructions.Where(s => !string.IsNullOrEmpty(s)))  //выполнять непустые строки
            {
                cmd.CommandText = sqlInstruction;
                cmd.ExecuteNonQuery();
            }
        }

        private SqlConnection GetOpenedSqlConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            return sqlConnection;
        }
    }
}
