using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpDev
{
    class Program
    {
        static void Main(string[] args)
        {

            var dim = Convert.ToInt32(Console.ReadLine());
            var railWays = 0;

            for (int i = 0; i < dim; i++)
            {
                var inStr = Console.ReadLine();
                var iLine = inStr.Split(' ').ToList();

                for (int j = i + 1; j < dim; j++)
                {
                    if (iLine[j] == "1")
                        ++railWays;
                }
            }

            Console.WriteLine(railWays);
        }
    }
}
