using System.Collections.Generic;
using System.Text;

namespace DigitizerMain.Libraries
{
    public interface IPrintableCharBuilder
    {
        (string row1, string row2, string row3) Build(
            string input);
    }
    public class PrintableCharBuilder : IPrintableCharBuilder
    {
        private readonly IDigitBuilder _digitBuilder;

        public PrintableCharBuilder(IDigitBuilder digitBuilder)
        {
            _digitBuilder = 
                digitBuilder;
        }

        public (string row1, string row2, string row3) Build(
            string  input)
        {

            List<Digit> digits
                = _digitBuilder
                    .Build(
                        input);

            return GeneratePrintables(
                digits);
        }

        private static (string row1, string row2, string row3) GeneratePrintables(
            List<Digit> digits)
        {
            var line1= 
                new StringBuilder();
            var line2= 
                new StringBuilder();
            var line3= 
                new StringBuilder();

            foreach (var digit in digits)
            {
                AppendLine1(
                    line1,
                    digit);

                AppendLine2(
                    line2,
                    digit);

                AppendLine3(
                    line3,
                    digit);
            }

            return (
                row1: line1.ToString(),
                row2: line2.ToString(),
                row3: line3.ToString());
        }

        private static void AppendLine1(
            StringBuilder line1, 
            Digit digit)
        {
            Append(line1,
                    digit
                        .Top
                            ? " _ "
                            : "   ");
        }

        private static void AppendLine3(
            StringBuilder line3, 
            Digit digit)
        {
            Append(line3,
                   digit
                        .BottomLeft
                            ? "|"
                            : " ");
            Append(line3,
                   digit
                        .Bottom
                             ? "_"
                             : " ");
            Append(line3,
                   digit
                      .BottomRight
                             ? "|"
                             : " ");
        }

        private static void AppendLine2(
            StringBuilder line2, 
            Digit digit)
        {
            Append(
                line2,
                digit
                    .TopLeft
                        ? "|"
                        : " ");

            Append(line2,
                     digit
                        .Middle
                             ? "_"
                             : " ");
            Append(
                line2,
                digit
                    .TopRight
                        ? "|"   
                        : " "); 
        }

        private static void Append(
                StringBuilder appendTo, 
                string toBeAppended)
        {
            appendTo
                .Append(
                    toBeAppended);

        }
    }
}
