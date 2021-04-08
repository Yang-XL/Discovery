using System;
using System.Text;

namespace ZooProxy
{
    public static class DigestHelper
    {
        public static string GetDigest(string userName, string plainPassword)
        {
            var bytes = Encoding.UTF8.GetBytes($"{userName}:{plainPassword}");
            var sha1Algo = System.Security.Cryptography.SHA1.Create();
            var sha1 = sha1Algo.ComputeHash(bytes);
            var base64 = Convert.ToBase64String(sha1);
            return $"{userName}:{base64}";
        }
    }
}
