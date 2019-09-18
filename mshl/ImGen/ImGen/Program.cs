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
            if (!Directory.Exists("Входящие"))
                Directory.CreateDirectory("Входящие");

            SearchFiles();
            Console.WriteLine("Готово! Нажми любую кнопку и наслаждайся картинками!");
            Console.Read();
        }

        private static void SearchFiles()
        {
            var files = Directory.GetFiles("Входящие");

            if (!Directory.Exists("complete"))
                Directory.CreateDirectory("complete");

            foreach (var file in files)
            {
                Console.WriteLine($"Найден файл {file}");

                DefType(file);
                var name = Path.GetFileNameWithoutExtension(file);

                if (File.Exists($"complete\\{name}.txt"))
                    File.Delete($"complete\\{name}.txt");

                File.Move(file, $"complete\\{name}.txt");
            }
        }

        private static void DefType(string path)
        {
            var dt = DateTime.Now.ToString("yy.MM.dd HH-mm");

            var l = File.ReadAllLines(path);

            if (l[0].ToLower() == "игры")
            {
                Console.WriteLine("Это файл с играми! Начинаю обработку...\n");

                for (int i = 1; i < l.Length; i++)
                {
                    Game g = new Game(l[i], dt);
                    g.SaveImage();
                }
            }
            else
                Console.WriteLine($"[Ошибка] Какой-то неизвезтный мне файл! {path}");
        }

    }
}