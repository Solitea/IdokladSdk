using System;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.NumericSequence;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.NumericSequence
{
    public partial class NumericSequenceTest : TestBase
    {
        private const int NumericSequenceId = 607899;
        private const int NumericSequenceYear = 2019;
        private NumericSequenceClient _numericSequenceClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _numericSequenceClient = DokladApi.NumericSequenceClient;
        }

        [Test]
        public void List_SuccessfullyGetList()
        {
            // Act
            var data = _numericSequenceClient.List()
                .Filter(f => f.DocumentType.IsEqual(NumericSequenceDocumentType.IssuedInvoice)).Get().AssertResult();

            // Assert
            Assert.AreEqual(data.TotalItems, 1);
        }

        [Test]
        public void DetailWithYear_SuccessfullyGetDetail()
        {
            // Act
            var data = _numericSequenceClient.Detail(NumericSequenceId, NumericSequenceYear).Get().AssertResult();

            // Assert
            Assert.AreEqual(NumericSequenceDocumentType.IssuedInvoice, data.DocumentType);
            Assert.AreEqual(NumericSequenceYear, data.Year);
        }

        [Test]
        public void DetailWithoutYear_SuccessfullyGetDetail()
        {
            // Act
            var data = _numericSequenceClient.Detail(NumericSequenceId).Get().AssertResult();

            // Assert
            Assert.AreEqual(NumericSequenceDocumentType.IssuedInvoice, data.DocumentType);
            Assert.AreNotEqual(NumericSequenceYear, data.Year);
        }

        [Test]
        public void GetDocumentNumber_SuccessfullyGetDocumentNumber()
        {
            // Act
            var data = _numericSequenceClient.GetDocumentNumber(NumericSequenceDocumentType.IssuedInvoice, null, 1)
                .AssertResult();

            // Assert
            Assert.AreEqual("20200001", data.Custom.DocumentNumber);
            Assert.IsFalse(data.Custom.IsUnique);
            Assert.NotNull(data.Unique);
        }

        [Test]
        public void GetDocumentNumber_AnotherYear_SuccessfullyGetDocumentNumber()
        {
            // Act
            var data = _numericSequenceClient.GetDocumentNumber(NumericSequenceDocumentType.IssuedInvoice, new DateTime(2019, 1, 1), 1)
                .AssertResult();

            // Assert
            Assert.AreEqual("20190001", data.Custom.DocumentNumber);
            Assert.IsTrue(data.Custom.IsUnique);
            Assert.NotNull(data.Unique);
        }

        [Test]
        public void Update_DoesNotFail()
        {
            // Arrange
            var model = new NumericSequencePatchModel
            {
                Id = NumericSequenceId
            };

            // Act
            var data = _numericSequenceClient.Update(model).AssertResult();

            // Assert
            Assert.NotNull(data);
        }
    }
}
