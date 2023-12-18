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
            Assert.That(data.TotalItems, Is.GreaterThan(1));
        }

        [Test]
        public async Task DetailWithYearAsync_SuccessfullyGetDetail()
        {
            // Act
            var data = await _numericSequenceClient.Detail(NumericSequenceId, NumericSequenceYear).GetAsync().AssertResult();

            // Assert
            Assert.That(data.DocumentType, Is.EqualTo(NumericSequenceDocumentType.IssuedInvoice));
            Assert.That(data.Year, Is.EqualTo(NumericSequenceYear));
        }

        [Test]
        public async Task DetailWithoutYearAsync_SuccessfullyGetDetail()
        {
            // Act
            var data = await _numericSequenceClient.Detail(NumericSequenceId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.DocumentType, Is.EqualTo(NumericSequenceDocumentType.IssuedInvoice));
            Assert.That(data.Year, Is.Not.EqualTo(NumericSequenceYear));
        }

        [Test]
        public async Task GetDocumentNumber_CurrentYear_SuccessfullyGetDocumentNumberAsync()
        {
            // Act
            var currentYear = DateTime.UtcNow.Year;
            var data = await _numericSequenceClient.GetDocumentNumberAsync(NumericSequenceDocumentType.IssuedInvoice, null, 1)
                .AssertResult();

            // Assert
            Assert.That(data.Custom.DocumentNumber, Is.EqualTo($"{currentYear}0001"));
            Assert.That(data.Custom.IsUnique, Is.False);
            Assert.That(data.Unique, Is.Not.Null);
        }

        [TestCaseSource(nameof(TestData_AnotherYear))]
        public async Task GetDocumentNumberAsync_AnotherYear_SuccessfullyGetDocumentNumber(DateTime date, string expectedDocumentNumber, bool isUnique)
        {
            // Act
            var data = await _numericSequenceClient.GetDocumentNumberAsync(NumericSequenceDocumentType.IssuedInvoice, date, 1).AssertResult();

            // Assert
            Assert.That(data.Custom.DocumentNumber, Is.EqualTo(expectedDocumentNumber));
            Assert.That(data.Custom.IsUnique, Is.EqualTo(isUnique));
            Assert.That(data.Unique, Is.Not.Null);
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
            Assert.That(data, Is.Not.Null);
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
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.ErrorCode, Is.EqualTo(DokladErrorCode.NumericSequenceUniqueness));
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
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
