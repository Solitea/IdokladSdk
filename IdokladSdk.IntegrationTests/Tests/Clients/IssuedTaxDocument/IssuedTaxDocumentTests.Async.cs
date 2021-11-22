using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.IssuedTaxDocument.Patch;
using IdokladSdk.Models.IssuedTaxDocument.Post;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.IssuedTaxDocument
{
    [TestFixture]
    public partial class IssuedTaxDocumentTests
    {
        private int _issuedTaxDocumentIdAsync;
        private int _issuedTaxDocumentItemIdAsync;

        [Test]
        public async Task GetDefaultAsync_SucessfullyReturnedAsync()
        {
            // Act
            var data = (await _issuedTaxDocumentClient.DefaultAsync(PaymentIdForDefault)).AssertResult();

            // Assert
            Assert.That(data.Prices.TotalWithVatHc, Is.EqualTo(1000m));
        }

        [Test]
        public async Task PostAsync_SucessfullyCreatedFromDefaultAsync()
        {
            // Arrange
            var defaultData = (await _issuedTaxDocumentClient.DefaultAsync(PaymentIdForDefault)).AssertResult();
            var postData = new IssuedTaxDocumentPostModel
            {
                DateOfIssue = defaultData.DateOfIssue,
                PaymentId = PaymentIdForDefault,
                Items = defaultData.Items.Select(x => new IssuedTaxDocumentItemPostModel
                {
                    Id = x.Id,
                    Name = "test",
                    VatCodeId = x.VatCodeId
                }).ToList()
            };

            // Act
            var result = (await _issuedTaxDocumentClient.PostAsync(postData)).AssertResult();

            // Assert
            Assert.That(result.PaymentId, Is.EqualTo(PaymentIdForDefault));
            Assert.That(result.DateOfIssue, Is.EqualTo(defaultData.DateOfIssue));
            Assert.That(result.Items.Count, Is.EqualTo(postData.Items.Count));

            // Teardown
            (await _issuedTaxDocumentClient.DeleteAsync(result.Id)).AssertResult();
        }

        [Test]
        [Order(8)]
        public async Task PostAsync_SuccessfullyCreated()
        {
            // Act
            var result = (await _issuedTaxDocumentClient.PostAsync(PaymentId)).AssertResult();
            _issuedTaxDocumentIdAsync = result.Id;
            _issuedTaxDocumentItemIdAsync = result.Items.FirstOrDefault().Id;

            // Assert
            Assert.That(result.ProformaInvoiceId, Is.EqualTo(ProformaInvoiceId));
            Assert.That(result.Prices.TotalWithVatHc, Is.EqualTo(1000));
        }

        [Test]
        [Order(9)]
        public async Task UpdateAsync_SuccessfullyUpdate()
        {
            var dateOfIssue = new DateTime(2020, 10, 12).SetKindUtc();
            var model = new IssuedTaxDocumentPatchModel
            {
                Id = _issuedTaxDocumentIdAsync,
                DateOfIssue = dateOfIssue,
                Items = new List<IssuedTaxDocumentItemPatchModel>()
                {
                    new IssuedTaxDocumentItemPatchModel
                    {
                        Id = _issuedTaxDocumentItemIdAsync,
                        Name = "TestModel",
                    }
                }
            };

            // Act
            var result = (await _issuedTaxDocumentClient.UpdateAsync(model)).AssertResult();

            // Assert
            Assert.That(result.DateOfIssue, Is.EqualTo(dateOfIssue));
            Assert.That(result.Items.Count, Is.GreaterThanOrEqualTo(0));
            Assert.That(result.Items[0].Name, Is.EqualTo("TestModel"));
        }

        [Test]
        [Order(10)]
        public async Task GetAsync_SuccessfullyGet()
        {
            // Act
            var data = (await _issuedTaxDocumentClient.Detail(_issuedTaxDocumentIdAsync).GetAsync()).AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(_issuedTaxDocumentIdAsync));
        }

        [Test]
        [Order(11)]
        public async Task GetListAsync_SuccessfullyReturned()
        {
            // Act
            var data = (await _issuedTaxDocumentClient.List().Sort(x => x.DateOfIssue.Desc()).GetAsync()).AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
        }

        [Test]
        [Order(12)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = (await _issuedTaxDocumentClient.DeleteAsync(_issuedTaxDocumentIdAsync)).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }
    }
}
