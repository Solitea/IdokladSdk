using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using IdokladSdk.Builders;
using IdokladSdk.Enums;
using IdokladSdk.NetCore.TestApp.Examples;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdokladSdk.NetCore.TestApp
{
    internal class Program
    {
        private static string _clientId;
        private static string _clientSecret;

        private static DokladApi _api;
        private static ServiceProvider _serviceProvider;

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
                InitializeServiceProvider();
                LoadConfiguration();
                SetIdokladApi();

                await AsyncComplexFlow();
                await AsyncFlow();

                await CleanUpAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private static void InitializeServiceProvider()
        {
            _serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
        }

        private static void SetIdokladApi()
        {
            var httpClientFactory = _serviceProvider.GetService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient("IdokladApi");

            _api = new DokladApiBuilder("Test", "1.0")
                .AddClientCredentialsAuthentication(_clientId, _clientSecret)
                .AddHttpClient(httpClient)
                .Build();
        }

        private static async Task AsyncFlow()
        {
            var batchExample = new BatchExamples(_api);
            await batchExample.SetExportedStateAsync(_issuedInvoiceId, _partner1Id, ExportedState.Exported);
            await batchExample.SetExportedStateAsync(_issuedInvoiceId, _partner1Id, ExportedState.NotExported);
        }

        private static async Task AsyncComplexFlow()
        {
            var contacts = new ContactExamples(_api);
            _partner1Id = await contacts.CreateContact_ResponseCheckingAsync();
            _partner2Id = await contacts.CreateContact_ExceptionHandlingAsync();
            await contacts.UpdateContactAsync(_partner1Id, "Jan", "Novák");

            var select = new SelectExamples(_api);
            await select.List_DefaultGetMethod_ReturnsDefaultModelAsync();
            await select.List_GetWithGenericType_ReturnsCustomModelAsync();
            await select.List_GetWithLambda_SpecificTypeAsync();
            await select.List_FilteringSortingPagingAsync();
            await select.Detail_DefaultGetMethod_ReturnsDefaultModelAsync(_partner1Id);
            await select.Detail_GetWithGenericType_ReturnsCustomModelAsync(_partner1Id);
            await select.Detail_WithLambda_ReturningAnonymousTypeAsync(_partner1Id);

            var invoices = new IssuedInvoiceExamples(_api);
            _priceListItemId = await invoices.CreatePriceListItemAsync();
            _issuedInvoiceId = await invoices.CreateNewInvoiceAsync(_partner1Id);
            (_proformaInvoice1Id, _accountingInvoice1Id) = await invoices.AccountProforma_WithIssuedInvoiceDetailAsync(_partner2Id, _priceListItemId);
            (_proformaInvoice2Id, _accountingInvoice2Id) = await invoices.AccountProforma_WithoutIssuedInvoiceDetailAsync(_partner2Id);
            await invoices.UpdateInvoice_AddItemFromPriceListAsync(_issuedInvoiceId, _priceListItemId);
            await invoices.UpdateInvoice_NullablePropertiesAsync(_issuedInvoiceId);

            var validation = new ValidationExamples(_api);
            await validation.ValidateOnClientAsync();
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

        private static async Task CleanUpAsync()
        {
            await _api.IssuedInvoiceClient.DeleteAsync(_issuedInvoiceId);
            await _api.IssuedInvoiceClient.DeleteAsync(_accountingInvoice1Id);
            await _api.IssuedInvoiceClient.DeleteAsync(_accountingInvoice2Id);
            await _api.ProformaInvoiceClient.DeleteAsync(_proformaInvoice1Id);
            await _api.ProformaInvoiceClient.DeleteAsync(_proformaInvoice2Id);
            await _api.ContactClient.DeleteAsync(_partner1Id);
            await _api.ContactClient.DeleteAsync(_partner2Id);
            await _api.PriceListItemClient.DeleteAsync(_priceListItemId);
        }
    }
}
