namespace Server.Infrastructure.Encryption.Interfaces
{
    public interface IEncryptionService
    {
        string Encrypt(string plainText);
        string Descrypt(string cipherText);
    }
}