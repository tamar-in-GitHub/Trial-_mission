namespace BL.Utilities
{
    public static class HebrewKeyboardConverter
    {
        private static readonly Dictionary<char, char> EngToHebMap = new Dictionary<char, char>
        {
            { 'a', 'ש' }, { 'b', 'נ' }, { 'c', 'ב' }, { 'd', 'ג' }, { 'e', 'ק' },
            { 'f', 'כ' }, { 'g', 'ע' }, { 'h', 'י' }, { 'i', 'ן' }, { 'j', 'ח' },
            { 'k', 'ל' }, { 'l', 'ך' }, { 'm', 'צ' }, { 'n', 'מ' }, { 'o', 'ם' },
            { 'p', 'פ' }, { 'q', '/' }, { 'r', 'ר' }, { 's', 'ד' }, { 't', 'א' },
            { 'u', 'ו' }, { 'v', 'ה' }, { 'w', '\'' }, { 'x', 'ס' }, { 'y', 'ט' },
            { 'z', 'ז' }
        };

        public static string ConvertEngToHeb(string input)
        {
            char[] converted = input.Select(c => EngToHebMap.ContainsKey(c) ? EngToHebMap[c] : c).ToArray();
            return new string(converted);
        }
    }
}