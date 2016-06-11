using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolist_windows_form
{
    class Encrypt
    {
        private static void GenerateKeyFromPassword(string password, int keysize,
            out byte[] key, int blocksize, out byte[] iv)
        {
            byte[] salt = System.Text.Encoding.UTF8.GetBytes("saltは1byte以上");
            System.Security.Cryptography.Rfc2898DeriveBytes deliverbyte =
                new System.Security.Cryptography.Rfc2898DeriveBytes(password, salt);
            deliverbyte.IterationCount = 1000;
            key = deliverbyte.GetBytes(keysize / 8);
            iv = deliverbyte.GetBytes(blocksize / 8);
        }
        public static string EncryptString(string sourcestring, string password)
        {
            System.Security.Cryptography.RijndaelManaged rijndael = 
                new System.Security.Cryptography.RijndaelManaged();
            byte[] key, iv;
            GenerateKeyFromPassword(password, rijndael.KeySize,
                out key, rijndael.BlockSize, out iv);
            rijndael.Key = key;
            rijndael.IV = iv;
            byte[] sourcebyte = System.Text.Encoding.UTF8.GetBytes(sourcestring);
            System.Security.Cryptography.ICryptoTransform encryptor =
                rijndael.CreateEncryptor();
            byte[] encbyte = 
                encryptor.TransformFinalBlock(sourcebyte, 0, sourcebyte.Length);
            encryptor.Dispose();

            return System.Convert.ToBase64String(encbyte);
        }
        public static string DecryptString(string sourcestring, string password)
        {
            System.Security.Cryptography.RijndaelManaged rijndael =
                new System.Security.Cryptography.RijndaelManaged();
            byte[] key, iv;
            GenerateKeyFromPassword(password, rijndael.KeySize,
                out key, rijndael.BlockSize, out iv);
            rijndael.Key = key;
            rijndael.IV = iv;

            if (String.IsNullOrEmpty(sourcestring))
            {
                return String.Empty;
            }
            else {
                byte[] sourcebyte = System.Convert.FromBase64String(sourcestring);
                System.Security.Cryptography.ICryptoTransform decryptor =
                    rijndael.CreateDecryptor();
                byte[] decbyte =
                    decryptor.TransformFinalBlock(sourcebyte, 0, sourcebyte.Length);
                decryptor.Dispose();

                return System.Text.Encoding.UTF8.GetString(decbyte);
            }
        }
    }
}