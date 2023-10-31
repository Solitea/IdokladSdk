using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Core.Helpers;
using IdokladSdk.Models.IssuedDocumentPayment;
using IdokladSdk.Models.IssuedTaxDocument.Patch;
using IdokladSdk.Models.IssuedTaxDocument.Post;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.IssuedTaxDocument
{
    /// <summary>
    /// IssuedTaxDocumentTests.
    /// </summary>
    [TestFixture]
    public class IssuedTaxDocumentTests : TestBase
    {
        private const int PaymentIdForDefault = 1981104;
        private int _issuedTaxDocumentItemId;
        private int _issuedTaxDocumentId;
        private IssuedTaxDocumentClient _issuedTaxDocumentClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _issuedTaxDocumentClient = DokladApi.IssuedTaxDocumentClient;
        }

        [Test]
        public async Task GetDefaultAsync_SucessfullyReturnedAsync()
        {
            // Act
            var data = await _issuedTaxDocumentClient.DefaultAsync(PaymentIdForDefault).AssertResult();

            // Assert
            Assert.That(data.Prices.TotalWithVatHc, Is.EqualTo(1000m));
        }

        [Test]
        public async Task PostAsync_SucessfullyCreatedFromDefaultAsync()
        {
            // Arrange
            var paymentId = (await GetDefaultProformaPayment()).Id;
            var defaultData = await _issuedTaxDocumentClient.DefaultAsync(paymentId).AssertResult();
            var postData = new IssuedTaxDocumentPostModel
            {
                DateOfIssue = defaultData.DateOfIssue,
                PaymentId = paymentId,
                Items = defaultData.Items.Select(x => new IssuedTaxDocumentItemPostModel
                {
                    Id = x.Id,
                    Name = "test",
                    VatCodeId = x.VatCodeId
                }).ToList()
            };

            // Act
            var result = await _issuedTaxDocumentClient.PostAsync(postData).AssertResult();

            // Assert
            Assert.That(result.PaymentId, Is.EqualTo(paymentId));
            Assert.That(result.DateOfIssue, Is.EqualTo(defaultData.DateOfIssue));
            Assert.That(result.Items.Count, Is.EqualTo(postData.Items.Count));

            // Teardown
            await _issuedTaxDocumentClient.DeleteAsync(result.Id).AssertResult();
        }

        [Test]
        [Order(1)]
        public async Task GetListAsync_SuccessfullyReturned()
        {
            // Act
            var data = await _issuedTaxDocumentClient.List().Sort(x => x.DateOfIssue.Desc()).GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
        }

        [Test]
        [Order(2)]
        public async Task GetList_WithAccountByInvoiceSimpleFilter_SuccessfullyReturned()
        {
            // Act
            var allDocuments = await _issuedTaxDocumentClient.List().GetAsync().AssertResult();
            var accounted = await _issuedTaxDocumentClient.List().Filter(i => i.AccountedByInvoiceId.IsNotEqual(null)).GetAsync().AssertResult();
            var notAccounted = await _issuedTaxDocumentClient.List().Filter(i => i.AccountedByInvoiceId.IsEqual(null)).GetAsync().AssertResult();

            // Assert
            Assert.That(allDocuments.Items.Count(i => i.AccountedByInvoiceId != null), Is.EqualTo(accounted.TotalItems));
            Assert.That(allDocuments.Items.Count(i => i.AccountedByInvoiceId == null), Is.EqualTo(notAccounted.TotalItems));
        }

        [Test]
        [Order(3)]
        public async Task GetList_WithAccountByInvoiceComplexFilter_SuccessfullyReturned()
        {
            // Act
            var data = await _issuedTaxDocumentClient.List().Filter(i => i.AccountedByInvoiceId.IsEqual(null) && i.Id.IsNotEqual(0)).GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
        }

        [Test]
        [Order(4)]
        public async Task PostAsync_SuccessfullyCreated()
        {
            // Act
            var payment = await GetDefaultProformaPayment();
            var paymentId = payment.Id;
            var result = await _issuedTaxDocumentClient.PostAsync(paymentId).AssertResult();
            _issuedTaxDocumentId = result.Id;
            _issuedTaxDocumentItemId = result.Items.FirstOrDefault().Id;

            // Assert
            Assert.That(result.ProformaInvoiceId, Is.EqualTo(payment.InvoiceId));
            Assert.That(result.Prices.TotalWithVatHc, Is.EqualTo(1000));
        }

        [Test]
        [Order(5)]
        public async Task UpdateAsync_SuccessfullyUpdate()
        {
            var dateOfIssue = new DateTime(2020, 10, 12).SetKindUtc();
            var model = new IssuedTaxDocumentPatchModel
            {
                Id = _issuedTaxDocumentId,
                DateOfIssue = dateOfIssue,
                Items = new List<IssuedTaxDocumentItemPatchModel>()
            {
                new IssuedTaxDocumentItemPatchModel
                {
                    Id = _issuedTaxDocumentItemId,
                    Name = "TestModel",
                }
            }
            };

            // Act
            var result = await _issuedTaxDocumentClient.UpdateAsync(model).AssertResult();

            // Assert
            Assert.That(result.DateOfIssue, Is.EqualTo(dateOfIssue));
            Assert.That(result.Items.Count, Is.GreaterThanOrEqualTo(0));
            Assert.That(result.Items[0].Name, Is.EqualTo("TestModel"));
        }

        [Test]
        [Order(6)]
        public async Task Get_Expand_SuccessfullyGet()
        {
            // Act
            var data = await _issuedTaxDocumentClient.Detail(_issuedTaxDocumentId)
                .Include(s => s.Payment).GetAsync().AssertResult();

            Assert.That(data.Id, Is.EqualTo(_issuedTaxDocumentId));
            Assert.That(data.Payment, Is.Not.Null);
        }

        [Test]
        [Order(7)]
        public async Task GetAsync_SuccessfullyGet()
        {
            // Act
            var data = await _issuedTaxDocumentClient.Detail(_issuedTaxDocumentId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(_issuedTaxDocumentId));
        }

        [Test]
        [Order(8)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = await _issuedTaxDocumentClient.DeleteAsync(_issuedTaxDocumentId).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }

        private async Task<IssuedDocumentPaymentListGetModel> GetDefaultProformaPayment()
        {
            var proforma = await DokladSdkTestsHelper.CreateDefaultProformaInvoiceAsync(DokladApi);
            var payments = await DokladApi.IssuedDocumentPaymentClient.List().Filter(i => i.InvoiceId.IsEqual(proforma.Id))
                .GetAsync().AssertResult();
            return payments.Items.FirstOrDefault();
        }
    }
}
