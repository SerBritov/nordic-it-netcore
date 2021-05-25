using System;
using System.Collections.Generic;

namespace _03_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Очередь Queue<T> - коллекция объектов, основанная на принципе "первый поступил -- первым обслужен"
             * используется, когда необходимо, чтобы приложение выполнялось асинхронно
             */

            Queue<int> integerQueue = new Queue<int>();
            integerQueue.Enqueue(1);    //добавить элемент в конец очереди
            integerQueue.Enqueue(2);
            integerQueue.Enqueue(3);
            while (true)
            {
                if (integerQueue.Count == 0)
                    break;
                Console.WriteLine(integerQueue.Dequeue());  //Взять значение и удалить элемент из начала очереди
                Console.WriteLine(integerQueue.Count);  //Число элементов в очереди
            }

        }
    }
}
