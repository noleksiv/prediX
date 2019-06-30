using System;
using System.Text;

namespace MoviePrediction.Expansions
{
    public class ColorGenerator
    {
        public string GenerateColor(Random random)
        {
            var numbers = HexHTML.Numbers;
            var chars = HexHTML.Chars;

            var color = new StringBuilder("#");

            for (var i = 1; i <= 6; i++)
            {
                var boolean = random.Next(0, 2);

                if (boolean == 0)
                {
                    color.Append(numbers[random.Next(0, numbers.Length)]);
                    continue;
                }

                var getChar = chars[random.Next(0, chars.Length)];
                color.Append(getChar);
            }
            return color.ToString();
        }
    }

    public static class HexHTML
    {
        public const string Numbers = "0123456789";
        public const string Chars = "abcdef";
    }
}
