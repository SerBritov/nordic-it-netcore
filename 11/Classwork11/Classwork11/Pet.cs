using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork11
{
    public partial class Pet
    {
        public byte Age
        {
            get
            {
                TimeSpan age = DateTimeOffset.Now - DateOfBirth;    //тип данных, получаемый как разница из другого типа данных
                return (byte)(Math.Floor(age.TotalDays / 365.25));
            }
        }

        public string Description
        {
            get { return $"{Name} is a {Kind}({Sex}) of {Age} years old"; }
        }

        public string ShortDescription
        {
            get { return $"{Name} is a {Kind}"; }
        }
        public void WriteDescription(bool showFullDescription = false, string prefix = "*")   //последний параметр является опциональным -- для этого его нужно указать
        {
            Console.WriteLine(
                prefix + " " + (showFullDescription ? 
                Description : 
                ShortDescription));
        }
    }
}
