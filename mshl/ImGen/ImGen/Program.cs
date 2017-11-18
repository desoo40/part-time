using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

namespace ImGen
{
    class Program
    {
        static void Main(string[] args)
        {
            DefType("incoming\\test1.txt");
            //GoGen("test.txt");
        }

        private static void DefType(string path)
        {
            var l = File.ReadAllLines(path);

            if (l[0].ToLower() == "игры")
            {
                Console.WriteLine("Это файл с играми! Начинаю обработку...");
                for (int i = 1; i < l.Length; i++)
                {
                    Game g = new Game(l[i]);
                    g.SaveImage();
                }
            }
        }

    }
}