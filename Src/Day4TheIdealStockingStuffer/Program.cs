using System;
using System.Security.Cryptography;
using System.Text;

namespace Day4TheIdealStockingStuffer
{
    class Program
    {
        static void Main(string[] args)
        {
            string secret = "iwrupvqb";
            string startsWithFiveZeroes = "00000";
            int nonceForFiveZeroes = GetNonce(secret, startsWithFiveZeroes);
            Console.WriteLine($"For MD5 hash which in hexadecimal start with '00000' lowest nonce is {nonceForFiveZeroes}");

            string startsWithSixZeroes = "000000";
            int nonceForSixZeroes = GetNonce(secret, startsWithSixZeroes);
            Console.WriteLine($"For MD5 hash which in hexadecimal start with '000000' lowest nonce is {nonceForSixZeroes}");
        }

        private static int GetNonce(string secret, string startsWith)
        {
            int nonce = 0;
            while (true)
            {
                string hexadecimalMD5Hash = GetHexadecimalMD5Hash(secret + nonce);
                if (hexadecimalMD5Hash.StartsWith(startsWith))
                    break;

                nonce += 1;
            }

            return nonce;
        }

        private static string GetHexadecimalMD5Hash(string value)
        {
            using MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
