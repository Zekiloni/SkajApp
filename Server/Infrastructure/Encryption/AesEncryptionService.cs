using Server.Infrastructure.Encryption.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Server.Infrastructure.Encryption
{
    public class AesEncryptionService : IEncryptionService
    {
        private readonly string _key;
        private readonly string _iv;

        public AesEncryptionService(string key, string iv)
        {
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(iv))
            {
                throw new ArgumentException("Key and IV must be provided.");
            }

            _key = key;
            _iv = iv;
        }

        public string Encrypt(string plainText)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_key);
                aesAlg.IV = Encoding.UTF8.GetBytes(_iv);

                using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                using (var msEncrypt = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(cryptoStream))
                    {
                        swEncrypt.Write(plainText);
                    }

                    byte[] encrypted = msEncrypt.ToArray();
                    return Convert.ToBase64String(encrypted);
                }
            }
        }

        public string Descrypt(string cipherText)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_key);
                aesAlg.IV = Encoding.UTF8.GetBytes(_iv);

                using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                using (var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                using (var cryptoStream = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new StreamReader(cryptoStream))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}
