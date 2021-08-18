using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Reminder.Storage.SqlServer.ADO
{
    public class SqlServerReminderStorage : IReminderStorage
    {
        private readonly string _connectionString;

        public SqlServerReminderStorage(string connectionString)
        {
            _connectionString = connectionString;            
        }

        public Guid Add(ReminderItemRestricted reminderItem)
        {
            using var sqlConnection = GetOpenedSqlConnection();
            var cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.AddReminderItem";

            cmd.Parameters.AddWithValue("@contactId", reminderItem.ContactId);
            cmd.Parameters.AddWithValue("@targetDate", reminderItem.Date);
            cmd.Parameters.AddWithValue("@message", reminderItem.Message);
            cmd.Parameters.AddWithValue("@statusId", reminderItem.Status);

            var outputIdParameter = new SqlParameter("@reminderId", System.Data.SqlDbType.UniqueIdentifier, 1);
            outputIdParameter.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outputIdParameter);

            cmd.ExecuteNonQuery();

            return (Guid)outputIdParameter.Value;
        }

        public void Update(ReminderItem reminderItem)
        {
            throw new Exception();
        }

        public ReminderItem Get(Guid id)
        {
            using var sqlConnection = GetOpenedSqlConnection();
            var cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM dbo.ReminderItem";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetGuid(reader.GetOrdinal("Id")) == id)
                    {
                        var reminderItem = new ReminderItem(
                            id,
                            reader.GetDateTimeOffset(reader.GetOrdinal("TargetDate")),
                            reader.GetString(reader.GetOrdinal("Message")),
                            reader.GetString(reader.GetOrdinal("ContactId")),
                            (ReminderItemStatus)reader.GetByte(reader.GetOrdinal("StatusId")));
                        return reminderItem;
                    }                    
                }
                throw new Exception("Nothing found");               
            }
           
        }

        public List<ReminderItem> GetList(ReminderItemStatus status)
        {
        throw new Exception();
    }
        private SqlConnection GetOpenedSqlConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            return sqlConnection;
        }

        Guid IReminderStorage.Add(ReminderItemRestricted reminderItem)
        {
            throw new NotImplementedException();
        }

        ReminderItem IReminderStorage.Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
