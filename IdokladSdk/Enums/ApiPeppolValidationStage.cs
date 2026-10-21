namespace IdokladSdk.Enums
{
    /// <summary>
    /// Stage at which Peppol attachment validation failed.
    /// </summary>
    public enum ApiPeppolValidationStage
    {
        /// <summary>Unknown stage.</summary>
        Unknown = 0,

        /// <summary>Schematron validation.</summary>
        Schematron = 1,

        /// <summary>XSD validation.</summary>
        Xsd = 2,

        /// <summary>XML validation.</summary>
        Xml = 3
    }
}
