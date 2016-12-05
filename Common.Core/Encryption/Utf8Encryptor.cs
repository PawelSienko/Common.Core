using System;
using System.Security.Cryptography;
using System.Text;
using Common.Core.Validation;

namespace Common.Core.Encryption
{
    public class Utf8Encryptor : IEncryptor
    {
        // ReSharper disable once InconsistentNaming
        private readonly SHA512 sha512;

        public Utf8Encryptor()
        {
            sha512 = new SHA512Managed();    
        }
        public string EncryptPasswordAsText(string passwordBeforeEncryption)
        {
            Validator.ValidateNullOrEmpty(passwordBeforeEncryption);

            var passwordBytesAfterEncryption = EncryptPasswordToByteArray(passwordBeforeEncryption);
            
            return Encoding.UTF8.GetString(passwordBytesAfterEncryption);
        }

        public byte[] EncryptPasswordAsBytes(string passwordBeforeEncryption)
        {
            Validator.ValidateNullOrEmpty(passwordBeforeEncryption);
            return EncryptPasswordToByteArray(passwordBeforeEncryption);
        }

        private byte[] EncryptPasswordToByteArray(string passwordBeforeEncryption)
        {
            byte[] passwordBytesAfterEncryption;

            using (sha512)
            {
                var passwordBytesBeforeEncryption = Encoding.UTF8.GetBytes(passwordBeforeEncryption);
                passwordBytesAfterEncryption = sha512.ComputeHash(passwordBytesBeforeEncryption);
            }

            return passwordBytesAfterEncryption;
        }

        public void Dispose()
        {
            this.sha512.Dispose();
        }
    }
}
