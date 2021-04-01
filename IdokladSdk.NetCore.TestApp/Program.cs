using System;
using System.IO;
using System.Threading.Tasks;
using IdokladSdk.Authentication;
using IdokladSdk.Enums;
using IdokladSdk.NetCore.TestApp.Examples;
using Microsoft.Extensions.Configuration;

namespace IdokladSdk.NetCore.TestApp
{
    internal class Program
    {
        private static string _clientId;
        private static string _clientSecret;

        private static DokladApi _api;

        private static int _partner1Id;
        private static int _partner2Id;
        private static int _issuedInvoiceId;
        private static int _proformaInvoice1Id;
        private static int _accountingInvoice1Id;
        private static int _proformaInvoice2Id;
        private static int _accountingInvoice2Id;
        private static int _priceListItemId;

        internal static async Task Main()
        {
            try
            {
                LoadConfiguration();
                _api = GetIdokladApi();
                SyncFlow();
                await AsyncFlow();
                CleanUp();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private static DokladApi GetIdokladApi()
        {
            var auth = new ClientCredentialsAuthentication(_clientId, _clientSecret);
            var context = new ApiContext("Test", "1.0", auth);
            var api = new DokladApi(context);
            return api;
        }

        private static async Task AsyncFlow()
        {
            var batchExample = new BatchExamples(_api);
            await batchExample.SetExportedStateAsync(_issuedInvoiceId, _partner1Id, ExportedState.Exported);
            await batchExample.SetExportedStateAsync(_issuedInvoiceId, _partner1Id, ExportedState.NotExported);
        }

        private static void SyncFlow()
        {
            var contacts = new ContactExamples(_api);
            _partner1Id = contacts.CreateContact_ResponseChecking();
            _partner2Id = contacts.CreateContact_ExceptionHandling();
            contacts.UpdateContact(_partner1Id, "Jan", "Novák");

            var select = new SelectExamples(_api);
            select.List_DefaultGetMethod_ReturnsDefaultModel();
            select.List_GetWithGenericType_ReturnsCustomModel();
            select.List_GetWithLambda_SpecificType();
            select.List_FilteringSortingPaging();
            select.List_Filtering_Obsolete();
            select.Detail_DefaultGetMethod_ReturnsDefaultModel(_partner1Id);
            select.Detail_GetWithGenericType_ReturnsCustomModel(_partner1Id);
            select.Detail_WithLambda_ReturningAnonymousType(_partner1Id);

            var invoices = new IssuedInvoiceExamples(_api);
            _priceListItemId = invoices.CreatePriceListItem();
            _issuedInvoiceId = invoices.CreateNewInvoice(_partner1Id);
            (_proformaInvoice1Id, _accountingInvoice1Id) = invoices.AccountProforma_WithIssuedInvoiceDetail(_partner2Id, _priceListItemId);
            (_proformaInvoice2Id, _accountingInvoice2Id) = invoices.AccountProforma_WithoutIssuedInvoiceDetail(_partner2Id);
            invoices.UpdateInvoice_AddItemFromPriceList(_issuedInvoiceId, _priceListItemId);
            invoices.UpdateInvoice_NullableProperties(_issuedInvoiceId);

            var validation = new ValidationExamples(_api);
            validation.ValidateOnClient();
        }

        /// <summary>
        /// Reads authorization data.
        /// </summary>
        /// <remarks>
        /// Create your own localsettings.json file in application directory. File content should be as follows:
        /// {
        ///    "ClientId": "7048b683-520c-43c9-b466-792a8a3b47ed",
        ///    "ClientSecret": "1357dee5-439c-4074-a701-172129401ec3"
        /// }
        /// ClientId and ClientSecret have to be valid API keys (from User setting in iDoklad).
        /// </remarks>
        private static void LoadConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("localsettings.json")
                .Build();

            _clientId = configuration.GetValue<string>("ClientId");
            _clientSecret = configuration.GetValue<string>("ClientSecret");
        }

        private static void CleanUp()
        {
            _api.IssuedInvoiceClient.Delete(_issuedInvoiceId);
            _api.IssuedInvoiceClient.Delete(_accountingInvoice1Id);
            _api.IssuedInvoiceClient.Delete(_accountingInvoice2Id);
            _api.ProformaInvoiceClient.Delete(_proformaInvoice1Id);
            _api.ProformaInvoiceClient.Delete(_proformaInvoice2Id);
            _api.ContactClient.Delete(_partner1Id);
            _api.ContactClient.Delete(_partner2Id);
            _api.PriceListItemClient.Delete(_priceListItemId);
        }
    }
}
