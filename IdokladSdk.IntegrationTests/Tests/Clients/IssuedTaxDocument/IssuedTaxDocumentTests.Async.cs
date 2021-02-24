using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.IssuedTaxDocument.Patch;
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
        [Order(6)]
        public async Task PostAsync_SuccessfullyCreated()
        {
            // Act
            var result = (await _issuedTaxDocumentClient.PostAsync(PaymentId)).AssertResult();
            _issuedTaxDocumentIdAsync = result.Id;
            _issuedTaxDocumentItemIdAsync = result.Items.FirstOrDefault().Id;

            // Assert
            Assert.AreEqual(1043167, result.ProformaInvoiceId);
            Assert.AreEqual(1000, result.Prices.TotalWithVatHc);
        }

        [Test]
        [Order(7)]
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
            Assert.AreEqual(dateOfIssue, result.DateOfIssue);
            Assert.GreaterOrEqual(result.Items.Count, 0);
            Assert.AreEqual("TestModel", result.Items[0].Name);
        }

        [Test]
        [Order(8)]
        public async Task DeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = (await _issuedTaxDocumentClient.DeleteAsync(_issuedTaxDocumentIdAsync)).AssertResult();

            // Assert
            Assert.IsTrue(data);
        }
    }
}
