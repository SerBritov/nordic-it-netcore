using System;
using System.Text;

namespace _06_string_builder
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Цена";
            s += " | ";
            s += "Количество";
            s += " | ";
            s += " Стоимость ";

            /*
             * StringBuilder -- позволяет оптимизированно работать со строками
             */
            StringBuilder sb = new StringBuilder();
            sb.Append("Цена");
            sb.Append(" | ");
            sb.Append("Количество");
            sb.Append(" | ");
            sb.Append(" Стоимость ");
            sb.Remove(5, 13);
            sb.Insert(5, 25);
            sb.AppendFormat("Дата: {0:yyyy-MM-dd}", DateTimeOffset.Now);
            if (sb.Length > 0)
            {
                var result = sb.ToString();
                Console.WriteLine(result);
            }

        }
    }
}
