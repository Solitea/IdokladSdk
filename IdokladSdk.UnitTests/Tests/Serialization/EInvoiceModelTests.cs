using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;
using IdokladSdk.Requests.CreditNote.Filter;
using IdokladSdk.Requests.IssuedInvoice.Filter;
using IdokladSdk.Requests.IssuedTaxDocument.Filter;
using IdokladSdk.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Serialization
{
    /// <summary>
    /// Tests for electronic invoice model serialization and filters.
    /// </summary>
    [TestFixture]
    public class EInvoiceModelTests
    {
        [Test]
        public void IssuedInvoicePatch_OnlySendsIsEInvoiceWhenSpecified()
        {
            var model = new IssuedInvoicePatchModel { Id = 42 };
            var unset = JObject.Parse(JsonConvert.SerializeObject(model, new PatchRequestJsonSerializerSettings()));
            Assert.That(unset.Property("IsEInvoice"), Is.Null);

            model.IsEInvoice = false;
            var explicitlyDisabled = JObject.Parse(JsonConvert.SerializeObject(model, new PatchRequestJsonSerializerSettings()));
            Assert.That(explicitlyDisabled["IsEInvoice"].Value<bool>(), Is.False);

            model.IsEInvoice = true;
            var explicitlyEnabled = JObject.Parse(JsonConvert.SerializeObject(model, new PatchRequestJsonSerializerSettings()));
            Assert.That(explicitlyEnabled["IsEInvoice"].Value<bool>(), Is.True);
        }

        [Test]
        public void IsEInvoiceFilters_UseTheApiFieldNameForAllSupportedDocumentTypes()
        {
            var invoices = new FilterModifier<IssuedInvoiceFilter>();
            invoices.Filter(filter => filter.IsEInvoice.IsEqual(true));
            var creditNotes = new FilterModifier<CreditNoteFilter>();
            creditNotes.Filter(filter => filter.IsEInvoice.IsEqual(true));
            var taxDocuments = new FilterModifier<IssuedTaxDocumentFilter>();
            taxDocuments.Filter(filter => filter.IsEInvoice.IsEqual(true));

            const string expected = "(IsEInvoice~eq~true)";
            Assert.That(invoices.GetQueryParameters()["filter"], Is.EqualTo(expected));
            Assert.That(creditNotes.GetQueryParameters()["filter"], Is.EqualTo(expected));
            Assert.That(taxDocuments.GetQueryParameters()["filter"], Is.EqualTo(expected));
        }
    }
}
