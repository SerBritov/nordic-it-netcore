using System;

namespace Homework03
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Minimum and maximum values of multipliers
             */
            const int minCollumnValue = 1, maxCollumnValue = 10;
            const int minLineValue = 1, maxLineValue = 10;

            const int collumnLength = maxCollumnValue - minCollumnValue + 1;
            const int lineLength = maxLineValue - minLineValue + 1;

            /*
             * Setting line and collumn arrays of the table
             */
            int[] tableCollumn = new int[collumnLength];
            int[] tableLine = new int[lineLength];

            for (int i = 0; i < tableCollumn.Length;
                tableCollumn[i] = minCollumnValue + i++) ;
            for (int i = 0; i < tableLine.Length;
                tableLine[i] = minLineValue + i++) ;

            //needed cell length of the table
            int padLeft = (tableLine[tableLine.Length - 1] * tableCollumn[tableCollumn.Length - 1]).ToString().Length + 2;
            /*
             * Output head of the tabel and first line
             */
            string tableHead =
               $"Multiplication table for ({tableLine[0]}..{tableLine[tableLine.Length - 1]}) X ({tableCollumn[0]}..{tableCollumn[tableCollumn.Length - 1]})";
            Console.WriteLine(
                tableHead.ToString().PadLeft((tableLine.Length + 1) * padLeft / 2 + tableHead.Length / 2));
            Console.Write("*".ToString().PadLeft(padLeft));
            for (int i = 0; i < tableLine.Length; Console.Write(tableLine[i++].ToString().PadLeft(padLeft))) ;
            Console.WriteLine();
            string firstLine_ = "";
            for (int i = 0; i < padLeft; i++)
                firstLine_ += "_";
            for (int i = 0; i < tableLine.Length + 1; i++)
                Console.Write(firstLine_);

            /*
             * Output table of values
             */
            for (int i = 0; i < tableCollumn.Length; i++)
            {
                Console.WriteLine();
                Console.Write(tableCollumn[i].ToString().PadLeft(padLeft - 1) + "|");
                for (int j = 0; j < tableLine.Length; j++)
                {
                    Console.Write((tableCollumn[i] * tableLine[j]).ToString().PadLeft(padLeft));
                }
            }
            Console.ReadKey();

        }
    }
}
