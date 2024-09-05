using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.UnpairedDocument
{
    [TestFixture]
    public class UnpairedDocumentTests : TestBase
    {
        private UnpairedDocumentClient _unpairedDocumentClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _unpairedDocumentClient = DokladApi.UnpairedDocumentClient;
        }

        [TestCaseSource(nameof(GetMovementTypes))]
        public async Task GetListAsync_SuccessfullyReturned(MovementType movementType)
        {
            // Act
            var result = await _unpairedDocumentClient.List(movementType).GetAsync();
            var data = result.Data;

            // Assert
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(data.TotalItems, Is.GreaterThan(0));
        }

        [TestCaseSource(nameof(GetMovementTypes))]
        public async Task GetListAsync_WithFilterAndSort_SuccessfullyReturned(MovementType movementType)
        {
            // Act
            var result = await _unpairedDocumentClient
                .List(movementType)
                .Filter(f => f.DocumentType.IsEqual(PairedDocumentType.IssuedInvoice))
                .Sort(s => s.DateOfIssue.Desc())
                .GetAsync();
            var data = result.Data;

            // Assert
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(data.TotalItems, Is.GreaterThan(0));
            Assert.That(data.Items.All(i => i.DocumentType == PairedDocumentType.IssuedInvoice), Is.True);
            Assert.That(data.Items.First().DateOfIssue, Is.GreaterThanOrEqualTo(data.Items.Last().DateOfIssue));
        }

        private static List<MovementType> GetMovementTypes()
        {
            var movementTypes = (MovementType[])Enum.GetValues(typeof(MovementType));
            return movementTypes.ToList();
        }
    }
}
