using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Encryption
{
    public interface IEncryptor: IDisposable
    {
        string EncryptPasswordAsText(string passwordBeforeEncryption);

        byte[] EncryptPasswordAsBytes(string passwordBeforeEncryption);
    }
}
