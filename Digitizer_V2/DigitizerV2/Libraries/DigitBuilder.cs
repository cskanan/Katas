using System.Collections.Generic;

namespace DigitizerMain.Libraries
{
    public interface IDigitBuilder
    {
        List<Digit> Build(string v);
    }

    public class DigitBuilder : IDigitBuilder
    {
        public List<Digit> Build(string numbers)
        {
            List<Digit> digits = new List<Digit>();

            foreach (char firstDigit in numbers)
            {
                digits.Add(ConvertToDigitalDigit(int.Parse(firstDigit.ToString())));
            }

            return digits;
        }

        private static Digit ConvertToDigitalDigit(int number)
        {
            switch (number)
            {
                case 0:
                    return new Digit
                    {
                        Middle = false
                    };

                case 1:
                    return new Digit
                    {
                        Top = false,
                        Middle = false,
                        Bottom = false,
                        TopLeft = false,
                        BottomLeft = false
                    };

                case 2:
                    return new Digit
                    {
                        TopLeft = false,
                        BottomRight = false
                    };

                case 3:
                    return new Digit
                    {
                        TopLeft = false,
                        BottomLeft = false
                    };

                case 4:
                    return new Digit
                    {
                        Top = false,
                        BottomLeft = false,
                        Bottom = false
                    };

                case 5:
                    return new Digit
                    {
                        TopRight = false,
                        BottomLeft = false
                    };

                case 6:
                    return new Digit
                    {
                        Top = false,
                        TopRight = false
                    };

                case 7:
                    return new Digit
                    {
                        TopLeft = false,
                        BottomLeft = false,
                        Middle = false,
                        Bottom = false

                    };

                case 8:
                    return new Digit();

                case 9:
                    return new Digit
                    {
                        BottomLeft = false,
                        Bottom = false
                    };

                default:
                    return null;

            }

        }
    }
}
