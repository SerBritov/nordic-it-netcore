using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork11
{
    public partial class Pet
    {
        public string Kind;
        public string Name;
        public char Sex;
        public DateTimeOffset DateOfBirth;
        public Pet()
        {

        }
        public Pet(string name, string kind)
        {
            Name = name;
            Kind = kind;
        }

        public Pet(string name, string kind, char sex, DateTimeOffset dateOfBirth)
        {
            Name = name;
            Kind = kind;
            Sex = sex;
            DateOfBirth = dateOfBirth;
        }
    }
}
