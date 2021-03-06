﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace ImGen
{
    public class TextInImg
    {
        // в дальнейшем может пригодиться ввести флаг отличающий оффсетные тексты от обычных...
        public string Text = "";
        public bool IsOffset { get; set; }
        public bool IsOutline = false;
        public bool IsGradient = false;

        public Color OutlineColor { get; set; }
        public Rectangle Position { get; set; }
        public Size RectSize { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public Font Font { get; set; }
        public Brush Color { get; set; }
        public LinearGradientBrush Gradient { get; set; }

        public StringFormat StrFormatting { get; set; }

        PrivateFontCollection coll = new PrivateFontCollection();

        public TextInImg() {}

        public TextInImg(string[] lines, int i)
        {
            Format format = new Format();
            if (CheckForNothing(lines[i]))
                return;

            var tmpFont = "Times New Roman";
            var tmpFontSize = 14;
            FontStyle tmpFontStyle = FontStyle.Regular;

            while (lines[i] != "*")
            {
                if (lines[i] == "Position")
                    Position = GetRectFromLine(lines[++i]);

                if (lines[i] == "Size")
                    RectSize = GetSizeFromLine(lines[++i]);


                if (lines[i] == "Repeatability" || lines[i] == "Offset")
                {
                    if (CheckForNothing(lines[++i]))
                    {
                        OffsetX = 0;
                        OffsetY = 0;
                        continue;
                    }

                    var spl = lines[i].Split(' ');

                    OffsetX = Convert.ToInt32(spl[0]);
                    OffsetY = Convert.ToInt32(spl[1]);
                }

                if (lines[i] == "Font")
                {
                    if (!CheckForNothing(lines[++i]))
                        tmpFont = lines[i];
                }

                if (lines[i] == "Font size")
                {
                    if (!CheckForNothing(lines[++i]))
                        tmpFontSize = Convert.ToInt32(lines[i]);
                }

                if (lines[i] == "Font style")
                {
                    if (!CheckForNothing(lines[++i]))
                    {
                        if (lines[i].ToLower() == "regular")
                            tmpFontStyle = FontStyle.Regular;

                        if (lines[i].ToLower() == "bold")
                            tmpFontStyle = FontStyle.Bold;

                        if (lines[i].ToLower() == "italic")
                            tmpFontStyle = FontStyle.Italic;
                    }
                }

                if (lines[i] == "Color")
                {
                    if (!CheckForNothing(lines[++i]))
                    {
                        if (lines[i].Contains(","))
                        {
                            Color = GetColorFromLine(lines[i]);
                        }
                        else
                        {
                            if (lines[i].ToLower() == "white")
                                Color = Brushes.White;

                            if (lines[i].ToLower() == "black")
                                Color = Brushes.Black;

                            if (lines[i].ToLower() == "blue")
                                Color = Brushes.Blue;

                            if (lines[i].ToLower() == "red")
                                Color = Brushes.Red;
                        }
                    }
                }

                if (lines[i] == "Gradient")
                {
                    if (!CheckForNothing(lines[++i]))
                    {
                        IsGradient = true;

                        if (lines[i].Contains(","))
                        {
                            Gradient = GetGradientFromLine(lines[i]);
                        }
                    }
                }

                if (lines[i] == "Formatting")
                {
                    if (!CheckForNothing(lines[++i]))
                    {
                        if (lines[i].ToLower() == "center")
                            StrFormatting = format.centerFormat;

                        if (lines[i].ToLower() == "left")
                            StrFormatting = format.leftFormat;

                        if (lines[i].ToLower() == "right")
                            StrFormatting = format.rightFormat;
                    }
                }

                if (lines[i] == "Outline")
                {
                    if (!CheckForNothing(lines[++i]))
                    {
                        IsOutline = true;

                        if (lines[i].Contains(","))
                        {
                            var spl = lines[i].Split(',');

                            OutlineColor = System.Drawing.Color.FromArgb(Convert.ToInt32(spl[0]),
                                    Convert.ToInt32(spl[1]),
                                    Convert.ToInt32(spl[2])); 
                        }
                        else
                        {
                            if (lines[i].ToLower() == "white")
                                OutlineColor = System.Drawing.Color.White;

                            if (lines[i].ToLower() == "black")
                                OutlineColor = System.Drawing.Color.Black;

                            if (lines[i].ToLower() == "blue")
                                OutlineColor = System.Drawing.Color.Blue;

                            if (lines[i].ToLower() == "red")
                                OutlineColor = System.Drawing.Color.Red;
                        }
                    }
                }

                ++i;
            }

            if (IsFontFromFile(tmpFont))
            {
                coll.AddFontFile(tmpFont);
                Font = new Font(coll.Families[0], tmpFontSize, tmpFontStyle);
            }
            else
                Font = new Font(tmpFont, tmpFontSize, tmpFontStyle);
        }

        private LinearGradientBrush GetGradientFromLine(string s)
        {
            var spl = s.Split(',');

            var br = new LinearGradientBrush(
                new Point(0, Position.Y),
                new Point(0, Position.Y + Position.Height / 2),
                System.Drawing.Color.FromArgb(Convert.ToInt32(spl[0]),
                Convert.ToInt32(spl[1]),
                Convert.ToInt32(spl[2])),
                System.Drawing.Color.FromArgb(Convert.ToInt32(spl[3]),
                Convert.ToInt32(spl[4]),
                Convert.ToInt32(spl[5])));

            return br;
        }

        private Brush GetColorFromLine(string s)
        {
            var spl = s.Split(',');

            return new SolidBrush(System.Drawing.Color.FromArgb(Convert.ToInt32(spl[0]),
                Convert.ToInt32(spl[1]),
                Convert.ToInt32(spl[2])));
        }

        internal Size GetSizeFromLine(string s)
        {
            if (CheckForNothing(s))
                return new Size();

            var spl = s.Split(' ');
            return new Size(Convert.ToInt32(spl[0]),
                Convert.ToInt32(spl[1]));
        }

        private bool IsFontFromFile(string tmpFont)
        {
            return tmpFont.Contains(".") || tmpFont.Contains("/");
        }

        internal Rectangle GetRectFromLine(string s)
        {
            if (CheckForNothing(s))
                return new Rectangle();

            var spl = s.Split(',');
            return new Rectangle(Convert.ToInt32(spl[0]),
                Convert.ToInt32(spl[1]),
                Convert.ToInt32(spl[2]),
                Convert.ToInt32(spl[3]));
        }

        internal bool CheckForNothing(string s)
        {
            return s == "-";
        }
    }
}