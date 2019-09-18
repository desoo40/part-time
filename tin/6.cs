using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace сSharpDev
{
    class Program
    {
        static void Main(string[] args)
        {
            var megaDict = new Dictionary<string, Dictionary<string, int>>();

            string tmp;

            while ((tmp = Console.ReadLine()) != null)
            {
                if (tmp == "")
                    continue;

                var parse = tmp.Split(' ').ToList();

                var name = parse[0];
                var product = parse[1];
                var count = Convert.ToInt32(parse[2]);

                if (megaDict.ContainsKey(name))
                {
                    if (megaDict[name].ContainsKey(product))
                        megaDict[name][product] += count;
                    else
                        megaDict[name].Add(product, count);
                }
                else
                {
                    var tmpDcit = new Dictionary<string, int>();

                    tmpDcit.Add(product, count);

                    megaDict.Add(name, tmpDcit);
                }

            }

            var names = from pairN in megaDict
                        orderby pairN.Key
                        select pairN;

            foreach (var pairN in names)
            {
                Console.WriteLine("{0}:", pairN.Key);

                var products = from pairP in pairN.Value
                    orderby pairP.Key
                    select pairP;

                foreach (var pairP in products)
                {
                    Console.WriteLine("{0} {1}", pairP.Key, pairP.Value);
                }
            }
        }
    }
}