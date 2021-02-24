using System;
using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.IssuedTaxDocument.Patch;
using IdokladSdk.Requests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.IssuedTaxDocument
{
    /// <summary>
    /// IssuedTaxDocumentTests.
    /// </summary>
    [TestFixture]
    public partial class IssuedTaxDocumentTests : TestBase
    {
        private const int PaymentId = 1981104;
        private const int ProformaInvoiceId = 1043167;
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
        [Order(1)]
        public void GetList_SuccessfullyReturned()
        {
            // Act
            var data = _issuedTaxDocumentClient.List().Get().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
        }

        [Test]
        [Order(2)]
        public void Post_SuccessfullyCreated()
        {
            // Act
            var result = _issuedTaxDocumentClient.Post(PaymentId).AssertResult();
            _issuedTaxDocumentId = result.Id;
            _issuedTaxDocumentItemId = result.Items.FirstOrDefault().Id;

            // Assert
            Assert.That(result.ProformaInvoiceId, Is.EqualTo(ProformaInvoiceId));
            Assert.That(result.Prices.TotalWithVatHc, Is.EqualTo(1000));
        }

        [Test]
        [Order(3)]
        public void Update_SuccessfullyUpdated()
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
            var result = _issuedTaxDocumentClient.Update(model).AssertResult();

            // Assert
            Assert.That(result.DateOfIssue, Is.EqualTo(dateOfIssue));
            Assert.That(result.Items.Count, Is.GreaterThanOrEqualTo(0));
            Assert.That(result.Items[0].Name, Is.EqualTo("TestModel"));
        }

        [Test]
        [Order(4)]
        public void Get_Expand_SuccessfullyGet()
        {
            // Act
            var data = _issuedTaxDocumentClient.Detail(_issuedTaxDocumentId)
                .Include(s => s.Payment).Get().AssertResult();

            Assert.That(data.Id, Is.EqualTo(_issuedTaxDocumentId));
            Assert.That(data.Payment, Is.Not.Null);
        }

        [Test]
        [Order(5)]
        public void Delete_SuccessfullyDeleted()
        {
            // Act
            var data = _issuedTaxDocumentClient.Delete(_issuedTaxDocumentId).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }
    }
}
