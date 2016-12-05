using System;
using System.Security.Cryptography;
using System.Text;
using Common.Core.Encryption;
using NUnit.Framework;
using Randomizer;

namespace Common.Core.UnitTests.Encryption
{
    [TestFixture]
    public class EncryptPasswordAsTextTests : UnitTestBase
    {
        // ReSharper disable once InconsistentNaming
        private IEncryptor encryptor;
        // ReSharper disable once InconsistentNaming
        private RandomAlphanumericStringGenerator randomStringGenerator;
        
        [SetUp]
        public override void SetUp()
        {
            encryptor = new Utf8Encryptor();
            randomStringGenerator = new RandomAlphanumericStringGenerator(); 
        }

        [Test]
        public void EncryptPasswordAsTextShouldThrowExceptionWhenPasswordIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => encryptor.EncryptPasswordAsText(null));
        }

        [Test]
        public void EncryptPasswordAsTextShouldThrowExceptionWhenPasswordIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => encryptor.EncryptPasswordAsText(string.Empty));
        }

        [Test]
        public void EncryptPasswordAsTextShouldReturnedNotNullValue()
        {
            string randomPassword = randomStringGenerator.GenerateValue(10);

            var returnedValue = encryptor.EncryptPasswordAsText(randomPassword);

            Assert.IsNotNull(returnedValue);
        }
        
        [Test]
        public void EncryptPasswordAsTextShouldReturnProperPassword()
        {
            string randomPassword = randomStringGenerator.GenerateValue(25);
            string encryptedPassword;

            var returnedValue = encryptor.EncryptPasswordAsText(randomPassword);

            using (SHA512 shaGenerator = new SHA512Managed())
            {
                byte[] passwordAsBytes = shaGenerator.ComputeHash(Encoding.UTF8.GetBytes(randomPassword));
                encryptedPassword = Encoding.UTF8.GetString(passwordAsBytes);
            }

            Assert.AreEqual(returnedValue,encryptedPassword);
        }
    }
}
