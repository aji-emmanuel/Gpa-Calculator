using System;
namespace Week1Task
{
    class PrintTable
    {
        private const int TableWidth = 80;
        /*
        public static void PrintLines()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        public static void PrintHeadings(params string[] columns)
        {
            int Width = (TableWidth - columns.Length) / columns.Length;
            const string seed = "|";
            string row = col.Aggregate(seed, (seperator, colText) => seperator + GetCenterAllignedText(colText, Width) + seed);
            Console.WriteLine(row);

        }

        private static string GetCenterAllignedText(string colText, int width)
        {
            colText = colText.Length > width ? colText.Substring(0, width - 3) + "..." : colText;
            return string.IsNullOrEmpty(colText) ? new string(' ', width)
                : colText.PadRight(width - ((width - colText.Length) / 2)).PadLeft(width);
        }

        */

        public static void PrintLines()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        public static void PrintHeadings(params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }
            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

    }
}
