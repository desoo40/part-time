namespace ImGen
{
    public class TextHelper
    {
        public string FullNameFinder(string s)
        {
            var inStr = s.ToLower();

            if (inStr == "рэу" || inStr == "плешка")
                return "РЭУ\nим. Плеханова";

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
    }
}