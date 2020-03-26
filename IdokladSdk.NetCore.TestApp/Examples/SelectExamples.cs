using System;
using System.Globalization;
using IdokladSdk.NetCore.TestApp.Examples.Models;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

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

        public void List_FilteringSortingPaging()
        {
            // When retrieving list of entities, we can specify filter which applies inside iDoklad and reduces amount of data transferred.
            // Expression used in Filter method allows usage only of those properties which can be filtered on server-side, it depends on
            // entity type. The same applies to properties used in Sort method.
            var list = _api.ContactClient
                .List()
                .Filter(c => c.CompanyName.Contains("company"))
                .Filter(c => c.DateLastChange.IsGreaterThan(DateTime.UtcNow.AddMinutes(-10)))
                .FilterType(FilterType.And)
                .Sort(c => c.Id.Asc())
                .PageSize(100)
                .Page(1)
                .Get();
        }

        public void List_DefaultGetMethod_ReturnsDefaultModel()
        {
            // Get with Default model return whole entity
            var list = _api.ContactClient
                .List()
                .Get();
        }

        public void List_GetWithGenericType_ReturnsCustomModel()
        {
            // Get with custom model uses projection to the result.
            // Less data is transferred between client and server - only properties of custom model (which has to have the same property names).
            var list = _api.ContactClient
                .List()
                .Get<ContactGridModel>();
        }

        public void List_GetWithLambda_SpecificType()
        {
            // Get with selector function calls that function to data returned from API.
            // Less data is transferred between client and server - only properties used in expression.
            var list = _api.ContactClient
                .List()
                .Get(c => new CustomContactModel
                {
                    CompanyName = c.CompanyName.ToUpper(CultureInfo.InvariantCulture),
                    Name = c.Firstname + " " + c.Surname,
                    Address = $"{c.Street} {c.City} {c.PostalCode}",
                    Discount = c.CompanyName.Length > 10 ? 10.0m : c.DiscountPercentage
                });
        }

        public void Detail_DefaultGetMethod_ReturnsDefaultModel(int contactId)
        {
            // Get with default model return whole entity
            var detail = _api.ContactClient
                .Detail(contactId)
                .Include(expand => expand.Country.Currency)
                .Get();
        }

        public void Detail_GetWithGenericType_ReturnsCustomModel(int contactId)
        {
            // Get with custom model uses projection to the result.
            // Less data is transferred between client and server - only properties of custom model (which has to have the same property names).
            var detail = _api.ContactClient
                .Detail(contactId)
                .Include(expand => expand.Country.Currency)
                .Get<ContactGridModel>();
        }

        public void Detail_WithLambda_ReturningAnonymousType(int contactId)
        {
            // Get with selector function calls that function to data returned from API.
            // Less data is transferred between client and server - only properties used in expression.
            // Following selector expression uses properties of nested objects - these objects have to be included by using Include method.
            var detail = _api.ContactClient
                .Detail(contactId)
                .Include(c => c.Bank, c => c.Country.Currency)
                .Get(c => new
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
