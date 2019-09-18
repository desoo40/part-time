using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figures
{
    public class Circle : IFigure
    {
        private double Radius;

        public Circle(double r)
        {
            if (r <= 0)
                throw new ArgumentException("Радиус должен быть положительным");

            Radius = r;
        }

        public double CalcSquare()
        {
            return Math.PI * Radius * Radius;
        }

        public void Print()
        {
            Console.WriteLine($"R = {Radius}\n");
        }
    }
}
