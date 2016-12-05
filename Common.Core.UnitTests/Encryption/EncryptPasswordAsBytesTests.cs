using System;
using System.Security.Cryptography;
using System.Text;
using Common.Core.Encryption;
using NUnit.Framework;
using Randomizer;

namespace Common.Core.UnitTests.Encryption
{
    [TestFixture]
    public class EncryptPasswordAsBytesTests : UnitTestBase
    {
        // ReSharper disable once InconsistentNaming
        private IEncryptor encryptor;
        // ReSharper disable once InconsistentNaming
        private RandomAlphanumericStringGenerator randomizer;

        [SetUp]
        public override void SetUp()
        {
            encryptor = new Utf8Encryptor();
            randomizer = new RandomAlphanumericStringGenerator();
        }

        [Test]
        public void EncryptPasswordAsBytesShouldThrowExceptionWhenPasswordNull()
        {
            Assert.Throws<ArgumentNullException>(() => encryptor.EncryptPasswordAsBytes(null));
        }
        
        [Test]
        public void EncryptPasswordAsBytesShouldThrowExceptionWhenPasswordEmptyl()
        {
            Assert.Throws<ArgumentNullException>(() => encryptor.EncryptPasswordAsBytes(string.Empty));
        }


        [Test]
        public void EncryptPasswordAsBytesShouldReturnBytesWhenPasswordPassed()
        {
            byte[] encryptedPassword = encryptor.EncryptPasswordAsBytes(randomizer.GenerateValue(10));

            Assert.IsNotNull(encryptedPassword);
        }

        [Test]
        public void EncryptPasswordAsBytesShouldReturnCorrectPasswordBytes()
        {
            string password = randomizer.GenerateValue(25);
            byte[] testingResult = encryptor.EncryptPasswordAsBytes(password);

            byte[] encryptdPasswordBySha = null;
            using (SHA512 sha512 = new SHA512Managed())
            {
                var passwordBytesBeforEncryption = Encoding.UTF8.GetBytes(password);
                encryptdPasswordBySha = sha512.ComputeHash(passwordBytesBeforEncryption);
            }

            Assert.AreEqual(encryptdPasswordBySha,testingResult);
        }
    }
}
