using System;
using System.Globalization;
using System.Threading.Tasks;
using IdokladSdk.NetCore.TestApp.Examples.Models;

namespace IdokladSdk.NetCore.TestApp.Examples
{
    /// <summary>
    /// Select usage examples.
    /// </summary>
    public class SelectExamples
    {
        private readonly DokladApi _api;

        public SelectExamples(DokladApi api)
        {
            _api = api;
        }

        public async Task List_FilteringSortingPagingAsync()
        {
            // When retrieving list of entities, we can specify filter which applies inside iDoklad and reduces amount of data transferred.
            // Expression used in Filter method allows usage only of those properties which can be filtered on server-side, it depends on
            // entity type. The same applies to properties used in Sort method.
            // Expressions can contain multiple expressions joined by arbitrary combination of && or || operators. Use parentheses to specify
            // precedence.
            var list = await _api.ContactClient
                .List()
                .Filter(c => c.DateLastChange.IsLowerThan(DateTime.UtcNow) && (c.CompanyName.Contains("a.s.") || c.CompanyName.Contains("s.r.o.")))
                .Sort(c => c.Id.Asc())
                .PageSize(100)
                .Page(1)
                .GetAsync();
        }

        public async Task List_DefaultGetMethod_ReturnsDefaultModelAsync()
        {
            // Get with Default model return whole entity
            var list = await _api.ContactClient
                .List()
                .GetAsync();
        }

        public async Task List_GetWithGenericType_ReturnsCustomModelAsync()
        {
            // Get with custom model uses projection to the result.
            // Less data is transferred between client and server - only properties of custom model (which has to have the same property names).
            var list = await _api.ContactClient
                .List()
                .GetAsync<ContactGridModel>();
        }

        public async Task List_GetWithLambda_SpecificTypeAsync()
        {
            // Get with selector function calls that function to data returned from API.
            // Less data is transferred between client and server - only properties used in expression.
            var list = await _api.ContactClient
                .List()
                .GetAsync(c => new CustomContactModel
                {
                    CompanyName = c.CompanyName.ToUpper(CultureInfo.InvariantCulture),
                    Name = c.Firstname + " " + c.Surname,
                    Address = $"{c.Street} {c.City} {c.PostalCode}",
                    Discount = c.CompanyName.Length > 10 ? 10.0m : c.DiscountPercentage
                });
        }

        public async Task Detail_DefaultGetMethod_ReturnsDefaultModelAsync(int contactId)
        {
            // Get with default model return whole entity
            var detail = await _api.ContactClient
                .Detail(contactId)
                .Include(expand => expand.Country.Currency)
                .GetAsync();
        }

        public async Task Detail_GetWithGenericType_ReturnsCustomModelAsync(int contactId)
        {
            // Get with custom model uses projection to the result.
            // Less data is transferred between client and server - only properties of custom model (which has to have the same property names).
            var detail = await _api.ContactClient
                .Detail(contactId)
                .Include(expand => expand.Country.Currency)
                .GetAsync<ContactGridModel>();
        }

        public async Task Detail_WithLambda_ReturningAnonymousTypeAsync(int contactId)
        {
            // Get with selector function calls that function to data returned from API.
            // Less data is transferred between client and server - only properties used in expression.
            // Following selector expression uses properties of nested objects - these objects have to be included by using Include method.
            var detail = await _api.ContactClient
                .Detail(contactId)
                .Include(c => c.Bank, c => c.Country.Currency)
                .GetAsync(c => new
                {
                    CompanyName = c.CompanyName.ToUpper(CultureInfo.InvariantCulture),
                    Currency = c.Country != null && c.Country.Currency != null ? c.Country.Currency.Name : string.Empty,
                    Bank = c.Bank != null ? c.Bank.Name : string.Empty,
                    Name = c.Firstname + " " + c.Surname,
                    Address = $"{c.Street} {c.City} {c.PostalCode}",
                    Discount = c.CompanyName.Length > 10 ? 10.0m : c.DiscountPercentage
                });
        }
    }
}
