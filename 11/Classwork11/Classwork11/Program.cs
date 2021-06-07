using System;

namespace Classwork11
{
    class Program
    {
        static void Main(string[] args)
        {
            Pet pet1 = new Pet();       //инициализация через свойства
            pet1.Name = "Кисольда";
            pet1.Kind = "Cat";
            pet1.Sex = 'f';
            pet1.DateOfBirth = DateTimeOffset.Parse("2012-01-01T12:00:00+0300");
                     
            Pet pet2 = new Pet()        //инициализация через инициализатор
            {
                Kind = "Dog",
                Name = "Терри",
                Sex = 'M',
                DateOfBirth = DateTimeOffset.Parse("2020-01-01T12:00:00+0300")
        };

            pet1.WriteDescription(true);
            pet2.WriteDescription();

            ///

            Button[] buttons = new Button[10];
            ButtonFactory buttonFactory = new ButtonFactory();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttonFactory.PushOnCreate = i < 5;
                buttons[i] = buttonFactory.CreateButton();
            }

            foreach (var button in buttons)
            {
                var state = button.IsPushed ? "pushed" : "not pushed";
                Console.WriteLine($"Button is {state}");
            }
        }
    }
}
