using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace сSharpDev
{
    class Program
    {
        public class Dot
        {
            public int X;
            public int Y;


        }
        static void Main(string[] args)
        {
            var dots = Convert.ToInt32(Console.ReadLine());
            var p = new List<Dot>();
            var ans = 0;
            for (int i = 0; i < dots; i++)
            {
                var l = Console.ReadLine().Split(' ').ToList();

                var dt = new Dot();
                dt.X = Convert.ToInt32(l[0]);
                dt.Y = Convert.ToInt32(l[1]);

                p.Add(dt);
            }
        
            for (int i = -10000; i <= 10000; i++)
            {
                for (int j = -10000; j <= 10000; j++)
                {
                    var d = new Dot();
                    d.X = i;
                    d.Y = j;

                    if (IsPointInPolygon4(p, d))
                        ans++;
                }
            }

           Console.WriteLine(ans);
        }

        public static bool IsPointInPolygon4(List<Dot> polygon, Dot testPoint)
        {
            bool result = false;
            int j = polygon.Count() - 1;
            for (int i = 0; i < polygon.Count(); i++)
            {
                if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
                {
                    if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
    }
}