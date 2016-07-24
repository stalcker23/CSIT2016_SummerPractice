﻿using System.Security.Cryptography;
using System.Text;

namespace AdBoard.Helpers
{
    public static class SecurityHelper
    {
        public static string Hash(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            var csp = new MD5CryptoServiceProvider();

            byte[] byteHash = csp.ComputeHash(bytes);

            string hash = string.Empty;

            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
    }
}