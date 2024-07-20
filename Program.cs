using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                string secretKey = "yzbqklnj";
                string leadingToLookFor = "00000";

                int i = 1;

                while(true) {
                    string hash = GetMD5Hash($"{secretKey}{i}");
                    
                    if (hash.StartsWith(leadingToLookFor)) {
                        Console.WriteLine($"Number = {i}, MD5 hash = {hash}");
                        break;
                    } else {
                        i += 1;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static string GetMD5Hash(string source)
        {
            byte[] data= MD5.HashData(Encoding.UTF8.GetBytes(source));
            var hash = new StringBuilder();

            foreach (var item in data)
            {
                hash.Append(item.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}