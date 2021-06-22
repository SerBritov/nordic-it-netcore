using System;

namespace _01_Selfwork
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ErrorList errorList = new ErrorList("Writing error"))
            {
                errorList.Add("No space available");
                errorList.Add("Damaged file path");
                errorList.Add("Access denied");

                /*foreach(var error in errorList)
                Console.WriteLine($"{errorList.Category}: {error}");*/
                errorList.WriteToConsole();
            }
        }
    }
}
