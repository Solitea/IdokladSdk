using System;
using System.Net;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.NumericSequence;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.NumericSequence
{
    [TestFixture]
    public class NumericSequenceTest : TestBase
    {
        private const int NumericSequenceId = 607899;
        private const int NumericSequenceYear = 2019;
        private const int NumericSequenceRegisterSaleId = 608046;
        private const int NumericSequenceRegisterSaleId2 = 608198;
        private NumericSequenceClient _numericSequenceClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _numericSequenceClient = DokladApi.NumericSequenceClient;
        }

        [Test]
        public async Task ListAsync_SuccessfullyGetList()
        {
            // Act
            var data = await _numericSequenceClient.List()
                .Filter(f => f.DocumentType.IsEqual(NumericSequenceDocumentType.IssuedInvoice)).GetAsync().AssertResult();

            // Assert
            Assert.AreEqual(data.TotalItems, 1);
        }

        [Test]
        public async Task DetailWithYearAsync_SuccessfullyGetDetail()
        {
            // Act
            var data = await _numericSequenceClient.Detail(NumericSequenceId, NumericSequenceYear).GetAsync().AssertResult();

            // Assert
            Assert.AreEqual(NumericSequenceDocumentType.IssuedInvoice, data.DocumentType);
            Assert.AreEqual(NumericSequenceYear, data.Year);
        }

        [Test]
        public async Task DetailWithoutYearAsync_SuccessfullyGetDetail()
        {
            // Act
            var data = await _numericSequenceClient.Detail(NumericSequenceId).GetAsync().AssertResult();

            // Assert
            Assert.AreEqual(NumericSequenceDocumentType.IssuedInvoice, data.DocumentType);
            Assert.AreNotEqual(NumericSequenceYear, data.Year);
        }

        [Test]
        public async Task GetDocumentNumber_CurrentYear_SuccessfullyGetDocumentNumberAsync()
        {
            // Act
            var currentYear = DateTime.UtcNow.Year;
            var data = await _numericSequenceClient.GetDocumentNumberAsync(NumericSequenceDocumentType.IssuedInvoice, null, 1)
                .AssertResult();

            // Assert
            Assert.AreEqual($"{currentYear}0001", data.Custom.DocumentNumber);
            Assert.IsFalse(data.Custom.IsUnique);
            Assert.NotNull(data.Unique);
        }

        [TestCaseSource(nameof(TestData_AnotherYear))]
        public async Task GetDocumentNumberAsync_AnotherYear_SuccessfullyGetDocumentNumber(DateTime date, string expectedDocumentNumber, bool isUnique)
        {
            // Act
            var data = await _numericSequenceClient.GetDocumentNumberAsync(NumericSequenceDocumentType.IssuedInvoice, date, 1).AssertResult();

            // Assert
            Assert.AreEqual(expectedDocumentNumber, data.Custom.DocumentNumber);
            Assert.AreEqual(isUnique, data.Custom.IsUnique);
            Assert.NotNull(data.Unique);
        }

        [Test]
        public async Task UpdateAsync_DoesNotFail()
        {
            // Arrange
            var model = new NumericSequencePatchModel
            {
                Id = NumericSequenceId
            };

            // Act
            var data = await _numericSequenceClient.UpdateAsync(model).AssertResult();

            // Assert
            Assert.NotNull(data);
        }

        [Test]
        public async Task UpdateAsync_DuplicateNumberFormat_SuccessfullyGetDetail()
        {
            // Arrange
            var existingSequence = await _numericSequenceClient.Detail(NumericSequenceRegisterSaleId).GetAsync().AssertResult();

            // Act
            var result = await _numericSequenceClient.UpdateAsync(new NumericSequencePatchModel
            {
                Id = NumericSequenceRegisterSaleId2,
                NumberFormat = existingSequence.NumberFormat,
            });

            // Assert
            Assert.False(result.IsSuccess);
            Assert.AreEqual(DokladErrorCode.NumericSequenceUniqueness, result.ErrorCode);
            Assert.AreEqual(HttpStatusCode.Conflict, result.StatusCode);
        }

        private static object[] TestData_AnotherYear()
        {
            return new object[]
            {
            new object[] { new DateTime(2019, 1, 1), "20190001", true },
            new object[] { new DateTime(2020, 1, 1), "20200001", false }
            };
        }
    }
}
