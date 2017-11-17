namespace ImGen
{
    public class TextHelper
    {
        public string FullNameFinder(string s)
        {
            var inStr = s.ToLower();

            if (inStr == "рэу" || inStr == "плешка")
                return "ХК РЭУ им. Плеханова";

            if (inStr == "миэт" || inStr == "зеленоград")
                return "ХК \"Электроник\" МИЭТ";

            if (inStr == "мгту" || inStr == "бауманка")
                return "ХК МГТУ им. Баумана";

            if (inStr == "тгу" || inStr == "держава")
                return "ХК \"Держава\" ТГУ";

            if (inStr == "ргуфксит" || inStr == "гцолифк" || inStr == "ргуфк")
                return "ХК \"Гладиаторы\" ГЦОЛИФК";

            if (inStr == "тверичи")
                return "МХК \"Тверичи\"";

            if (inStr == "капитан")
                return "МХК \"Капитан\"";

            if (inStr == "юургу")
                return "ХК \"Политехник\" ЮУрГУ";

            if (inStr == "мсха")
                return "ХК \"Тимирязевские зубры\" МСХА";

            if (inStr == "ранхигс")
                return "ХК \"Сенатор\" РАНХиГС";

            if (inStr == "umb")
                return "UMB (Словакия)";

            if (inStr == "ukpraha")
                return "UK PRAHA (Чехия)";

            if (inStr == "миит")
                return "ХК \"Дизель\" МИИТ";

            if (inStr == "мисис")
                return "ХК \"Стальные медведи\" МИСиС";

            return s;
        }

        public string[] FindNamedBy(string s)
        {
            if (s.ToLower() == "маи1" || s.ToLower() == "маи3")
                s = "МАИ";

            if (s.ToLower() == "маи2")
                return new[] { "МАИ", "2010" };

            if (s.ToLower() == "мсха")
                s = "РГАУ-МСХА";

            if (s.ToLower() == "миит")
                s = "РУТ(МИИТ)";

            if (s.ToLower() == "миит")
                s = "РУТ(МИИТ)";

            if (s.ToLower() == "ву")
                s = "ВУ МО РФ";

            if (s.ToLower() == "ранхигс")
                return new[] { "РАНХиГС", "" };

            if (s.ToLower() == "ргуфксмит")
                return new[] { "РГУФКСМиТ", "" };

            if (s.ToLower() == "мисис")
                return new[] { "МИСиС", "" };

            if (s.ToLower() == "рниму")
                return new[] {s.ToUpper(), "ИМ. ПИРОГОВА" };

            if (s.ToLower() == "мгту")
                return new[] { s.ToUpper(), "ИМ. БАУМАНА" };

            if (s.ToLower() == "рэу")
                return new[] { s.ToUpper(), "ИМ. ПЛЕХАНОВА" };

            if (s.ToLower() == "пмгму")
                return new[] { s.ToUpper(), "ИМ. СЕЧЕНОВА" };

            if (s.ToLower() == "ргунг")
                return new[] { s.ToUpper(), "ИМ. ГУБКИНА" };

            if (s.ToLower() == "мгу")
                return new[] { s.ToUpper(), "ИМ. ЛОМОНОСОВА" };

            if (s.ToLower() == "тгу")
                return new[] { s.ToUpper(), "ИМ. ДЕРЖАВИНА" };

            return new[] {s.ToUpper(), ""};
        }
    }
}