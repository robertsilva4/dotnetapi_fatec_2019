using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Infrastucture.Hash
{
    public static class HashMD5
    {
        public static string GetHash(string Source)
        {
            using (System.Security.Cryptography.MD5 Md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] InputBytes = Encoding.ASCII.GetBytes(Source);
                byte[] HashBytes = Md5.ComputeHash(InputBytes);
                return String.Join("", HashBytes.ToList().Select(Hb => Hb.ToString("X2")));
            }
        }
    }
}
