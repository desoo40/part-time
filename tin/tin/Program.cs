using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tin
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = 0;
            string tmp;

            while ((tmp = Console.ReadLine()) != null)
            {
                if (tmp == "")
                    continue;

                sum += Convert.ToInt32(tmp);
            }

            Console.WriteLine(sum);
        }
    }
}
