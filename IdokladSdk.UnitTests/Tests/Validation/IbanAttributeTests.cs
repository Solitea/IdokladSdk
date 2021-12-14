using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation
{
    [TestFixture]
    public class IbanAttributeTests
    {
        internal IbanAttribute IbanAttribute { get; set; }

        [SetUp]
        public void SetUp()
        {
            IbanAttribute = new IbanAttribute("error");
        }

        [TestCase("SK3002000000003604642112")]
        [TestCase("")]
        [TestCase(null)]
        public void IbanValue_IsValid(string value)
        {
            // Assert
            Assert.True(IbanAttribute.IsValid(value));
        }

        [TestCase("invalidValue")]
        public void IbanValue_IsInvalid(string value)
        {
            // Assert
            Assert.False(IbanAttribute.IsValid(value));
        }
    }
}
