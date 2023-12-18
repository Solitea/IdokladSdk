using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Core.Helpers;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.CreditNote;
using IdokladSdk.Models.CreditNote.Post;
using IdokladSdk.Models.CreditNote.Put;
using IdokladSdk.Models.DocumentAddress;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.CreditNote
{
    /// <summary>
    /// CreditNoteTests.
    /// </summary>
    [TestFixture]
    public class CreditNoteTests : TestBase
    {
        private const int InvoiceWithMossId = 1052496;

        private const int DeliveryAddressId1 = 11;

        private const int DeliveryAddressId2 = 12;

        private CreditNoteDefaultGetModel _creditNotePostModel;

        private CreditNotePostModel _creditNoteToOffsetPostModel;

        private int _creditedIssuedInvoiceId;

        private int _postedCreditNoteItemId;

        private int _postedCreditNoteId;

        private int _offsetCreditNoteId;

        public CreditNoteClient CreditNoteClient { get; set; }

        public IssuedDocumentPaymentClient IssuedDocumentPaymentClient { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            CreditNoteClient = DokladApi.CreditNoteClient;
            IssuedDocumentPaymentClient = DokladApi.IssuedDocumentPaymentClient;
            _creditedIssuedInvoiceId = DokladSdkTestsHelper.CreateDefaultIssuedInvoiceAsync(DokladApi).GetAwaiter().GetResult().Id;
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await DokladApi.IssuedInvoiceClient.DeleteAsync(_creditedIssuedInvoiceId);
        }

        [Test]
        [Order(1)]
        public async Task DefaultAsync_SuccessfullyReturned()
        {
            // Act
            _creditNotePostModel = await CreditNoteClient.DefaultAsync(_creditedIssuedInvoiceId).AssertResult();

            // Assert
            AssertDefault(_creditNotePostModel);
        }

        [Test]
        [Order(2)]
        public async Task PostAsync_SuccessfullyPosted()
        {
            // Arrange
            CreatePostModel(_creditNotePostModel);

            // Act
            var creditNoteGetModel = await CreditNoteClient.PostAsync(_creditNotePostModel).AssertResult();
            _postedCreditNoteId = creditNoteGetModel.Id;
            _postedCreditNoteItemId = creditNoteGetModel.Items.First().Id;

            // Assert
            ComparePostAndGetModels(_creditNotePostModel, creditNoteGetModel, false);
            ComparePostAndGetItems(_creditNotePostModel.Items, creditNoteGetModel.Items.Cast<CreditNoteItemListGetModel>().ToList());
        }

        [Test]
        [Order(3)]
        public async Task GetDetailAsync_ReturnsCreditNote()
        {
            // Act
            var creditNoteGetModel = await CreditNoteClient.Detail(_postedCreditNoteId).GetAsync().AssertResult();

            // Assert
            Assert.That(creditNoteGetModel.Id, Is.EqualTo(_postedCreditNoteId));
            ComparePostAndGetModels(_creditNotePostModel, creditNoteGetModel, false);
            ComparePostAndGetItems(_creditNotePostModel.Items, creditNoteGetModel.Items.Cast<CreditNoteItemListGetModel>().ToList());
        }

        [Test]
        [Order(4)]
        public async Task GetListAsync_ReturnsCreditNotes()
        {
            // Act
            var data = await CreditNoteClient
                .List()
                .Filter(c => c.Id.IsEqual(_postedCreditNoteId))
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.Items, Is.Not.Null);
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
            var firstItem = data.Items.First();
            ComparePostAndGetModels(_creditNotePostModel, firstItem, false);
            ComparePostAndGetItems(_creditNotePostModel.Items, firstItem.Items);
        }

        [Test]
        [Order(5)]
        public async Task UpdateAsync_SuccessfullyUpdatedCreditNote()
        {
            // Arrange
            var creditNotePatchModel = CreatePatchModel();

            // Act
            var creditNoteGetModel = await CreditNoteClient.UpdateAsync(creditNotePatchModel).AssertResult();

            // Assert
            Assert.That(creditNoteGetModel.Id, Is.EqualTo(creditNotePatchModel.Id));
            ComparePatchAndGetModels(creditNotePatchModel, creditNoteGetModel);
        }

        [Test]
        [Order(6)]
        public async Task RecountAsync_SuccessfullyRecounted()
        {
            // Arrange
            var creditNoteRecountPostModel = CreateRecountPostModel();

            // Act
            var creditNoteRecountGetModel = await CreditNoteClient.RecountAsync(creditNoteRecountPostModel).AssertResult();

            // Assert
            ComparePostAndGetRecountModels(creditNoteRecountPostModel, creditNoteRecountGetModel);
        }

        [Test]
        [Order(7)]
        public async Task OffsetNewCreditNoteAsync_SuccessfullyOffset()
        {
            // Arrange
            var result = await IssuedDocumentPaymentClient.FullyUnpayAsync(_creditedIssuedInvoiceId).AssertResult();
            Assert.That(result, Is.True);
            _creditNoteToOffsetPostModel = await CreditNoteClient.DefaultAsync(_creditedIssuedInvoiceId).AssertResult();
            CreatePostModel(_creditNoteToOffsetPostModel);

            // Act
            var offsetCreditNote = await CreditNoteClient.OffsetAsync(_creditNoteToOffsetPostModel).AssertResult();
            _offsetCreditNoteId = offsetCreditNote.Id;

            // Assert
            Assert.That(offsetCreditNote.Id, Is.EqualTo(_offsetCreditNoteId));
            ComparePostAndGetModels(_creditNoteToOffsetPostModel, offsetCreditNote, true);
            ComparePostAndGetItems(_creditNoteToOffsetPostModel.Items, offsetCreditNote.Items.Cast<CreditNoteItemListGetModel>().ToList());
            Assert.That(offsetCreditNote.DateOfPayment, Is.Not.Null);
        }

        [Test]
        [Order(8)]
        public async Task OffsetExistingCreditNoteAsync_SuccessfullyOffset()
        {
            // Arrange
            var result = await IssuedDocumentPaymentClient.FullyUnpayAsync(_creditedIssuedInvoiceId).AssertResult();
            Assert.That(result, Is.True);
            result = await IssuedDocumentPaymentClient.FullyUnpayAsync(_offsetCreditNoteId).AssertResult();
            Assert.That(result, Is.True);

            // Act
            var offsetCreditNote = await CreditNoteClient.OffsetAsync(_offsetCreditNoteId, new CreditNoteOffsetPutModel()).AssertResult();

            // Assert
            Assert.That(offsetCreditNote.Id, Is.EqualTo(_offsetCreditNoteId));
            ComparePostAndGetModels(_creditNoteToOffsetPostModel, offsetCreditNote, true);
            ComparePostAndGetItems(_creditNoteToOffsetPostModel.Items, offsetCreditNote.Items.Cast<CreditNoteItemListGetModel>().ToList());
            Assert.That(offsetCreditNote.DateOfPayment, Is.Not.Null);
        }

        [Test]
        [Order(9)]
        public async Task DeleteAsync_SuccessfullyDeletedCreditNote()
        {
            // Act
            var result1 = await CreditNoteClient.DeleteAsync(_postedCreditNoteId).AssertResult();
            var result2 = await CreditNoteClient.DeleteAsync(_offsetCreditNoteId).AssertResult();

            // Assert
            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
        }

        [Test]
        public async Task CreateFromInvoiceWithMossAsync_SuccessfullyCreated()
        {
            // Act
            var model = await CreditNoteClient.DefaultAsync(InvoiceWithMossId).AssertResult();
            model.CreditNoteReason = "Creadit note reason";
            var result = await CreditNoteClient.PostAsync(model).AssertResult();

            // Assert
            Assert.That(result.Id, Is.GreaterThan(0));
            Assert.That(result.HasVatRegimeOss, Is.True);
            Assert.That(result.Items.First().VatRate, Is.EqualTo(19));

            // Teardown
            await CreditNoteClient.DeleteAsync(result.Id);
        }

        private static void AssertDefaultItem(CreditNoteItemPostModel creditNoteItem)
        {
            Assert.That(creditNoteItem.DiscountName, Is.Not.Empty);
            Assert.That(creditNoteItem.Name, Is.Not.Empty);
        }

        private static void ComparePatchAndGetModels(CreditNotePatchModel patchModel, CreditNoteGetModel getModel)
        {
            Assert.That(getModel.Attachments, Is.Empty);
            Assert.That(getModel.ConstantSymbolId, Is.EqualTo(patchModel.ConstantSymbolId));
            Assert.That(getModel.CreditNoteReason, Is.EqualTo(patchModel.CreditNoteReason));
            Assert.That(getModel.CurrencyId, Is.EqualTo(patchModel.CurrencyId));
            Assert.That(getModel.DateOfIssue.Date, Is.EqualTo(patchModel.DateOfIssue.Value.GetValueOrDefault().Date));
            Assert.That(getModel.DateOfMaturity.Date, Is.EqualTo(patchModel.DateOfMaturity.Value.GetValueOrDefault().Date));
            Assert.That(getModel.DateOfTaxing.Date, Is.EqualTo(patchModel.DateOfTaxing.GetValueOrDefault().Date));
            Assert.That(getModel.DateOfVatClaim?.Date, Is.EqualTo(patchModel.DateOfVatClaim.Value?.Date));
            Assert.That(getModel.Description, Is.EqualTo(patchModel.Description));
            Assert.That(getModel.DiscountPercentage, Is.EqualTo(patchModel.DiscountPercentage));
            Assert.That(getModel.EetResponsibility, Is.EqualTo(patchModel.EetResponsibility));
            Assert.That(getModel.ExchangeRate, Is.EqualTo(patchModel.ExchangeRate));
            Assert.That(getModel.ExchangeRateAmount, Is.EqualTo(patchModel.ExchangeRateAmount));
            Assert.That(getModel.IsEet, Is.EqualTo(patchModel.IsEet.GetValueOrDefault()));
            Assert.That(getModel.IsIncomeTax, Is.EqualTo(patchModel.IsIncomeTax));
            var getModelNormalItems = getModel.Items.Where(i => i.ItemType == IssuedInvoiceItemType.ItemTypeNormal)
                .ToList();
            Assert.That(getModelNormalItems.Count, Is.EqualTo(patchModel.Items.Count));

            for (int i = 0; i < patchModel.Items.Count; i++)
            {
                ComparePatchAndGetItemModels(patchModel.Items[i], getModelNormalItems[i]);
            }

            Assert.That(getModel.ItemsTextPrefix, Is.EqualTo(patchModel.ItemsTextPrefix));
            Assert.That(getModel.ItemsTextSuffix, Is.EqualTo(patchModel.ItemsTextSuffix));
            Assert.That(getModel.Note, Is.EqualTo(patchModel.Note));
            Assert.That(getModel.OrderNumber, Is.EqualTo(patchModel.OrderNumber));
            Assert.That(getModel.PartnerId, Is.EqualTo(patchModel.PartnerId));
            Assert.That(getModel.PartnerAddress.AccountNumber, Is.EqualTo(patchModel.PartnerAddress.AccountNumber));
            Assert.That(getModel.PartnerAddress.City, Is.EqualTo(patchModel.PartnerAddress.City));
            Assert.That(getModel.PartnerAddress.CountryId, Is.EqualTo(patchModel.PartnerAddress.CountryId));
            Assert.That(getModel.PartnerAddress.Fax, Is.EqualTo(patchModel.PartnerAddress.Fax));
            Assert.That(getModel.PartnerAddress.Firstname, Is.EqualTo(patchModel.PartnerAddress.Firstname));
            Assert.That(getModel.PartnerAddress.Iban, Is.EqualTo(patchModel.PartnerAddress.Iban));
            Assert.That(getModel.PartnerAddress.IdentificationNumber, Is.EqualTo(patchModel.PartnerAddress.IdentificationNumber));
            Assert.That(getModel.PartnerAddress.Mobile, Is.EqualTo(patchModel.PartnerAddress.Mobile));
            Assert.That(getModel.PartnerAddress.Phone, Is.EqualTo(patchModel.PartnerAddress.Phone));
            Assert.That(getModel.PartnerAddress.PostalCode, Is.EqualTo(patchModel.PartnerAddress.PostalCode));
            Assert.That(getModel.PartnerAddress.Street, Is.EqualTo(patchModel.PartnerAddress.Street));
            Assert.That(getModel.PartnerAddress.Surname, Is.EqualTo(patchModel.PartnerAddress.Surname));
            Assert.That(getModel.PartnerAddress.Swift, Is.EqualTo(patchModel.PartnerAddress.Swift));
            Assert.That(getModel.PartnerAddress.VatIdentificationNumber, Is.EqualTo(patchModel.PartnerAddress.VatIdentificationNumber));
            Assert.That(getModel.PartnerAddress.VatIdentificationNumberSk, Is.EqualTo(patchModel.PartnerAddress.VatIdentificationNumberSk));
            Assert.That(getModel.PartnerAddress.Www, Is.EqualTo(patchModel.PartnerAddress.Www));
            Assert.That(getModel.MyAddress.AccountNumber, Is.EqualTo(patchModel.MyAddress.AccountNumber));
            Assert.That(getModel.MyAddress.Iban, Is.EqualTo(patchModel.MyAddress.Iban));
            Assert.That(getModel.MyAddress.Swift, Is.EqualTo(patchModel.MyAddress.Swift));
            Assert.That(getModel.MyAddress.BankCode, Is.EqualTo("0600"));
            Assert.That(getModel.PaymentOptionId, Is.EqualTo(patchModel.PaymentOptionId));
            Assert.That(getModel.Prices, Is.Not.Null);
            Assert.That(getModel.Prices.TotalWithVat, Is.Zero);
            Assert.That(getModel.ReportLanguage, Is.EqualTo(patchModel.ReportLanguage));
            Assert.That(getModel.VariableSymbol, Is.EqualTo(patchModel.VariableSymbol));
        }

        private static void ComparePatchAndGetItemModels(CreditNoteItemPatchModel patchModel, CreditNoteItemGetModel getModel)
        {
            Assert.That(getModel.Amount, Is.EqualTo(patchModel.Amount));
            Assert.That(getModel.DiscountName, Is.EqualTo(patchModel.DiscountPercentage != 0.0m ? patchModel.DiscountName ?? string.Empty : string.Empty));
            Assert.That(getModel.DiscountPercentage, Is.EqualTo((decimal)patchModel.DiscountPercentage));
            Assert.That(getModel.IsTaxMovement, Is.EqualTo(patchModel.IsTaxMovement));
            Assert.That(getModel.Name, Is.EqualTo(patchModel.Name));
            Assert.That(getModel.PriceListItemId, Is.EqualTo((int)patchModel.PriceListItemId));
            Assert.That(getModel.Prices, Is.Not.Null);
            Assert.That(getModel.Prices.TotalWithVat, Is.Zero);
            Assert.That(getModel.PriceType, Is.EqualTo(patchModel.PriceType));
            Assert.That(getModel.Unit, Is.EqualTo(patchModel.Unit));
            Assert.That(getModel.VatRateType, Is.EqualTo(patchModel.VatRateType));
        }

        private static void ComparePostAndGetModels(CreditNotePostModel postModel, CreditNoteListGetModel getModel, bool offset)
        {
            Assert.That(getModel.Attachments, Is.Empty);
            Assert.That(getModel.ConstantSymbolId, Is.EqualTo(postModel.ConstantSymbolId));
            Assert.That(getModel.CreditedInvoiceId, Is.EqualTo(postModel.CreditedInvoiceId));
            Assert.That(getModel.CreditNoteReason, Is.EqualTo(postModel.CreditNoteReason));
            Assert.That(getModel.CurrencyId, Is.EqualTo(postModel.CurrencyId));
            Assert.That(getModel.DateOfIssue.Date, Is.EqualTo(postModel.DateOfIssue.Date));
            Assert.That(getModel.DateOfMaturity.Date, Is.EqualTo(postModel.DateOfMaturity.Date));

            if (offset)
            {
                Assert.That(getModel.DateOfPayment.Date, Is.Not.Null);
            }
            else
            {
                Assert.That(getModel.DateOfPayment.Date, Is.EqualTo(postModel.DateOfPayment.GetValueOrDefault().Date));
            }

            Assert.That(getModel.DateOfTaxing.Date, Is.EqualTo(postModel.DateOfTaxing.Date));
            Assert.That(getModel.DateOfVatClaim?.Date, Is.EqualTo(postModel.DateOfVatClaim));
            Assert.That(getModel.Description, Is.EqualTo(postModel.Description));
            Assert.That(getModel.DiscountPercentage, Is.EqualTo(postModel.DiscountPercentage));
            Assert.That(getModel.DocumentSerialNumber, Is.GreaterThan(0));
            Assert.That(getModel.EetResponsibility, Is.EqualTo(postModel.EetResponsibility));
            Assert.That(getModel.ExchangeRate, Is.EqualTo(postModel.ExchangeRate));
            Assert.That(getModel.ExchangeRateAmount, Is.EqualTo(postModel.ExchangeRateAmount));
            Assert.That(getModel.IsEet, Is.EqualTo(postModel.IsEet));
            Assert.That(getModel.IsIncomeTax, Is.EqualTo(postModel.IsIncomeTax));
            Assert.That(getModel.ItemsTextPrefix, Is.EqualTo(postModel.ItemsTextPrefix));
            Assert.That(getModel.ItemsTextSuffix, Is.EqualTo(postModel.ItemsTextSuffix));
            Assert.That(getModel.MyAddress.AccountNumber, Is.EqualTo(postModel.AccountNumber));
            Assert.That(getModel.MyAddress.Iban, Is.EqualTo(postModel.Iban));
            Assert.That(getModel.MyAddress.Swift, Is.EqualTo(postModel.Swift));
            Assert.That(getModel.Note, Is.EqualTo(postModel.Note));
            Assert.That(getModel.NoteForCreditNote, Is.EqualTo(postModel.NoteForCreditNote));
            Assert.That(getModel.OrderNumber, Is.EqualTo(postModel.OrderNumber));
            Assert.That(getModel.PartnerId, Is.EqualTo(postModel.PartnerId));

            if (!offset)
            {
                Assert.That(getModel.PaymentOptionId, Is.EqualTo(postModel.PaymentOptionId));
            }

            Assert.That(getModel.Prices, Is.Not.Null);
            Assert.That(getModel.Prices.TotalWithVat, Is.Not.Zero);
            Assert.That(getModel.ReportLanguage, Is.EqualTo(postModel.ReportLanguage));
            Assert.That(getModel.SalesPosEquipmentId, Is.EqualTo(postModel.SalesPosEquipmentId));
            Assert.That(getModel.VariableSymbol, Is.EqualTo(postModel.VariableSymbol));
            Assert.That(getModel.VatOnPayStatus, Is.EqualTo(postModel.VatOnPayStatus));
            Assert.That(getModel.VatReverseChargeCodeId, Is.EqualTo(postModel.VatReverseChargeCodeId));
        }

        private static void ComparePostAndGetItemModels(CreditNoteItemPostModel postModel, CreditNoteItemListGetModel getModel)
        {
            Assert.That(getModel.Amount, Is.EqualTo(postModel.Amount));
            Assert.That(getModel.Code, Is.EqualTo(postModel.Code));
            Assert.That(getModel.DiscountName, Is.EqualTo(postModel.DiscountPercentage != 0.0m ? postModel.DiscountName ?? string.Empty : string.Empty));
            Assert.That(getModel.DiscountPercentage, Is.EqualTo(postModel.DiscountPercentage));
            Assert.That(getModel.IsTaxMovement, Is.EqualTo(postModel.IsTaxMovement));
            Assert.That(getModel.Name, Is.EqualTo(postModel.Name));
            Assert.That(getModel.PriceListItemId, Is.EqualTo(postModel.PriceListItemId));
            Assert.That(getModel.Prices, Is.Not.Null);
            Assert.That(getModel.Prices.TotalWithVat, Is.Not.Zero);
            Assert.That(getModel.PriceType, Is.EqualTo(postModel.PriceType));
            Assert.That(getModel.Unit, Is.EqualTo(postModel.Unit));
            Assert.That(getModel.VatCodeId, Is.EqualTo(postModel.VatCodeId));
            Assert.That(getModel.VatRateType, Is.EqualTo(postModel.VatRateType));
        }

        private static void ComparePostAndGetItems(List<CreditNoteItemPostModel> postModelItems, List<CreditNoteItemListGetModel> getModelItems)
        {
            var getModelNormalItems = getModelItems.Where(i => i.ItemType == IssuedInvoiceItemType.ItemTypeNormal)
                .ToList();
            Assert.That(getModelNormalItems.Count, Is.EqualTo(postModelItems.Count));

            for (int i = 0; i < postModelItems.Count; i++)
            {
                ComparePostAndGetItemModels(postModelItems[i], getModelNormalItems[i]);
            }
        }

        private static void ComparePostAndGetRecountModels(CreditNoteRecountPostModel postModel, CreditNoteRecountGetModel getModel)
        {
            Assert.That(getModel.CurrencyId, Is.EqualTo(postModel.CurrencyId));
            Assert.That(getModel.DiscountPercentage, Is.EqualTo(postModel.DiscountPercentage));
            Assert.That(getModel.ExchangeRate, Is.EqualTo(postModel.ExchangeRate));
            Assert.That(getModel.ExchangeRateAmount, Is.EqualTo(postModel.ExchangeRateAmount));
            Assert.That(getModel.Prices.TotalPaid, Is.EqualTo(0));
            Assert.That(getModel.Prices.TotalPaidHc, Is.EqualTo(0));
            Assert.That(getModel.Prices.TotalVat, Is.EqualTo(37.8m));
            Assert.That(getModel.Prices.TotalVatHc, Is.EqualTo(37.8m));
            Assert.That(getModel.Prices.TotalWithoutVat, Is.EqualTo(180.2m));
            Assert.That(getModel.Prices.TotalWithoutVatHc, Is.EqualTo(180.2m));
            Assert.That(getModel.Prices.TotalWithVat, Is.EqualTo(218m));
            Assert.That(getModel.Prices.TotalWithVatHc, Is.EqualTo(218m));
            Assert.That(getModel.Prices.TotalDiscountAmount, Is.EqualTo(-24.2m));
            Assert.That(getModel.Prices.TotalWithoutDiscount, Is.EqualTo(242m));

            Assert.That(getModel.Items.Count, Is.GreaterThanOrEqualTo(1));
            ComparePostAndGetRecountItemModels(postModel.Items.First(), getModel.Items.First(i => i.ItemType == IssuedInvoiceItemType.ItemTypeNormal));

            Assert.That(getModel.Prices.VatRateSummary.Count, Is.EqualTo(2));
            CheckRecountVatRateSummary(getModel.Prices.VatRateSummary.First());
        }

        private static void ComparePostAndGetRecountItemModels(CreditNoteItemRecountPostModel postModel, CreditNoteItemRecountGetModel getModel)
        {
            Assert.That(getModel.Amount, Is.EqualTo(postModel.Amount));
            Assert.That(getModel.DiscountPercentage, Is.EqualTo(postModel.DiscountPercentage));
            Assert.That(getModel.Id, Is.EqualTo(postModel.Id));
            Assert.That(getModel.Name, Is.EqualTo(postModel.Name));
            Assert.That(getModel.Prices.TotalVat, Is.EqualTo(37.8m));
            Assert.That(getModel.Prices.TotalVatHc, Is.EqualTo(37.8m));
            Assert.That(getModel.Prices.TotalWithoutVat, Is.EqualTo(180m));
            Assert.That(getModel.Prices.TotalWithoutVatHc, Is.EqualTo(180m));
            Assert.That(getModel.Prices.TotalWithVat, Is.EqualTo(217.8m));
            Assert.That(getModel.Prices.TotalWithVatHc, Is.EqualTo(217.8m));
            Assert.That(getModel.PriceType, Is.EqualTo(postModel.PriceType));
            Assert.That(getModel.VatRateType, Is.EqualTo(postModel.VatRateType));
        }

        private static void CheckRecountVatRateSummary(VatRateSummaryItem vatRateSummary)
        {
            Assert.AreEqual(VatRateType.Basic, vatRateSummary.VatRateType);
            Assert.AreEqual(37.8m, vatRateSummary.TotalVat);
            Assert.AreEqual(37.8m, vatRateSummary.TotalVatHc);
            Assert.AreEqual(180m, vatRateSummary.TotalWithoutVat);
            Assert.AreEqual(180m, vatRateSummary.TotalWithoutVatHc);
            Assert.AreEqual(217.8m, vatRateSummary.TotalWithVat);
            Assert.AreEqual(217.8m, vatRateSummary.TotalWithVatHc);
            Assert.AreEqual(21.0m, vatRateSummary.VatRate);
        }

        private static void CreatePostModel(CreditNotePostModel postModel)
        {
            postModel.CreditNoteReason = "reason";
            postModel.DateOfVatClaim = postModel.DateOfVatApplication;
            postModel.DeliveryAddressId = DeliveryAddressId1;
        }

        private void AssertDefault(CreditNotePostModel creditNote)
        {
            Assert.That(creditNote.AccountNumber, Is.Not.Empty);
            Assert.That(creditNote.ConstantSymbolId, Is.Not.Null);
            Assert.That(creditNote.CreditedInvoiceId, Is.EqualTo(_creditedIssuedInvoiceId));
            Assert.That(creditNote.CreditNoteReason, Is.Empty);
            Assert.That(creditNote.CurrencyId, Is.GreaterThan(0));
            Assert.That(creditNote.DateOfIssue, Is.Not.Null);
            Assert.That(creditNote.DateOfMaturity, Is.Not.Null);
            Assert.That(creditNote.DateOfPayment, Is.Not.Null);
            Assert.That(creditNote.DateOfTaxing, Is.Not.Null);
            Assert.That(creditNote.DateOfVatApplication, Is.Not.Null);
            Assert.That(creditNote.DateOfVatClaim, Is.Null);
            Assert.That(creditNote.Description, Is.Not.Empty);
            Assert.That(creditNote.DocumentSerialNumber, Is.GreaterThan(0));
            Assert.That(creditNote.ExchangeRate, Is.EqualTo(1));
            Assert.That(creditNote.ExchangeRateAmount, Is.EqualTo(1));
            Assert.That(creditNote.Items.Count, Is.GreaterThan(0));

            foreach (var creditNoteItem in creditNote.Items)
            {
                AssertDefaultItem(creditNoteItem);
            }

            Assert.That(creditNote.ItemsTextPrefix, Is.Empty);
            Assert.That(creditNote.ItemsTextSuffix, Is.Empty);
            Assert.That(creditNote.Note, Is.Empty);
            Assert.That(creditNote.NoteForCreditNote, Is.Empty);
            Assert.That(creditNote.NumericSequenceId, Is.GreaterThan(0));
            Assert.That(creditNote.PartnerId, Is.GreaterThan(0));
            Assert.That(creditNote.ReportLanguage, Is.Not.Null);
            Assert.That(creditNote.VariableSymbol, Is.Not.Empty);
        }

        private CreditNotePatchModel CreatePatchModel()
        {
            var date = DateTime.Today.AddDays(1);
            var model = new CreditNotePatchModel
            {
                ConstantSymbolId = 11,
                CreditNoteReason = "some text",
                CurrencyId = 10,
                DateOfIssue = date.SetKindUtc(),
                DateOfMaturity = date.AddDays(1).SetKindUtc(),
                DateOfPayment = date.AddDays(2).SetKindUtc(),
                DateOfTaxing = date.AddDays(3).SetKindUtc(),
                DateOfVatClaim = date.AddDays(4).SetKindUtc(),
                DeliveryAddressId = DeliveryAddressId2,
                Description = "other text",
                DiscountPercentage = 0,
                EetResponsibility = EetResponsibility.ExternalApplication,
                ExchangeRate = 10,
                ExchangeRateAmount = 10,
                Id = _postedCreditNoteId,
                IsIncomeTax = true,
                Items = new List<CreditNoteItemPatchModel>
            {
                new CreditNoteItemPatchModel
                {
                    Id = _postedCreditNoteItemId,
                    Amount = 101,
                    DiscountName = "discount name",
                    DiscountPercentage = 13.5m,
                    IsTaxMovement = true,
                    Name = "name",
                    PriceListItemId = 107444,
                    PriceType = PriceType.WithoutVat,
                    Unit = "unit",
                    UnitPrice = 123.45m,
                    VatRateType = VatRateType.Reduced1
                }
            },
                ItemsTextPrefix = "items prefix",
                ItemsTextSuffix = "items suffix",
                Note = "note",
                OrderNumber = "12345667890",
                PartnerId = 323823,
                PartnerAddress = new DocumentAddressPatchModel
                {
                    AccountNumber = "1234567890",
                    City = "Bystrice nad Pernstejnem",
                    CountryId = 3,
                    Fax = "1234567890",
                    Firstname = "Firstname",
                    Iban = "1234567890",
                    IdentificationNumber = "68636938",
                    Mobile = "9876543210",
                    Phone = "1472583690",
                    PostalCode = "60200",
                    Street = "Tyrsova",
                    Surname = "Surname",
                    Swift = "7894561230",
                    Title = "some title",
                    VatIdentificationNumber = "9876543210",
                    VatIdentificationNumberSk = "3216549870",
                    Www = "xxx.yyy.cz"
                },
                MyAddress = new MyDocumentAddressPatchModel
                {
                    AccountNumber = "555777",
                    Iban = "5453187522",
                    Swift = "asda514",
                    BankId = 14
                },
                PaymentOptionId = 4,
                ReportLanguage = Language.Sk,
                VariableSymbol = "9876543210"
            };

            return model;
        }

        private CreditNoteRecountPostModel CreateRecountPostModel()
        {
            var model = new CreditNoteRecountPostModel
            {
                CurrencyId = _creditNotePostModel.CurrencyId,
                DateOfTaxing = DateTime.Today.SetKindUtc(),
                DiscountPercentage = 0,
                ExchangeRate = 1,
                ExchangeRateAmount = 1,
                PaymentOptionId = 1,
                Items = new List<CreditNoteItemRecountPostModel>
            {
                new CreditNoteItemRecountPostModel
                {
                    Amount = 2,
                    Id = 5,
                    Name = "item",
                    PriceType = PriceType.WithoutVat,
                    UnitPrice = 100,
                    VatRateType = VatRateType.Basic,
                    DiscountPercentage = 10
                }
            }
            };

            return model;
        }
    }
}
