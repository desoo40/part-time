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
            string outStr = "";

            var inStr = Console.ReadLine();

            if (inStr == null)
            {
                Console.WriteLine("");
                return;
            }

            var listWords = inStr.Split(' ').ToList();

            listWords.RemoveAll(IsEmpty);

            for (int i = 0; i < listWords.Count; i++)
            {
                outStr += listWords[i];

                if (i != listWords.Count - 1)
                    outStr += " ";
            }

            Console.WriteLine(outStr);
        }

        private static bool IsEmpty(String s)
        {
            return s == "";
        }
    }
}
