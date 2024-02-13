using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.RecurringInvoice;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.RecurringInvoice
{
    [TestFixture]
    public class RecurringInvoiceTests : TestBase
    {
        private const int DeliveryAddressId1 = 11;
        private const int PartnerId = 323823;
        private const int PriceListItemId = 107444;
        private const string PartnerName = "Alza.cz a.s.";

        private int? _issuedInvoiceId;
        private int _recurringInvoiceId;
        private int? _recurringInvoiceItemId;

        public IssuedInvoiceClient IssuedInvoiceClient { get; set; }

        public ProformaInvoiceClient ProformaInvoiceClient { get; set; }

        public RecurringInvoiceClient RecurringInvoiceClient { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            IssuedInvoiceClient = DokladApi.IssuedInvoiceClient;
            ProformaInvoiceClient = DokladApi.ProformaInvoiceClient;
            RecurringInvoiceClient = DokladApi.RecurringInvoiceClient;
        }

        [SetUp]
        public void SetUp()
        {
            _issuedInvoiceId = null;
        }

        [TearDown]
        public async Task TearDown()
        {
            if (_issuedInvoiceId.HasValue)
            {
                await IssuedInvoiceClient.DeleteAsync(_issuedInvoiceId.Value);
            }
        }

        [Test]
        [Order(1)]
        public async Task PostAsync_SuccessfullyCreated()
        {
            // Arrange
            var model = await CreatePostModelAsync();

            // Act
            var data = await RecurringInvoiceClient.PostAsync(model).AssertResult();
            _recurringInvoiceId = data.Id;
            _recurringInvoiceItemId = data.InvoiceTemplate?.Items?.First()?.Id;
            _issuedInvoiceId = data.CreatedInvoice?.Id;

            // Assert
            AssertResultGetModel(data);
        }

        [Test]
        [Order(2)]
        public async Task GetDetailAsync_ReturnsRecurringInvoice()
        {
            // Act
            var data = await RecurringInvoiceClient.Detail(_recurringInvoiceId).GetAsync().AssertResult();

            // Assert
            AssertGetModel(data);
        }

        [Test]
        [Order(3)]
        public async Task GetDetailAsync_Expand_ReturnsRecurringInvoice()
        {
            // Act
            var data = await RecurringInvoiceClient.Detail(_recurringInvoiceId)
                .Include(i => i.InvoiceTemplate.ConstantSymbol)
                .Include(i => i.InvoiceTemplate.Currency)
                .Include(i => i.InvoiceTemplate.Partner)
                .Include(i => i.InvoiceTemplate.PaymentOption)
                .Include(i => i.InvoiceTemplate.VatReverseChargeCode)
                .Include(i => i.InvoiceTemplate.Items.PriceListItem)
                .GetAsync()
                .AssertResult();

            // Assert
            AssertGetModel(data);
            AssertExpand(data);
        }

        [Test]
        [Order(4)]
        public async Task UpdateAsync_SuccessfullyUpdated()
        {
            // Arrange
            var model = CreatePatchModel();

            // Act
            var data = await RecurringInvoiceClient.UpdateAsync(model).AssertResult();

            // Assert
            AssertGetModel(data);
        }

        [Test]
        [Order(5)]
        public async Task GetListAsync_ReturnsList()
        {
            // Act
            var data = await RecurringInvoiceClient.List().GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
            Assert.That(data.Items, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        [Order(6)]
        public async Task GetListAsync_WithFilter_ReturnsList()
        {
            // Act
            var data = await RecurringInvoiceClient.List()
                .Filter(i => i.CompanyName.IsEqual(PartnerName)
                            && i.Id.IsEqual(_recurringInvoiceId))
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
            Assert.That(data.Items, Is.Not.Null.And.Not.Empty);
            AssertListGetModel(data.Items.FirstOrDefault());
        }

        [Test]
        [Order(7)]
        public async Task GetRecurringInvoiceCopyAsync_SuccessfullyGot()
        {
            // Act
            var data = await RecurringInvoiceClient.CopyAsync(_recurringInvoiceId).AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.InvoiceTemplate.PartnerId, Is.EqualTo(PartnerId));
        }

        [Test]
        [Order(8)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = await RecurringInvoiceClient.DeleteAsync(_recurringInvoiceId).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }

        [Test]
        [Order(9)]
        public async Task NextIssueDateAsync_ReturnsCorrectValue()
        {
            // Arrange
            var model = CreateNextIssueDatesPostModel();

            // Act
            var data = await RecurringInvoiceClient.NextIssueDatesAsync(model).AssertResult();

            // Assert
            AssertNextIssueData(data);
        }

        [Test]
        [Order(10)]
        public async Task RecountAsync_SuccessfullyRecounted()
        {
            // Arrange
            var model = CreateRecountPostModel();

            // Act
            var data = await RecurringInvoiceClient.RecountAsync(model).AssertResult();

            // Assert
            AssertRecountData(model, data);
        }

        private void AssertGetModel(RecurringInvoiceGetModel data)
        {
            AssertInvoiceTemplate(data.InvoiceTemplate);
            AssertInvoiceItemsTemplate(data.InvoiceTemplate.Items);
            AssertRecurringSetting(data.RecurringSetting);
        }

        private void AssertListGetModel(RecurringInvoiceListGetModel data)
        {
            AssertInvoiceTemplate(data.InvoiceTemplate);
            AssertInvoiceItemsTemplate(data.InvoiceTemplate.Items);
            AssertRecurringSetting(data.RecurringSetting);
        }

        private void AssertResultGetModel(RecurringInvoiceResultGetModel data)
        {
            Assert.That(data.Id, Is.GreaterThan(0));
            Assert.That(data.CreatedInvoice, Is.Not.Null);
            Assert.That(data.CreatedInvoice.Id, Is.GreaterThan(0));
            AssertGetModel((RecurringInvoiceGetModel)data);
        }

        private void AssertExpand(RecurringInvoiceGetModel data)
        {
            Assert.That(data.InvoiceTemplate.ConstantSymbol, Is.Not.Null);
            Assert.That(data.InvoiceTemplate.Currency, Is.Not.Null);
            Assert.That(data.InvoiceTemplate.Partner, Is.Not.Null);
            Assert.That(data.InvoiceTemplate.PaymentOption, Is.Not.Null);
            Assert.That(data.InvoiceTemplate.VatReverseChargeCode, Is.Null);
            Assert.That(data.InvoiceTemplate.Items.First().PriceListItem, Is.Not.Null);
        }

        private void AssertInvoiceItemsTemplate(IEnumerable<InvoiceItemTemplateListGetModel> invoiceItemsTemplate)
        {
            Assert.That(invoiceItemsTemplate, Is.Not.Null.And.Not.Empty);
            var item = invoiceItemsTemplate.First();
            Assert.That(item.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(item.Prices, Is.Not.Null);
            Assert.That(item.PriceListItemId, Is.GreaterThan(0));
            Assert.That(item.Unit, Is.Not.Null);
        }

        private void AssertInvoiceTemplate(InvoiceTemplateListGetModel invoiceTemplate)
        {
            Assert.That(invoiceTemplate, Is.Not.Null);
            Assert.That(invoiceTemplate.BankAccountId, Is.GreaterThan(0));
            Assert.That(invoiceTemplate.CurrencyId, Is.GreaterThan(0));
            Assert.That(invoiceTemplate.Description, Is.Not.Null.And.Not.Empty);
            //Assert.That(invoiceTemplate.DeliveryAddress, Is.Not.Null);
            //Assert.That(invoiceTemplate.DeliveryAddress.ContactDeliveryAddressId, Is.GreaterThan(0));
            Assert.That(invoiceTemplate.InvoiceMaturity, Is.GreaterThan(0));
            Assert.That(invoiceTemplate.ItemsTextPrefix, Is.Not.Null);
            Assert.That(invoiceTemplate.ItemsTextSuffix, Is.Not.Null);
            Assert.That(invoiceTemplate.Note, Is.Not.Null);
            Assert.That(invoiceTemplate.NumericSequenceId, Is.GreaterThan(0));
            //Assert.That(invoiceTemplate.PartnerId, Is.GreaterThan(0));
            Assert.That(invoiceTemplate.PaymentOptionId, Is.GreaterThan(0));
            Assert.That(invoiceTemplate.VariableSymbol, Is.Not.Null);
            Assert.That(invoiceTemplate.ReportLanguage, Is.Not.Null);
        }

        private void AssertNextIssueData(NextIssueDatesGetModel data)
        {
            Assert.That(data.NextIssueDates, Is.Not.Null);
            Assert.That(data.NextIssueDates.Count, Is.GreaterThan(1));
            var firstIssue = data.NextIssueDates.First();
            Assert.That(firstIssue, Is.EqualTo(new DateTime(2020, 12, 31)));
        }

        private void AssertRecountData(InvoiceTemplateRecountPostModel model, InvoiceTemplateRecountGetModel data)
        {
            var itemToRecount = model.Items.First();
            var recountedItem = data.Items.First(x => x.ItemType == RecurringInvoiceItemGetType.ItemTypeNormal);
            Assert.That(recountedItem.Id, Is.EqualTo(itemToRecount.Id));
            Assert.That(recountedItem.Name, Is.EqualTo(itemToRecount.Name));
            Assert.That(recountedItem.Prices.TotalWithVat, Is.EqualTo(242));
            Assert.That(recountedItem.Prices.TotalWithVatHc, Is.EqualTo(242));
            Assert.That(recountedItem.Prices.TotalVat, Is.EqualTo(42));
            Assert.That(recountedItem.Prices.TotalVatHc, Is.EqualTo(42));
            Assert.That(recountedItem.Prices.TotalWithoutVat, Is.EqualTo(200));
            Assert.That(recountedItem.Prices.TotalWithoutVatHc, Is.EqualTo(200));
        }

        private void AssertRecurringSetting(RecurringSettingListGetModel recurringSetting)
        {
            Assert.That(recurringSetting, Is.Not.Null);
            Assert.That(recurringSetting.CopyCountActual, Is.EqualTo(1));
            Assert.That(recurringSetting.CopyCountActual, Is.EqualTo(1));
            Assert.That(recurringSetting.DateOfEnd, Is.Null);
            Assert.That(recurringSetting.DateOfLastIssue, Is.Not.Null);
            Assert.That(recurringSetting.DateOfLastActivation, Is.Not.Null);
            Assert.That(recurringSetting.DateOfStart, Is.Not.Null);
            Assert.That(recurringSetting.TemplateName, Is.Not.Null.And.Not.Empty);
        }

        private NextIssueDatesPostModel CreateNextIssueDatesPostModel()
        {
            return new NextIssueDatesPostModel
            {
                CopyCountActual = null,
                CopyCountEnd = null,
                DateOfEnd = null,
                DateOfLastActivation = new DateTime(1753, 1, 1).SetKindUtc(),
                DateOfLastIssue = new DateTime(1753, 1, 1).SetKindUtc(),
                DateOfStart = new DateTime(2020, 12, 31).SetKindUtc(),
                IssueLastDayOfMonth = true,
                RecurrenceCount = 1,
                RecurrenceType = RecurrenceType.Months,
                TypeOfEnd = RecurrenceTypeOfEnd.Never
            };
        }

        private RecurringInvoicePatchModel CreatePatchModel()
        {
            return new RecurringInvoicePatchModel
            {
                Id = _recurringInvoiceId,
                InvoiceTemplate = new InvoiceTemplatePatchModel
                {
                    Description = "New description",
                    Items = new List<InvoiceItemTemplatePatchModel>
                {
                    new InvoiceItemTemplatePatchModel
                    {
                        Id = _recurringInvoiceItemId ?? 0,
                        Name = "Modified item"
                    }
                }
                },
                RecurringSetting = new RecurringSettingPatchModel
                {
                    RecurrenceCount = 1,
                    TemplateName = "Modified template name"
                }
            };
        }

        private async Task<RecurringInvoicePostModel> CreatePostModelAsync()
        {
            var model = await RecurringInvoiceClient.DefaultAsync().AssertResult();
            model.InvoiceTemplate.Description = "Some description";
            model.InvoiceTemplate.DocumentType = RecurringDocumentType.IssuedInvoice;
            model.InvoiceTemplate.PartnerId = PartnerId;
            model.InvoiceTemplate.DeliveryAddressId = DeliveryAddressId1;
            var item = model.InvoiceTemplate.Items.First();
            item.Name = "Some item";
            item.PriceListItemId = PriceListItemId;
            model.RecurringSetting.TemplateName = "Recurring invoice template";
            return model;
        }

        private InvoiceTemplateRecountPostModel CreateRecountPostModel()
        {
            return new InvoiceTemplateRecountPostModel
            {
                CurrencyId = 1,
                Items = new List<InvoiceItemTemplateRecountPostModel>
            {
                new InvoiceItemTemplateRecountPostModel
                {
                    Amount = 2,
                    Id = 1,
                    Name = "Test",
                    PriceType = PriceType.WithoutVat,
                    UnitPrice = 100,
                    VatRateType = VatRateType.Basic
                }
            },
                PaymentOptionId = 1
            };
        }
    }
}
