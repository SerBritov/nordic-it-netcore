using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _02_Selfwork
{
    class PhoneBook
    {   public class Contact
        {
            public string Name;
            public string PhoneNumber;
            public string Adress;
        }
        public List<Contact> contacts = new List<Contact>();

        public void AddNewContact(Contact newContact)
        {
            contacts.Add(newContact);
        }

        public Contact Search(string name)
        {
            foreach (var contact in contacts)
                if (contact.Name == name)
                    return contact;
            return null;
        }
    }
}