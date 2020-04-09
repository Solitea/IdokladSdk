using IdokladSdk.Validation.Attributes;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Validation
{
    [TestFixture]
    public class ColorAttributeTests
    {
        internal ColorAttribute ColorAttribute { get; set; }

        [SetUp]
        public void SetUp()
        {
            ColorAttribute = new ColorAttribute();
        }

        [TestCase("#000000")]
        [TestCase("#123456")]
        [TestCase("#abcdef")]
        [TestCase("#ABCDEF")]
        [TestCase("#a1B23C")]
        [TestCase("#ffFFff")]
        public void ColorValue_IsValid(string color)
        {
            // Assert
            Assert.True(ColorAttribute.IsValid(color));
        }

        [TestCase("blue")]
        [TestCase("#aabbccd")]
        [TestCase("#abc")]
        [TestCase("#123")]
        [TestCase("abcdef")]
        [TestCase("123456")]
        public void ColorValue_IsInvalid(string color)
        {
            // Assert
            Assert.False(ColorAttribute.IsValid(color));
        }
    }
}
