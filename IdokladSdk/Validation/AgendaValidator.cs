using IdokladSdk.Exceptions;
using IdokladSdk.Models.Account;

namespace IdokladSdk.Validation
{
    internal static class AgendaValidator
    {
        public static void ValidatePatch(AgendaPatchModel model)
        {
            if (model?.Contact != null)
            {
                var contact = model.Contact;
                ValidateIdentificationNumber(contact.IdentificationNumber, contact.HasNoIdentificationNumber);
            }
        }

        private static void ValidateIdentificationNumber(string identificationNumber, bool? hasNoIdentificationNumber)
        {
            if (identificationNumber != null && hasNoIdentificationNumber != null)
            {
                if (!string.IsNullOrEmpty(identificationNumber) && hasNoIdentificationNumber.Value)
                {
                    throw new IdokladSdkException(
                        "Cannot update IdentificationNumber if HasNoIdentificationNumber field is set to true");
                }

                if (string.IsNullOrEmpty(identificationNumber) && !hasNoIdentificationNumber.Value)
                {
                    throw new IdokladSdkException(
                        "IdentificationNumber is required if HasNoIdentificationNumber field is set to false");
                }
            }

            if ((identificationNumber != null && hasNoIdentificationNumber == null) ||
                (identificationNumber == null && hasNoIdentificationNumber != null))
            {
                throw new IdokladSdkException(
                    "Both or neither fields HasNoIdentificationNumber and IdentificationNumber must be filled");
            }
        }
    }
}
