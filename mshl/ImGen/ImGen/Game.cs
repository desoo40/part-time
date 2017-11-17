using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImGen
{
    class Game
    {
        public TextInImg Division { get; set; }
        public TextInImg HomeTeam { get; set; }
        public ImgInImg HomeTeamLogo { get; set; }
        public ImgInImg AwayTeamLogo { get; set; }
        public TextInImg AwayTeam { get; set; }
        public TextInImg ScorePeriods { get; set; }
        public TextInImg Score { get; set; }
        public TextInImg Date { get; set; }

        public ImgInImg MshlLogo { get; set; }
        public TextInImg HomeLower { get; set; }
        public TextInImg AwayLower { get; set; }
        public TextInImg Mshl { get; set; }



        public Game(string s)
        {
            FillSheet("sheets\\game.txt");
            FillData(s);
        }

        private void FillData(string s)
        {
            var pars = s.Split(';');

            Date.Text = pars[0];
            FillTeams(pars[1]);
            Division.Text = pars[2];
            if (Division.Text.ToLower() == "абитуриент")
                Division.Gradient.LinearColors = new Color[2]
                {
                    Color.FromArgb(192, 250, 176), Color.FromArgb(165, 216, 157)
                };

            if (Division.Text.ToLower() == "бакалавр")
                Division.Gradient.LinearColors = new Color[2]
                {
                    Color.FromArgb(203, 250, 255), Color.FromArgb(175, 213, 222)
                };

            if (Division.Text.ToLower() == "магистр")
                Division.Gradient.LinearColors = new Color[2]
                {
                    Color.FromArgb(190, 208, 228), Color.FromArgb(212, 237, 255)
                };

            ScorePeriods.Text = pars[3].Replace("\t", " ");
            Score.Text = pars[4];
        }

        private void FillTeams(string s)
        {
            var teams = s.Replace(" ", "").Split('-');

            TextHelper th = new TextHelper();

            var namedByHt = th.FindNamedBy(teams[0]);
            HomeTeam.Text = namedByHt[0];
            HomeLower.Text = namedByHt[1];

            var namedByAt = th.FindNamedBy(teams[1]);
            AwayTeam.Text = namedByAt[0];
            AwayLower.Text = namedByAt[1];


            HomeTeamLogo.Image = Image.FromFile($"images\\logos\\{teams[0].ToLower()}.png");
            AwayTeamLogo.Image = Image.FromFile($"images\\logos\\{teams[1].ToLower()}.png");
            MshlLogo.Image = Image.FromFile("images\\logos\\мсхл.png");
        }

        private void FillSheet(string sheetsGameTxt)
        {
            var sheetList = File.ReadAllLines(sheetsGameTxt);

            if (sheetList.Length == 0)
            {
                Console.WriteLine(@"ERROR(файл не содержит строк)");
                return;
            }

            for (int i = 0; i < sheetList.Length; i++)
            {
                if (sheetList[i] == "Images")
                    i = FillImages(sheetList, ++i);

                if (sheetList[i] == "Texts")
                    i = FillTexts(sheetList, ++i);
            }



        }
        private int FillTexts(string[] lines, int i)
        {
            while (lines[i] != "+")
            {
                if (lines[i] == "Division")
                    Division = new TextInImg(lines, ++i);

                if (lines[i] == "Date")
                    Date = new TextInImg(lines, ++i);

                if (lines[i] == "ScorePeriods")
                    ScorePeriods = new TextInImg(lines, ++i);

                if (lines[i] == "Score")
                    Score = new TextInImg(lines, ++i);

                if (lines[i] == "HomeTeam")
                    HomeTeam = new TextInImg(lines, ++i);

                if (lines[i] == "AwayTeam")
                    AwayTeam = new TextInImg(lines, ++i);

                if (lines[i] == "HomeLower")
                    HomeLower = new TextInImg(lines, ++i);

                if (lines[i] == "AwayLower")
                    AwayLower = new TextInImg(lines, ++i);

                if (lines[i] == "Mshl")
                    Mshl = new TextInImg(lines, ++i);

                ++i;
            }
            return i;
        }

        private int FillImages(string[] lines, int i)
        {
            while (lines[i] != "+")
            {
                if (lines[i] == "HomeTeamLogo")
                    HomeTeamLogo = new ImgInImg(lines[++i]);

                if (lines[i] == "AwayTeamLogo")
                    AwayTeamLogo = new ImgInImg(lines[++i]);

                if (lines[i] == "MshlLogo")
                    MshlLogo = new ImgInImg(lines[++i]);

                ++i;
            }
            return i;
        }

        public void SaveImage()
        {
            Image bitmap = Image.FromFile("images\\blanks\\game2.jpg");

            using (Graphics g = Graphics.FromImage(bitmap))
            {

                


                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                var h = GetInscribed(HomeTeamLogo.Position, HomeTeamLogo.Image.Size);
                var a = GetInscribed(AwayTeamLogo.Position, AwayTeamLogo.Image.Size);
                var m = GetInscribed(MshlLogo.Position, MshlLogo.Image.Size);


                g.DrawImage(HomeTeamLogo.Image, h);
                g.DrawImage(AwayTeamLogo.Image, a);
                g.DrawImage(MshlLogo.Image, m);
                
                g.DrawString(Division.Text, Division.Font, Division.Gradient, Division.Position, Division.StrFormatting);
                g.DrawString("MSHLIVE.RU", Mshl.Font, Mshl.Gradient, Mshl.Position, Mshl.StrFormatting);

                g.DrawString(HomeTeam.Text, HomeTeam.Font, HomeTeam.Gradient, HomeTeam.Position, HomeTeam.StrFormatting);
                g.DrawString(AwayTeam.Text, AwayTeam.Font, AwayTeam.Gradient, AwayTeam.Position, AwayTeam.StrFormatting);
                g.DrawString(HomeLower.Text, HomeLower.Font, HomeLower.Gradient, HomeLower.Position, HomeLower.StrFormatting);
                g.DrawString(AwayLower.Text, AwayLower.Font, AwayLower.Gradient, AwayLower.Position, AwayLower.StrFormatting);
                g.DrawString(Score.Text, Score.Font, Score.Gradient, Score.Position, Score.StrFormatting);
                g.DrawString(ScorePeriods.Text, ScorePeriods.Font, ScorePeriods.Gradient, ScorePeriods.Position, ScorePeriods.StrFormatting);
                g.DrawString(Date.Text, Date.Font, Date.Gradient, Date.Position, Date.StrFormatting);

                //g.DrawRectangle(Pens.Red, Division.Position);
                //g.DrawRectangle(Pens.Red, AwayTeam.Position);
                //g.DrawRectangle(Pens.Red, HomeTeam.Position);
                //g.DrawRectangle(Pens.Red, Score.Position);
                //g.DrawRectangle(Pens.Red, ScorePeriods.Position);
                //g.DrawRectangle(Pens.Red, Date.Position);
                //g.DrawRectangle(Pens.Red, Mshl.Position);
                //g.DrawRectangle(Pens.Red, h);
                //g.DrawRectangle(Pens.Red, a);
                //g.DrawRectangle(Pens.Red, m);



            }

            var id = Date.Text.Replace(".","-");

            var file = $"images\\complete\\{id}_{HomeTeam.Text}-{AwayTeam.Text}.jpg";

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

        private static Rectangle GetInscribed(Rectangle baseRect, Size inputsize)
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
