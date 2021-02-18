using System.Security.Cryptography;
using System.Text;

namespace IRT.Api.Util
{
    public class HashPassword
    {
        public string CalculateMD5Hash(string input)
        {
            // calculate o Hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Convert byte array for string hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
