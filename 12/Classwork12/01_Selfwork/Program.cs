using System;

namespace _01_Selfwork
{
	class Program
	{
		static void Main(string[] args)
		{

			var passport2 = new Passport("124253", DateTimeOffset.Parse("12.01.2020"), "Russia", "Sergei");
			var passport3 = new Passport("124253", DateTimeOffset.Parse("12.01.2020"), "Russia", "Sergei");

			//passport2.SetProperties("name", "12421354", DateTimeOffset.Parse("12.01.2020"), "Russia", "Sergei");


			passport2.WriteToConsole();
			Console.WriteLine(passport2.Equals(passport3));

			var doc1 = new BaseDocument();
			var doc2 = new BaseDocument();
			doc1.SetProperties("name", "12421354", DateTimeOffset.Parse("12.01.2020"));
			doc1.WriteToConsole();
			doc2.SetProperties("name", "12421354", DateTimeOffset.Parse("12.01.2020"));

			Console.WriteLine(doc1.Equals(doc2));
			int length = 4;
			BaseDocument[] someDoc = new BaseDocument[length];

			someDoc[0] = passport2;
			someDoc[1] = passport3;
			someDoc[2] = doc1;
			someDoc[3] = doc2;

			foreach (var doc in someDoc)
			{
				if (doc is Passport)
					((Passport)doc).ChangeIssueDate(DateTimeOffset.Now);
			}

			foreach (var doc in someDoc)
				doc.WriteToConsole();
		}
	}
}

