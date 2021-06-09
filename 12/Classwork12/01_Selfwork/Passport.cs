using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Selfwork
{
	public class Passport : BaseDocument
	{
		public string Country;
		public string PersonName;

		public Passport(string number, DateTimeOffset issueDate, string country, string personName) : base("Passport", number, issueDate)
		{
			Country = country;
			PersonName = personName;
		}


		public override string PropertiesString
		{
			get
			{
				return
			   $"Name: {DocName}; Number: {DocNumber}; Issue date: {IssueDate.ToString()}; Country: {Country}; PersonName: {PersonName}";
			}
			set { }
		}

		//new public void WriteToConsole()
		//{
		//    Console.WriteLine(PropertiesString);
		//}

		public void SetProperties(string name, string number, DateTimeOffset issueDate, string country, string person)
		{
			DocName = name;
			DocNumber = number;
			IssueDate = issueDate;
			Country = country;
			PersonName = person;
		}

		public override bool Equals(object passport)
		{
			return /*passport.ToString() == "_01_Selfwork.Passport"*/
				(passport is Passport) &&
				((Passport)passport).Country == Country &&
				((Passport)passport).DocName == DocName &&
				((Passport)passport).DocNumber == DocNumber &&
				((Passport)passport).IssueDate == IssueDate &&
				((Passport)passport).PersonName == PersonName;
		}

		public void ChangeIssueDate(DateTimeOffset newIssueDate)
		{
			IssueDate = newIssueDate;
		}
	}
}
