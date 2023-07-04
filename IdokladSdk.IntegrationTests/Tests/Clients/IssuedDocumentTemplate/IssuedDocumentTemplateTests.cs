using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doklad.Shared.Enums.Api;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.IssuedDocumentTemplate.Patch;
using IdokladSdk.Models.IssuedDocumentTemplate.Post;
using IdokladSdk.Models.IssuedDocumentTemplate.Recount;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.IssuedDocumentTemplate
{
    [TestFixture]
    public class IssuedDocumentTemplateTests : TestBase
    {
        private const int DeliveryAddressId1 = 11;
        private const int PartnerId = 323823;
        private const int PriceListItemId = 107444;
        private const string PartnerName = "Alza.cz a.s.";
        private int _createdId;

        public IssuedDocumentTemplateClient IssuedDocumentTemplateClient { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            IssuedDocumentTemplateClient = DokladApi.IssuedDocumentTemplateClient;
        }

        [OneTimeTearDown]
        public async Task TearDown()
        {
            if (_createdId > 0)
            {
                await IssuedDocumentTemplateClient.DeleteAsync(_createdId);
            }
        }

        [Test]
        [Order(1)]

        public async Task DefaultAsync_SuccessfullyCreated()
        {
            // Act
            var data = await IssuedDocumentTemplateClient.DefaultAsync().AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.DocumentType, Is.EqualTo(IssuedDocumentTemplateType.IssuedInvoice));
        }

        [Test]
        [Order(2)]
        public async Task PostAsync_SuccessfullyCreated()
        {
            // Arrange
            var model = await CreatePostModelAsync();

            // Act
            var data = await IssuedDocumentTemplateClient.PostAsync(model).AssertResult();
            _createdId = data.Id;

            // Assert
            Assert.That(data.Id, Is.GreaterThan(0));
            Assert.That(data.DocumentType, Is.EqualTo(model.DocumentType));
            Assert.That(data.CurrencyId, Is.EqualTo(model.CurrencyId));
            Assert.That(data.BankAccountId, Is.EqualTo(model.BankAccountId));
            Assert.That(data.ConstantSymbolId, Is.EqualTo(model.ConstantSymbolId));
            Assert.That(data.DeliveryAddressId, Is.EqualTo(model.DeliveryAddressId));
            Assert.That(data.PartnerId, Is.EqualTo(model.PartnerId));
            Assert.That(data.PaymentOptionId, Is.EqualTo(model.PaymentOptionId));
            Assert.That(data.NumericSequenceId, Is.EqualTo(model.NumericSequenceId));
            Assert.That(data.VatReverseChargeCodeId, Is.EqualTo(model.VatReverseChargeCodeId));
            Assert.That(data.Items, Is.Not.Null);
        }

        [Test]
        [Order(3)]
        public async Task GetAsync_SuccessfullyCreated()
        {
            // Arrange
            var model = await CreatePostModelAsync();

            // Act
            var data = await IssuedDocumentTemplateClient.Detail(_createdId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.GreaterThan(0));
            Assert.That(data.DocumentType, Is.EqualTo(model.DocumentType));
            Assert.That(data.CurrencyId, Is.EqualTo(model.CurrencyId));
            Assert.That(data.BankAccountId, Is.EqualTo(model.BankAccountId));
            Assert.That(data.ConstantSymbolId, Is.EqualTo(model.ConstantSymbolId));
            Assert.That(data.DeliveryAddressId, Is.EqualTo(model.DeliveryAddressId));
            Assert.That(data.PartnerId, Is.EqualTo(model.PartnerId));
            Assert.That(data.PaymentOptionId, Is.EqualTo(model.PaymentOptionId));
            Assert.That(data.NumericSequenceId, Is.EqualTo(model.NumericSequenceId));
            Assert.That(data.VatReverseChargeCodeId, Is.EqualTo(model.VatReverseChargeCodeId));
            Assert.That(data.Items, Is.Not.Null);
        }

        [Test]
        [Order(4)]
        public async Task GetDetailAsync_Expand_ReturnsRecurringInvoice()
        {
            // Act
            var data = await IssuedDocumentTemplateClient.Detail(_createdId)
                .Include(i => i.BankAccount)
                .Include(i => i.ConstantSymbol)
                .Include(i => i.Currency)
                .Include(i => i.PaymentOption)
                .Include(i => i.VatReverseChargeCode)
                .Include(i => i.NumericSequence)
                .Include(i => i.Items.PriceListItem)
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.BankAccount, Is.Not.Null);
            Assert.That(data.ConstantSymbol, Is.Not.Null);
            Assert.That(data.Currency, Is.Not.Null);
            Assert.That(data.PaymentOption, Is.Not.Null);
            Assert.That(data.NumericSequence, Is.Not.Null);
            Assert.That(data.VatReverseChargeCode, Is.Null);
            // Assert.That(data.Items.First().PriceListItem, Is.Not.Null);
        }

        [Test]
        [Order(5)]
        public async Task UpdateAsync_SuccessfullyUpdated()
        {
            // Arrange
            var model = CreatePatchModel();

            // Act
            var data = await IssuedDocumentTemplateClient.UpdateAsync(model).AssertResult();

            // Assert
            Assert.That(data.Description, Is.EqualTo(model.Description));
            Assert.That(data.Items.Count, Is.EqualTo(1));
            Assert.That(data.Items.First().Name, Is.EqualTo(model.Items.First().Name));
        }

        [Test]
        [Order(6)]
        public async Task GetListAsync_ReturnsList()
        {
            // Act
            var data = await IssuedDocumentTemplateClient.List().GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
            Assert.That(data.Items, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        [Order(7)]
        public async Task GetListAsync_WithFilter_ReturnsList()
        {
            // Act
            var data = await IssuedDocumentTemplateClient.List()
                .Filter(i => i.CompanyName.IsEqual(PartnerName))
                .Filter(i => i.Id.IsEqual(_createdId))
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
            Assert.That(data.Items, Is.Not.Null.And.Not.Empty);
            var invoiceTemplate = data.Items.First();
            Assert.That(invoiceTemplate, Is.Not.Null);
            Assert.That(invoiceTemplate.BankAccountId, Is.GreaterThan(0));
            Assert.That(invoiceTemplate.CurrencyId, Is.GreaterThan(0));
            Assert.That(invoiceTemplate.Description, Is.Not.Null.And.Not.Empty);
            Assert.That(invoiceTemplate.DeliveryAddressId, Is.GreaterThan(0));
            Assert.That(invoiceTemplate.InvoiceMaturity, Is.GreaterThan(0));
            Assert.That(invoiceTemplate.ItemsTextPrefix, Is.Not.Null);
            Assert.That(invoiceTemplate.ItemsTextSuffix, Is.Not.Null);
            Assert.That(invoiceTemplate.NumericSequenceId, Is.GreaterThan(0));
            Assert.That(invoiceTemplate.PartnerId, Is.GreaterThan(0));
            Assert.That(invoiceTemplate.PaymentOptionId, Is.GreaterThan(0));
            Assert.That(invoiceTemplate.VariableSymbol, Is.Not.Null);
            Assert.That(invoiceTemplate.ReportLanguage, Is.Not.Null);
        }

        [Test]
        [Order(8)]
        public async Task GetRecurringInvoiceCopyAsync_SuccessfullyGot()
        {
            // Act
            var data = await IssuedDocumentTemplateClient.CopyAsync(_createdId).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.AreEqual(PartnerId, data.PartnerId);
        }

        [Test]
        [Order(9)]
        public async Task RecountAsync_SuccessfullyRecounted()
        {
            // Arrange
            var model = CreateRecountPostModel();

            // Act
            var data = await IssuedDocumentTemplateClient.RecountAsync(model).AssertResult();

            // Assert
            var itemToRecount = model.Items.First();
            var recountedItem = data.Items.First(x => x.ItemType == IssuedInvoiceItemType.ItemTypeNormal);
            Assert.That(recountedItem.Id, Is.EqualTo(itemToRecount.Id));
            Assert.That(recountedItem.Name, Is.EqualTo(itemToRecount.Name));
            Assert.That(recountedItem.Prices.TotalWithVat, Is.EqualTo(242));
            Assert.That(recountedItem.Prices.TotalWithVatHc, Is.EqualTo(242));
            Assert.That(recountedItem.Prices.TotalVat, Is.EqualTo(42));
            Assert.That(recountedItem.Prices.TotalVatHc, Is.EqualTo(42));
            Assert.That(recountedItem.Prices.TotalWithoutVat, Is.EqualTo(200));
            Assert.That(recountedItem.Prices.TotalWithoutVatHc, Is.EqualTo(200));
        }

        [Test]
        [Order(10)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = await IssuedDocumentTemplateClient.DeleteAsync(_createdId).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }

        private IssuedDocumentTemplatePatchModel CreatePatchModel()
        {
            return new IssuedDocumentTemplatePatchModel
            {
                Id = _createdId,
                Description = "New description",
                Items = new List<IssuedDocumentTemplateItemPatchModel>
                    {
                        new IssuedDocumentTemplateItemPatchModel
                        {
                            Name = "added item",
                            ItemType = PostIssuedInvoiceItemType.ItemTypeNormal
                        }
                    }
            };
        }

        private async Task<IssuedDocumentTemplatePostModel> CreatePostModelAsync()
        {
            var model = await IssuedDocumentTemplateClient.DefaultAsync().AssertResult();
            model.Description = "Some description";
            model.DocumentType = IssuedDocumentTemplateType.IssuedInvoice;
            model.PartnerId = PartnerId;
            model.DeliveryAddressId = DeliveryAddressId1;
            var item = model.Items.First();
            item.Name = "Some item";
            item.PriceListItemId = PriceListItemId;
            model.Name = "Template";
            model.ValidityDays = null;
            return model;
        }

        private IssuedDocumentTemplateRecountPostModel CreateRecountPostModel()
        {
            return new IssuedDocumentTemplateRecountPostModel
            {
                CurrencyId = 1,
                Items = new List<IssuedDocumentTemplateItemRecountPostModel>
                {
                    new IssuedDocumentTemplateItemRecountPostModel
                    {
                        Amount = 2,
                        Id = 1,
                        Name = "Test",
                        UnitPrice = 100,
                        VatRateType = VatRateType.Basic,
                        PriceType = PriceType.WithoutVat,
                    }
                },
                PaymentOptionId = 1
            };
        }
    }
}
