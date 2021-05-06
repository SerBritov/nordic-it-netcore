using System;

namespace Homework04
{
    [Flags]
    enum Containers : int
    {
        None = 0,
        small = 1,   //1 litres
        medium = 1<<1,  //5 litres
        large = 1<<2    //20 litres
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            /*Объемы контейнеров и объявление переменных*/
            const int smallestContainerVolume = 1;
            const int mediumContainerVolume = 5;
            const int largeContainerVolume = 20;
            int smallestContainers = 0, mediumContainers = 0, largeContainers = 0;
            Containers neededContainers = 0;
            double juiceVolume;

            /*ввод пользователая*/
            Console.WriteLine("What volume of juice you need to package?");
            juiceVolume = double.Parse(Console.ReadLine());

            /*рассчет числа контейнеров*/
            if (juiceVolume >= largeContainerVolume)
            {
                largeContainers = (int)(juiceVolume / largeContainerVolume);
                juiceVolume %= largeContainerVolume;
                neededContainers |= Containers.large;
            }
            if (juiceVolume >= mediumContainerVolume)
            {
                mediumContainers = (int)(juiceVolume / mediumContainerVolume);
                juiceVolume %=  mediumContainerVolume;
                neededContainers |= Containers.medium;
            }
            if (juiceVolume > 0)
            {
                smallestContainers = (int)(juiceVolume / smallestContainerVolume);
                neededContainers |= Containers.small;
                juiceVolume -= smallestContainers * smallestContainerVolume;
                if (juiceVolume > 0)
                    smallestContainers++;
            }

            /*вывод*/
            Console.WriteLine("Containers you need: ");
            if ((neededContainers & Containers.large) > 0)
                Console.WriteLine($"20 litres: {largeContainers}");
            if ((neededContainers & Containers.medium) > 0)
                Console.WriteLine($"5 litres: {mediumContainers}");
            if ((neededContainers & Containers.small) > 0)
                Console.WriteLine($"1 litres: {smallestContainers}");
            Console.ReadKey();
        }
    }
}
