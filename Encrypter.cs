using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Tratatui
{
    public static class Encrypter
    {
        const int saltSize = 8;
        public static string Encrypt(string input, byte[]? Salt)
        {
            if (Salt == null)
            {
                Salt = new byte[saltSize];
                RandomNumberGenerator gen = RandomNumberGenerator.Create();
                gen.GetNonZeroBytes(Salt);
            }

            byte[] ByteInput = Encoding.UTF8.GetBytes(input);
            byte[] ByteSaltedInput = new byte[ByteInput.Length + Salt.Length];
            for (int i = 0; i < ByteInput.Length; i++) ByteSaltedInput[i] = ByteInput[i];
            for (int i = 0; i < Salt.Length; i++) ByteSaltedInput[ByteInput.Length + i] = Salt[i];

            HashAlgorithm Algorithm = MD5.Create();
            byte[] Hash = Algorithm.ComputeHash(ByteSaltedInput);
            byte[] HashPlusSalt = new byte[Hash.Length + Salt.Length];
            for (int i = 0; i < Hash.Length; i++) HashPlusSalt[i] = Hash[i];
            for (int i = 0; i < Salt.Length; i++) HashPlusSalt[Hash.Length + i] = Salt[i];
            return Convert.ToBase64String(HashPlusSalt);
        }

        public static byte[] Extract(string SaltedHash)
        {
            byte[] hashWithSaltBytes = Convert.FromBase64String(SaltedHash);
            byte[] Salt = new byte[saltSize];
            for (int i = 1; i <= Salt.Length; i++) Salt[Salt.Length - i] = hashWithSaltBytes[hashWithSaltBytes.Length - i];
            return Salt;
        }
    }
}
