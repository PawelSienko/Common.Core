using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Common.Core.UnitTests
{
    public abstract class UnitTestBase
    {
        [SetUp]
        public abstract void SetUp();
    }
}
