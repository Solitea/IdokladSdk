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
            Assert.AreEqual(_postedCreditNoteId, creditNoteGetModel.Id);
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
            Assert.NotNull(data.Items);
            Assert.Greater(data.TotalItems, 0);
            Assert.Greater(data.TotalPages, 0);
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
            Assert.AreEqual(creditNotePatchModel.Id, creditNoteGetModel.Id);
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
            Assert.True(result);
            _creditNoteToOffsetPostModel = await CreditNoteClient.DefaultAsync(_creditedIssuedInvoiceId).AssertResult();
            CreatePostModel(_creditNoteToOffsetPostModel);

            // Act
            var offsetCreditNote = await CreditNoteClient.OffsetAsync(_creditNoteToOffsetPostModel).AssertResult();
            _offsetCreditNoteId = offsetCreditNote.Id;

            // Assert
            Assert.AreEqual(_offsetCreditNoteId, offsetCreditNote.Id);
            ComparePostAndGetModels(_creditNoteToOffsetPostModel, offsetCreditNote, true);
            ComparePostAndGetItems(_creditNoteToOffsetPostModel.Items, offsetCreditNote.Items.Cast<CreditNoteItemListGetModel>().ToList());
            Assert.IsNotNull(offsetCreditNote.DateOfPayment);
        }

        [Test]
        [Order(8)]
        public async Task OffsetExistingCreditNoteAsync_SuccessfullyOffset()
        {
            // Arrange
            var result = await IssuedDocumentPaymentClient.FullyUnpayAsync(_creditedIssuedInvoiceId).AssertResult();
            Assert.True(result);
            result = await IssuedDocumentPaymentClient.FullyUnpayAsync(_offsetCreditNoteId).AssertResult();
            Assert.True(result);

            // Act
            var offsetCreditNote = await CreditNoteClient.OffsetAsync(_offsetCreditNoteId, new CreditNoteOffsetPutModel()).AssertResult();

            // Assert
            Assert.AreEqual(_offsetCreditNoteId, offsetCreditNote.Id);
            ComparePostAndGetModels(_creditNoteToOffsetPostModel, offsetCreditNote, true);
            ComparePostAndGetItems(_creditNoteToOffsetPostModel.Items, offsetCreditNote.Items.Cast<CreditNoteItemListGetModel>().ToList());
            Assert.IsNotNull(offsetCreditNote.DateOfPayment);
        }

        [Test]
        [Order(9)]
        public async Task DeleteAsync_SuccessfullyDeletedCreditNote()
        {
            // Act
            var result1 = await CreditNoteClient.DeleteAsync(_postedCreditNoteId).AssertResult();
            var result2 = await CreditNoteClient.DeleteAsync(_offsetCreditNoteId).AssertResult();

            // Assert
            Assert.True(result1);
            Assert.True(result2);
        }

        [Test]
        public async Task CreateFromInvoiceWithMossAsync_SuccessfullyCreated()
        {
            // Act
            var model = await CreditNoteClient.DefaultAsync(InvoiceWithMossId).AssertResult();
            model.CreditNoteReason = "Creadit note reason";
            var result = await CreditNoteClient.PostAsync(model).AssertResult();

            // Assert
            Assert.Greater(result.Id, 0);
            Assert.That(result.HasVatRegimeOss, Is.True);
            Assert.AreEqual(result.Items.First().VatRate, 19);

            // Teardown
            await CreditNoteClient.DeleteAsync(result.Id);
        }

        private static void AssertDefaultItem(CreditNoteItemPostModel creditNoteItem)
        {
            Assert.IsNotEmpty(creditNoteItem.DiscountName);
            Assert.IsNotEmpty(creditNoteItem.Name);
        }

        private static void ComparePatchAndGetModels(CreditNotePatchModel patchModel, CreditNoteGetModel getModel)
        {
            Assert.IsEmpty(getModel.Attachments);
            Assert.AreEqual(patchModel.ConstantSymbolId, getModel.ConstantSymbolId);
            Assert.AreEqual(patchModel.CreditNoteReason, getModel.CreditNoteReason);
            Assert.AreEqual(patchModel.CurrencyId, getModel.CurrencyId);
            Assert.AreEqual(patchModel.DateOfIssue.Value.GetValueOrDefault().Date, getModel.DateOfIssue.Date);
            Assert.AreEqual(patchModel.DateOfMaturity.Value.GetValueOrDefault().Date, getModel.DateOfMaturity.Date);
            Assert.AreEqual(patchModel.DateOfTaxing.GetValueOrDefault().Date, getModel.DateOfTaxing.Date);
            Assert.AreEqual(patchModel.DateOfVatClaim.Value?.Date, getModel.DateOfVatClaim?.Date);
            Assert.AreEqual(patchModel.Description, getModel.Description);
            Assert.AreEqual(patchModel.DiscountPercentage, getModel.DiscountPercentage);
            Assert.AreEqual(patchModel.EetResponsibility, getModel.EetResponsibility);
            Assert.AreEqual(patchModel.ExchangeRate, getModel.ExchangeRate);
            Assert.AreEqual(patchModel.ExchangeRateAmount, getModel.ExchangeRateAmount);
            Assert.AreEqual(patchModel.IsEet.GetValueOrDefault(), getModel.IsEet);
            Assert.AreEqual(patchModel.IsIncomeTax, getModel.IsIncomeTax);
            var getModelNormalItems = getModel.Items.Where(i => i.ItemType == IssuedInvoiceItemType.ItemTypeNormal)
                .ToList();
            Assert.AreEqual(patchModel.Items.Count, getModelNormalItems.Count);

            for (int i = 0; i < patchModel.Items.Count; i++)
            {
                ComparePatchAndGetItemModels(patchModel.Items[i], getModelNormalItems[i]);
            }

            Assert.AreEqual(patchModel.ItemsTextPrefix, getModel.ItemsTextPrefix);
            Assert.AreEqual(patchModel.ItemsTextSuffix, getModel.ItemsTextSuffix);
            Assert.AreEqual(patchModel.Note, getModel.Note);
            Assert.AreEqual(patchModel.OrderNumber, getModel.OrderNumber);
            Assert.AreEqual(patchModel.PartnerId, getModel.PartnerId);
            Assert.AreEqual(patchModel.PartnerAddress.AccountNumber, getModel.PartnerAddress.AccountNumber);
            Assert.AreEqual(patchModel.PartnerAddress.City, getModel.PartnerAddress.City);
            Assert.AreEqual(patchModel.PartnerAddress.CountryId, getModel.PartnerAddress.CountryId);
            Assert.AreEqual(patchModel.PartnerAddress.Fax, getModel.PartnerAddress.Fax);
            Assert.AreEqual(patchModel.PartnerAddress.Firstname, getModel.PartnerAddress.Firstname);
            Assert.AreEqual(patchModel.PartnerAddress.Iban, getModel.PartnerAddress.Iban);
            Assert.AreEqual(patchModel.PartnerAddress.IdentificationNumber, getModel.PartnerAddress.IdentificationNumber);
            Assert.AreEqual(patchModel.PartnerAddress.Mobile, getModel.PartnerAddress.Mobile);
            Assert.AreEqual(patchModel.PartnerAddress.Phone, getModel.PartnerAddress.Phone);
            Assert.AreEqual(patchModel.PartnerAddress.PostalCode, getModel.PartnerAddress.PostalCode);
            Assert.AreEqual(patchModel.PartnerAddress.Street, getModel.PartnerAddress.Street);
            Assert.AreEqual(patchModel.PartnerAddress.Surname, getModel.PartnerAddress.Surname);
            Assert.AreEqual(patchModel.PartnerAddress.Swift, getModel.PartnerAddress.Swift);
            Assert.AreEqual(patchModel.PartnerAddress.VatIdentificationNumber, getModel.PartnerAddress.VatIdentificationNumber);
            Assert.AreEqual(patchModel.PartnerAddress.VatIdentificationNumberSk, getModel.PartnerAddress.VatIdentificationNumberSk);
            Assert.AreEqual(patchModel.PartnerAddress.Www, getModel.PartnerAddress.Www);
            Assert.AreEqual(patchModel.MyAddress.AccountNumber, getModel.MyAddress.AccountNumber);
            Assert.AreEqual(patchModel.MyAddress.Iban, getModel.MyAddress.Iban);
            Assert.AreEqual(patchModel.MyAddress.Swift, getModel.MyAddress.Swift);
            Assert.AreEqual("0600", getModel.MyAddress.BankCode);
            Assert.AreEqual(patchModel.PaymentOptionId, getModel.PaymentOptionId);
            Assert.IsNotNull(getModel.Prices);
            Assert.NotZero(getModel.Prices.TotalWithVat);
            Assert.AreEqual(patchModel.ReportLanguage, getModel.ReportLanguage);
            Assert.AreEqual(patchModel.VariableSymbol, getModel.VariableSymbol);
        }

        private static void ComparePatchAndGetItemModels(CreditNoteItemPatchModel patchModel, CreditNoteItemGetModel getModel)
        {
            Assert.AreEqual(patchModel.Amount, getModel.Amount);
            Assert.AreEqual(
                patchModel.DiscountPercentage != 0.0m ? patchModel.DiscountName ?? string.Empty : string.Empty,
                getModel.DiscountName);
            Assert.AreEqual((decimal)patchModel.DiscountPercentage, getModel.DiscountPercentage);
            Assert.AreEqual(patchModel.IsTaxMovement, getModel.IsTaxMovement);
            Assert.AreEqual(patchModel.Name, getModel.Name);
            Assert.AreEqual((int)patchModel.PriceListItemId, getModel.PriceListItemId);
            Assert.IsNotNull(getModel.Prices);
            Assert.NotZero(getModel.Prices.TotalWithVat);
            Assert.AreEqual(patchModel.PriceType, getModel.PriceType);
            Assert.AreEqual(patchModel.Unit, getModel.Unit);
            Assert.AreEqual(patchModel.VatRateType, getModel.VatRateType);
        }

        private static void ComparePostAndGetModels(CreditNotePostModel postModel, CreditNoteListGetModel getModel, bool offset)
        {
            Assert.IsEmpty(getModel.Attachments);
            Assert.AreEqual(postModel.ConstantSymbolId, getModel.ConstantSymbolId);
            Assert.AreEqual(postModel.CreditedInvoiceId, getModel.CreditedInvoiceId);
            Assert.AreEqual(postModel.CreditNoteReason, getModel.CreditNoteReason);
            Assert.AreEqual(postModel.CurrencyId, getModel.CurrencyId);
            Assert.AreEqual(postModel.DateOfIssue.Date, getModel.DateOfIssue.Date);
            Assert.AreEqual(postModel.DateOfMaturity.Date, getModel.DateOfMaturity.Date);

            if (offset)
            {
                Assert.IsNotNull(getModel.DateOfPayment.Date);
            }
            else
            {
                Assert.AreEqual(postModel.DateOfPayment.GetValueOrDefault().Date, getModel.DateOfPayment.Date);
            }

            Assert.AreEqual(postModel.DateOfTaxing.Date, getModel.DateOfTaxing.Date);
            Assert.AreEqual(postModel.DateOfVatClaim, getModel.DateOfVatClaim?.Date);
            Assert.AreEqual(postModel.Description, getModel.Description);
            Assert.AreEqual(postModel.DiscountPercentage, getModel.DiscountPercentage);
            Assert.Greater(getModel.DocumentSerialNumber, 0);
            Assert.AreEqual(postModel.EetResponsibility, getModel.EetResponsibility);
            Assert.AreEqual(postModel.ExchangeRate, getModel.ExchangeRate);
            Assert.AreEqual(postModel.ExchangeRateAmount, getModel.ExchangeRateAmount);
            Assert.AreEqual(postModel.IsEet, getModel.IsEet);
            Assert.AreEqual(postModel.IsIncomeTax, getModel.IsIncomeTax);
            Assert.AreEqual(postModel.ItemsTextPrefix, getModel.ItemsTextPrefix);
            Assert.AreEqual(postModel.ItemsTextSuffix, getModel.ItemsTextSuffix);
            Assert.AreEqual(postModel.AccountNumber, getModel.MyAddress.AccountNumber);
            Assert.AreEqual(postModel.Iban, getModel.MyAddress.Iban);
            Assert.AreEqual(postModel.Swift, getModel.MyAddress.Swift);
            Assert.AreEqual(postModel.Note, getModel.Note);
            Assert.AreEqual(postModel.NoteForCreditNote, getModel.NoteForCreditNote);
            Assert.AreEqual(postModel.OrderNumber, getModel.OrderNumber);
            Assert.AreEqual(postModel.PartnerId, getModel.PartnerId);

            if (!offset)
            {
                Assert.AreEqual(postModel.PaymentOptionId, getModel.PaymentOptionId);
            }

            Assert.IsNotNull(getModel.Prices);
            Assert.NotZero(getModel.Prices.TotalWithVat);
            Assert.AreEqual(postModel.ReportLanguage, getModel.ReportLanguage);
            Assert.AreEqual(postModel.SalesPosEquipmentId, getModel.SalesPosEquipmentId);
            Assert.AreEqual(postModel.VariableSymbol, getModel.VariableSymbol);
            Assert.AreEqual(postModel.VatOnPayStatus, getModel.VatOnPayStatus);
            Assert.AreEqual(postModel.VatReverseChargeCodeId, getModel.VatReverseChargeCodeId);
        }

        private static void ComparePostAndGetItemModels(CreditNoteItemPostModel postModel, CreditNoteItemListGetModel getModel)
        {
            Assert.AreEqual(postModel.Amount, getModel.Amount);
            Assert.AreEqual(postModel.Code, getModel.Code);
            Assert.AreEqual(
                postModel.DiscountPercentage != 0.0m ? postModel.DiscountName ?? string.Empty : string.Empty,
                getModel.DiscountName);
            Assert.AreEqual(postModel.DiscountPercentage, getModel.DiscountPercentage);
            Assert.AreEqual(postModel.IsTaxMovement, getModel.IsTaxMovement);
            Assert.AreEqual(postModel.Name, getModel.Name);
            Assert.AreEqual(postModel.PriceListItemId, getModel.PriceListItemId);
            Assert.IsNotNull(getModel.Prices);
            Assert.NotZero(getModel.Prices.TotalWithVat);
            Assert.AreEqual(postModel.PriceType, getModel.PriceType);
            Assert.AreEqual(postModel.Unit, getModel.Unit);
            Assert.AreEqual(postModel.VatCodeId, getModel.VatCodeId);
            Assert.AreEqual(postModel.VatRateType, getModel.VatRateType);
        }

        private static void ComparePostAndGetItems(List<CreditNoteItemPostModel> postModelItems, List<CreditNoteItemListGetModel> getModelItems)
        {
            var getModelNormalItems = getModelItems.Where(i => i.ItemType == IssuedInvoiceItemType.ItemTypeNormal)
                .ToList();
            Assert.AreEqual(postModelItems.Count, getModelNormalItems.Count);

            for (int i = 0; i < postModelItems.Count; i++)
            {
                ComparePostAndGetItemModels(postModelItems[i], getModelNormalItems[i]);
            }
        }

        private static void ComparePostAndGetRecountModels(CreditNoteRecountPostModel postModel, CreditNoteRecountGetModel getModel)
        {
            Assert.AreEqual(postModel.CurrencyId, getModel.CurrencyId);
            Assert.AreEqual(postModel.DiscountPercentage, getModel.DiscountPercentage);
            Assert.AreEqual(postModel.ExchangeRate, getModel.ExchangeRate);
            Assert.AreEqual(postModel.ExchangeRateAmount, getModel.ExchangeRateAmount);
            Assert.AreEqual(0, getModel.Prices.TotalPaid);
            Assert.AreEqual(0, getModel.Prices.TotalPaidHc);
            Assert.AreEqual(37.8m, getModel.Prices.TotalVat);
            Assert.AreEqual(37.8m, getModel.Prices.TotalVatHc);
            Assert.AreEqual(180.2m, getModel.Prices.TotalWithoutVat);
            Assert.AreEqual(180.2m, getModel.Prices.TotalWithoutVatHc);
            Assert.AreEqual(218m, getModel.Prices.TotalWithVat);
            Assert.AreEqual(218m, getModel.Prices.TotalWithVatHc);
            Assert.AreEqual(-24.2m, getModel.Prices.TotalDiscountAmount);
            Assert.AreEqual(242m, getModel.Prices.TotalWithoutDiscount);

            Assert.GreaterOrEqual(getModel.Items.Count, 1);
            ComparePostAndGetRecountItemModels(postModel.Items.First(), getModel.Items.First(i => i.ItemType == IssuedInvoiceItemType.ItemTypeNormal));

            Assert.AreEqual(2, getModel.Prices.VatRateSummary.Count);
            CheckRecountVatRateSummary(getModel.Prices.VatRateSummary.First());
        }

        private static void ComparePostAndGetRecountItemModels(CreditNoteItemRecountPostModel postModel, CreditNoteItemRecountGetModel getModel)
        {
            Assert.AreEqual(postModel.Amount, getModel.Amount);
            Assert.AreEqual(postModel.DiscountPercentage, getModel.DiscountPercentage);
            Assert.AreEqual(postModel.Id, getModel.Id);
            Assert.AreEqual(postModel.Name, getModel.Name);
            Assert.AreEqual(37.8m, getModel.Prices.TotalVat);
            Assert.AreEqual(37.8m, getModel.Prices.TotalVatHc);
            Assert.AreEqual(180m, getModel.Prices.TotalWithoutVat);
            Assert.AreEqual(180m, getModel.Prices.TotalWithoutVatHc);
            Assert.AreEqual(217.8m, getModel.Prices.TotalWithVat);
            Assert.AreEqual(217.8m, getModel.Prices.TotalWithVatHc);
            Assert.AreEqual(postModel.PriceType, getModel.PriceType);
            Assert.AreEqual(postModel.VatRateType, getModel.VatRateType);
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
            Assert.IsNotEmpty(creditNote.AccountNumber);
            Assert.IsNotNull(creditNote.ConstantSymbolId);
            Assert.AreEqual(_creditedIssuedInvoiceId, creditNote.CreditedInvoiceId, 0);
            Assert.IsEmpty(creditNote.CreditNoteReason);
            Assert.Greater(creditNote.CurrencyId, 0);
            Assert.IsNotNull(creditNote.DateOfIssue);
            Assert.IsNotNull(creditNote.DateOfMaturity);
            Assert.IsNotNull(creditNote.DateOfPayment);
            Assert.IsNotNull(creditNote.DateOfTaxing);
            Assert.IsNotNull(creditNote.DateOfVatApplication);
            Assert.IsNull(creditNote.DateOfVatClaim);
            Assert.IsNotEmpty(creditNote.Description);
            Assert.Greater(creditNote.DocumentSerialNumber, 0);
            Assert.AreEqual(1, creditNote.ExchangeRate);
            Assert.AreEqual(1, creditNote.ExchangeRateAmount);
            Assert.Greater(creditNote.Items.Count, 0);

            foreach (var creditNoteItem in creditNote.Items)
            {
                AssertDefaultItem(creditNoteItem);
            }

            Assert.IsEmpty(creditNote.ItemsTextPrefix);
            Assert.IsEmpty(creditNote.ItemsTextSuffix);
            Assert.IsEmpty(creditNote.Note);
            Assert.IsEmpty(creditNote.NoteForCreditNote);
            Assert.Greater(creditNote.NumericSequenceId, 0);
            Assert.Greater(creditNote.PartnerId, 0);
            Assert.IsNotNull(creditNote.ReportLanguage);
            Assert.IsNotEmpty(creditNote.VariableSymbol);
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
                //CurrencyId = _creditNotePostModel.CurrencyId,
                CurrencyId = 1,
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
