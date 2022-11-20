using System.Text;

namespace Fiinancial.Api.Service.Utils
{
    public static class StringExtensions
    {
        public static string ToSha512(this string input)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);

                using (var hash = System.Security.Cryptography.SHA512.Create())
                {
                    byte[] hashedInputBytes = hash.ComputeHash(bytes);
                    StringBuilder hashedInputStringBuilder = new StringBuilder(128);

                    foreach (Byte b in hashedInputBytes)
                    {
                        hashedInputStringBuilder.Append(b.ToString("X2"));
                    }

                    return hashedInputStringBuilder.ToString().ToLower();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
