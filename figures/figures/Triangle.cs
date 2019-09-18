using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figures
{
    public class Triangle : IFigure
    {
        private double A;
        private double B;
        private double C;

        public Triangle(double s1, double s2, double s3)
        {
            if (s1 <= 0 || s2 <= 0 || s3 <= 0)
                throw new ArgumentException("Стороны треугольника должны быть положительными");

            if (!CheckForTriangleRule(s1, s2, s3))
                throw new ArgumentException($"{s1} {s2} {s3} такой треугольник не существует");

            A = s1;
            B = s2;
            C = s3;
        }

        private bool CheckForTriangleRule(double s1, double s2, double s3)
        {
            return s1 + s2 > s3 && s1 + s3 > s2 && s2 + s3 > s1;
        }

        public double CalcSquare()
        {
            var p = (A + B + C) / 2.0;

            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public bool CheckIfRight()
        {
            var a2 = A * A;
            var b2 = B * B;
            var c2 = C * C;

            return Math.Abs(c2 - (a2 + b2)) < 0.001 || Math.Abs(a2 - (b2 + c2)) < 0.001 || Math.Abs(b2 - (a2 + c2)) < 0.001;
        }

        public void Print()
        {
            Console.WriteLine($"A = {A}\n" +
                              $"B = {B}\n" +
                              $"C = {C}\n");
        }
    }
}
