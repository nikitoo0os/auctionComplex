
namespace auctionComplex.Utilities
{
    internal class FilterUtils
    {
        private static readonly char[] digits = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        public static bool IsDigits(string filter)
        {
            int temp = 0;

            for (int i = 0; i < filter.Length; i++)
                for (int j = 0; j < digits.Length; j++)
                    if (filter[i] == digits[j]) temp++;

            if (filter.Length == temp) return true;
            return false;
        }

        public static bool IsSymbols(string filter)
        {
            int temp = 0;

            for (int i = 0; i < filter.Length; i++)
                for (int j = 0; j < digits.Length; j++)
                    if (filter[i] == digits[j]) temp++;

            if (temp == 0) return true;
            return false;
        }
    }
}
