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
            DefType("incoming\\test.txt");
            //GoGen("test.txt");
        }

        private static void DefType(string path)
        {
            var l = File.ReadAllLines(path).ToList();

            if (l[0].ToLower() == "результаты")
            {
                Game g = new Game(l);

                MakeImage(g);



            }
        }

        private static void MakeImage(Game game)
        {
            PrivateFontCollection collection = new PrivateFontCollection();
            collection.AddFontFile("seguisbi.ttf");
  
            Font div = new Font(collection.Families[0], 150, FontStyle.Bold);

            Image bitmap = Image.FromFile("blanks\\score.jpg");

            LinearGradientBrush linGrBrush = new LinearGradientBrush(
                new Point(0, 70),
                new Point(0, 220),
                Color.FromArgb(186, 203, 219),
                Color.FromArgb(218, 243, 255) // Opaque red
                ); // Opaque blue

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Image hometeam = Image.FromFile($"logos\\{game.HomeTeam}1.png");
                Image awayteam = Image.FromFile($"logos\\{game.AwayTeam}.png");

                Console.WriteLine(bitmap.Size.Height + "  " + bitmap.Size.Width);
                Console.WriteLine(hometeam.Size.Height + "  " + hometeam.Size.Width);
                Console.WriteLine(awayteam.Size.Height + "  " + awayteam.Size.Width);


                Console.Read();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawString(game.Division.ToUpper(), div, linGrBrush,500, 60);
                g.DrawImage(hometeam, 106, 366);
                g.DrawImage(awayteam, 1315, 366);


            }


            var file = $"complete\\res{game.HomeTeam}-{game.AwayTeam}.jpg";

            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;

            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            bitmap.Save(file, jpgEncoder, myEncoderParameters);
        }

        private static void GoGen(string v)
        {
            Image bitmap = Image.FromFile("test1.jpg");
            var kek = File.ReadAllLines(v).ToList();

            LinearGradientBrush linGrBrush = new LinearGradientBrush(
                new Point(0, 10),
                new Point(0, 60),
                Color.FromArgb(80, 80, 80),
                Color.FromArgb(10, 10, 10)  // Opaque red
                );  // Opaque blue

            Font f = new Font("Calibri", 90);
            Font place = new Font("Calibri", 50);
            Font time = new Font("Calibri", 50);



            using (Graphics g = Graphics.FromImage(bitmap))
            {

                Point ulCorner = new Point(100, 100);
                Point urCorner = new Point(550, 100);
                Point llCorner = new Point(150, 250);
                Point leCorner = new Point(600, 250);

                Point[] destPara = { ulCorner, urCorner, leCorner, llCorner};

                // Draw image to screen.
                //g.FillPolygon(linGrBrush, destPara);
                //g.DrawString("РАСПИСАНИЕ ИГР", f, linGrBrush, new PointF(500, 200));

                for (int i = 0; i < kek.Count; i++)
                {
                    if (kek[i].ToLower() == "магистр")
                    {
                        var teams = kek[++i].Split('-');
                        var team1 = Image.FromFile($"logos\\{teams[0].ToLower()}.png");
                        var team2 = Image.FromFile($"logos\\{teams[1].ToLower()}.png");
                        Point t1 = new Point(35, 245);
                        Point t2 = new Point(220, 250);

                        Rectangle te1 = GetInscribed(new Rectangle(t1, new Size(75, 75)), team1.Size);
                        Rectangle te2 = GetInscribed(new Rectangle(t2, new Size(75, 75)), team2.Size);


                        g.DrawImage(team1, te1);
                        g.DrawImage(team2, te2);

                    }
                }
            }

            var file = "Stat.jpg";

            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;

            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            bitmap.Save(file, jpgEncoder, myEncoderParameters);
            
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private static  Rectangle GetInscribed(Rectangle baseRect, Size inputsize)
        {
            Rectangle resRect = baseRect;

            //соотношение сторон
            float ratio = inputsize.Width / (float)inputsize.Height;

            int height = baseRect.Height;
            int width = (int)(height * ratio);

            if (width > baseRect.Width)
            {
                width = baseRect.Width;
                height = (int)(width / ratio);
            }

            var x = baseRect.X + baseRect.Width / 2 - width / 2;
            var y = baseRect.Y + baseRect.Height / 2 - height / 2;

            resRect = new Rectangle(x, y, width, height);

            return resRect;
        }

    }
}
