using System;
using System.Text;

namespace MoviePrediction.Convertors
{
    public class ColorGenerator
    {
        public string GenerateColor(Random random)
        {
            var numbers = "0123456789";
            var chars = "abcdef";

            var color = new StringBuilder("#");

            for (var i = 1; i <= 6; i++)
            {
                var boolean = random.Next(0, 2);

                if (boolean == 0)
                {
                    color.Append(numbers[random.Next(0, numbers.Length)]);
                    continue;
                }

                color.Append(chars[random.Next(0, chars.Length)]);
            }
            return color.ToString();
        }
    }
}
