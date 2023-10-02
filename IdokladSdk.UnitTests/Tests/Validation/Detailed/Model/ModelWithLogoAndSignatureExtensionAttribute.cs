using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.UnitTests.Tests.Validation.Detailed.Model
{
    public class ModelWithLogoAndSignatureExtensionAttribute
    {
        [LogoAndSignatureExtension]
        public string FileName { get; set; }
    }
}
