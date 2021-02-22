using System.Security.Cryptography;
using System.Text;

namespace IRT.Domain.Extensions
{
    public static class StringExtension
    {
        public static string ToHashMD5(this string value)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));
            return sb.ToString();
        }
    }
}
