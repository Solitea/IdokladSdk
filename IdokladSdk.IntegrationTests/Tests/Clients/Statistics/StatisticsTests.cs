using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Statistics
{
    /// <summary>
    /// StatisticsTests.
    /// </summary>
    public class StatisticsTests : TestBase
    {
        private StatisticsClient _statisticsClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _statisticsClient = DokladApi.StatisticsClient;
        }

        [Test]
        public async Task InvoicingForPeriodAsync_ReturnsDataForGivenPeriod()
        {
            // Arrange
            var periodType = PeriodType.Month;

            // Act
            var data = await _statisticsClient.InvoicingForPeriodAsync(periodType).AssertResult();

            // Assert
            Assert.That(data.IssuedInvoices.Count, Is.GreaterThan(0));
            Assert.That(data.IssuedInvoices.First().Period, Is.Not.Null);
            Assert.That(data.IssuedInvoices.First().Period, Is.Not.Empty);
            Assert.That(data.ReceivedInvoices.Count, Is.GreaterThan(0));
            Assert.That(data.ReceivedInvoices.First().Period, Is.Not.Null);
            Assert.That(data.ReceivedInvoices.First().Period, Is.Not.Empty);
        }

        [Test]
        public async Task InvoicingForYearAsync_CurrentYear_ReturnsDataForGivenYear()
        {
            // Arrange
            var yearType = YearType.Actual;

            // Act
            var data = await _statisticsClient.InvoicingForYearAsync(yearType).AssertResult();

            // Assert
            Assert.That(data.IssuedInvoices.TotalWithVat, Is.GreaterThan(0));
            Assert.That(data.ReceivedInvoices.TotalWithVat, Is.GreaterThan(0));
        }

        [Test]
        public async Task QuarterSummaryAsync_ReturnsDataQuarters()
        {
            // Act
            var data = await _statisticsClient.QuarterSummaryAsync().AssertResult();

            // Assert
            Assert.That(data.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task TopPartnersAsync_ReturnsTopPartners()
        {
            // Act
            var data = await _statisticsClient.TopPartnersAsync().AssertResult();

            // Assert
            Assert.That(data.Count, Is.GreaterThan(0));
            Assert.That(data.First().TotalWithVatHc, Is.GreaterThan(0));
        }

        [Test]
        public async Task AgendaSummaryAsync_ReturnsTopPartners()
        {
            // Act
            var data = await _statisticsClient.AgendaSummaryAsync().AssertResult();

            // Assert
            Assert.That(data.IssuedInvoices, Is.GreaterThan(0));
            Assert.That(data.ReceivedInvoices, Is.GreaterThan(0));
            Assert.That(data.SalesReceipts, Is.GreaterThan(0));
        }

        [Test]
        public async Task StatisticForContactAsync_ReturnsTopPartners()
        {
            // Act
            var data = await _statisticsClient.StatisticForContactAsync(323823).AssertResult();

            // Assert
            Assert.That(data.IssuedInvoiceCount, Is.GreaterThan(0));
            Assert.That(data.IssuedInvoiceTotalWithVat, Is.GreaterThan(0));
        }
    }
}
