using System;
using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.Models.CreditNote;
using IdokladSdk.Models.EDocument;
using IdokladSdk.Models.IssuedInvoice;
using IdokladSdk.Models.IssuedTaxDocument.Get;
using IdokladSdk.Models.IssuedTaxDocument.Post;
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
        [TestCase(null, null, false)]
        [TestCase(123, null, true)]
        [TestCase(null, 123, true)]
        [TestCase(123, 456, true)]
        [TestCase(null, 0, false)]
        [TestCase(null, -1, false)]
        public void TaxDocumentPost_RequiresPaymentOrCorrectedDocument(int? paymentId, int? correctedDocumentId, bool isValid)
        {
            var model = new IssuedTaxDocumentPostModel
            {
                PaymentId = paymentId,
                CorrectedDocumentId = correctedDocumentId,
                DateOfIssue = new DateTime(2026, 11, 11, 0, 0, 0, DateTimeKind.Utc),
                Items = new List<IssuedTaxDocumentItemPostModel>()
            };

            Assert.That(model.Validate().IsValid, Is.EqualTo(isValid));
        }

        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(2, false)]
        [TestCase(-1, false)]
        public void SendModel_ValidatesCurrentDeliveryModesAndMethods(int value, bool isValid)
        {
            var model = new EInvoiceSendModel
            {
                DocumentId = 123,
                DeliveryMode = (EInvoiceDeliveryMode)value,
                Method = (EInvoiceSendMethod)value
            };

            Assert.That(model.Validate().IsValid, Is.EqualTo(isValid));
        }

        [Test]
        public void SendModel_PreservesAgendaDefaultsWhenAttachmentOptionsAreOmitted()
        {
            var body = JObject.Parse(JsonConvert.SerializeObject(new EInvoiceSendModel { DocumentId = 123 }, new CommonJsonSerializerSettings()));

            Assert.That(body["SendAttachments"].Type, Is.EqualTo(JTokenType.Null));
            Assert.That(body["SendDocumentPdf"].Type, Is.EqualTo(JTokenType.Null));
            Assert.That(body["Method"].Type, Is.EqualTo(JTokenType.Null));
            Assert.That(body["AttachmentIds"], Is.Empty);
        }

        [Test]
        public void DocumentDetails_PreservePeppolTimestampAndDeliveryStatus()
        {
            const string json = "{\"DateCreatedEDocument\":\"2026-11-11T09:42:18Z\",\"EInvoiceStatus\":4,\"DocumentType\":12,\"CreditedDocumentType\":3,\"CorrectedDocumentId\":123}";
            var settings = new CommonJsonSerializerSettings();
            var invoice = JsonConvert.DeserializeObject<IssuedInvoiceGetModel>(json, settings);
            var creditNote = JsonConvert.DeserializeObject<CreditNoteGetModel>(json, settings);
            var taxDocument = JsonConvert.DeserializeObject<IssuedTaxDocumentGetModel>(json, settings);
            var timestamp = new DateTime(2026, 11, 11, 9, 42, 18, DateTimeKind.Utc);

            Assert.That(invoice.DateCreatedEDocument, Is.EqualTo(timestamp));
            Assert.That(creditNote.DateCreatedEDocument, Is.EqualTo(timestamp));
            Assert.That(taxDocument.DateCreatedEDocument, Is.EqualTo(timestamp));
            Assert.That(invoice.EInvoiceStatus, Is.EqualTo(EInvoiceStatus.Delivered));
            Assert.That(creditNote.EInvoiceStatus, Is.EqualTo(EInvoiceStatus.Delivered));
            Assert.That(taxDocument.EInvoiceStatus, Is.EqualTo(EInvoiceStatus.Delivered));
            Assert.That(creditNote.DocumentType, Is.EqualTo(CorrectedDocumentType.IssuedDebitNote));
            Assert.That(creditNote.CreditedDocumentType, Is.EqualTo(CorrectedDocumentType.CreditNote));
            Assert.That(taxDocument.CorrectedDocumentId, Is.EqualTo(123));
        }

        [Test]
        public void CorrectionFilters_UseSupportedApiFieldNamesAndValues()
        {
            var invoices = new FilterModifier<IssuedInvoiceFilter>();
            invoices.Filter(filter => filter.EInvoiceChannel.IsEqual(EInvoiceChannel.XmlSentViaPeppol));
            var creditNotes = new FilterModifier<CreditNoteFilter>();
            creditNotes.Filter(filter => filter.DocumentType.IsEqual(CorrectedDocumentType.IssuedDebitNote));
            var taxDocuments = new FilterModifier<IssuedTaxDocumentFilter>();
            taxDocuments.Filter(filter => filter.CorrectedDocumentId.IsEqual(123));

            Assert.That(invoices.GetQueryParameters()["filter"], Is.EqualTo("(EInvoiceChannel~eq~XmlSentViaPeppol)"));
            Assert.That(creditNotes.GetQueryParameters()["filter"], Is.EqualTo("(DocumentType~eq~IssuedDebitNote)"));
            Assert.That(taxDocuments.GetQueryParameters()["filter"], Is.EqualTo("(CorrectedDocumentId~eq~123)"));
        }

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
