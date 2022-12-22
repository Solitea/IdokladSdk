using System;
using System.Threading.Tasks;
using IdokladSdk.NetCore.TestApp.Examples.Providers;

namespace IdokladSdk.NetCore.TestApp.Examples
{
    public class ValidationExamples
    {
        private readonly DokladApi _api;

        public ValidationExamples(DokladApi api)
        {
            _api = api;
        }

        public async Task ValidateOnClientAsync()
        {
            // Get default model containing default values based on agenda settings.
            var invoice = (await _api.IssuedInvoiceClient.DefaultAsync()).Data;

            // Modify properties to get validation errors.
            invoice.VariableSymbol = "12345678901234567890";

            // Validate model on client side (based on validation attributes) without sending data to server.
            var validationResult = invoice.Validate();

            if (!validationResult.IsValid)
            {
                Console.WriteLine("There are validation errors:");
                // Create instance of custom validation message provider to get custom localized validation messages.
                var validationMessageProvider = new CustomValidationMessageProvider();

                foreach (var propertyValidationResult in validationResult.InvalidProperties.Values)
                {
                    var validationMessages = validationMessageProvider.GetValidationMessages(propertyValidationResult);
                    Console.WriteLine($"{propertyValidationResult.Name} {propertyValidationResult.ValidationContext.DisplayName}:");

                    foreach (var validationMessage in validationMessages)
                    {
                        Console.WriteLine("   " + validationMessage);
                    }
                }
            }
        }
    }
}
