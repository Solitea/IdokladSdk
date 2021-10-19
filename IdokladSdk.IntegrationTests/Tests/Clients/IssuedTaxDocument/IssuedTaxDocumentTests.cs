using System;
using System.Collections.Generic;
using System.Linq;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
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
    public partial class IssuedTaxDocumentTests : TestBase
    {
        private const int PaymentId = 1981104;
        private const int PaymentIdForDefault = 1984505;
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
        public void GetDefault_SucessfullyReturned()
        {
            // Act
            var data = _issuedTaxDocumentClient.Default(PaymentIdForDefault).AssertResult();

            // Assert
            Assert.That(data.Prices.TotalWithVatHc, Is.EqualTo(100));
        }

        [Test]
        public void Post_SucessfullyCreatedFromDefault()
        {
            // Arrange
            var defaultData = _issuedTaxDocumentClient.Default(PaymentIdForDefault).AssertResult();
            var postData = new IssuedTaxDocumentPostModel
            {
                DateOfIssue = defaultData.DateOfIssue,
                PaymentId = PaymentIdForDefault,
                Items = new List<IssuedTaxDocumentItemPostModel>()
            };

            foreach (var item in defaultData.Items)
            {
                postData.Items.Add(new IssuedTaxDocumentItemPostModel
                {
                    Name = "test",
                    PriceType = item.PriceType,
                    VatRate = item.VatRate,
                    VatCodeId = item.VatCodeId
                });
            }

            // Act
            var result = _issuedTaxDocumentClient.Post(postData).AssertResult();

            // Assert
            Assert.That(result.PaymentId, Is.EqualTo(PaymentIdForDefault));
            Assert.That(result.DateOfIssue, Is.EqualTo(defaultData.DateOfIssue));
            Assert.That(result.Items.Count, Is.EqualTo(postData.Items.Count));

            _issuedTaxDocumentClient.Delete(result.Id).AssertResult();
        }

        [Test]
        [Order(1)]
        public void GetList_SuccessfullyReturned()
        {
            // Act
            var data = _issuedTaxDocumentClient.List().Sort(x => x.DateOfIssue.Desc()).Get().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.TotalPages, Is.GreaterThan(0));
        }

        [Test]
        [Order(2)]
        public void GetList_WithAccountByInvoiceSimpleFilter_SuccessfullyReturned()
        {
            // Act
            var allDocuments = _issuedTaxDocumentClient.List().Get().AssertResult();
            var accounted = _issuedTaxDocumentClient.List().Filter(i => i.AccountedByInvoiceId.IsNotEqual(null)).Get().AssertResult();
            var notAccounted = _issuedTaxDocumentClient.List().Filter(i => i.AccountedByInvoiceId.IsEqual(null)).Get().AssertResult();

            // Assert
            Assert.That(allDocuments.Items.Count(i => i.AccountedByInvoiceId != null), Is.EqualTo(accounted.TotalItems));
            Assert.That(allDocuments.Items.Count(i => i.AccountedByInvoiceId == null), Is.EqualTo(notAccounted.TotalItems));
        }

        [Test]
        [Order(3)]
        public void GetList_WithAccountByInvoiceComplexFilter_SuccessfullyReturned()
        {
            // Act
            var data = _issuedTaxDocumentClient.List().Filter(i => i.AccountedByInvoiceId.IsEqual(null) && i.Id.IsNotEqual(0)).Get().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(0));
        }

        [Test]
        [Order(4)]
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
        [Order(5)]
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
        [Order(6)]
        public void Get_Expand_SuccessfullyGet()
        {
            // Act
            var data = _issuedTaxDocumentClient.Detail(_issuedTaxDocumentId)
                .Include(s => s.Payment).Get().AssertResult();

            Assert.That(data.Id, Is.EqualTo(_issuedTaxDocumentId));
            Assert.That(data.Payment, Is.Not.Null);
        }

        [Test]
        [Order(7)]
        public void Delete_SuccessfullyDeleted()
        {
            // Act
            var data = _issuedTaxDocumentClient.Delete(_issuedTaxDocumentId).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }
    }
}
