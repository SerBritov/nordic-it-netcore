using System;

namespace _02_Selfwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var contact1 = new Contact()
            {
                Name = "Sergei",
                PhoneNumber = "+1232345",
                Adress = "Moscow, some street etc"
            };
            var contact2 = new Contact()
            {
                Name = "Petya",
                PhoneNumber = "+654325",
                Adress = "Some other city"
            };

            var phoneBook = new PhoneBook();
            phoneBook.AddNewContact(contact1);
            phoneBook.AddNewContact(contact2);

            var searchedContact = phoneBook.Search("Sergei");
            Console.WriteLine($"{searchedContact.Name} from {searchedContact.Adress}, {searchedContact.PhoneNumber}");
        }
    }
}
