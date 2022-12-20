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
            Assert.Greater(data.IssuedInvoices.Count, 0);
            Assert.IsNotNull(data.IssuedInvoices.First().Period);
            Assert.IsNotEmpty(data.IssuedInvoices.First().Period);
            Assert.Greater(data.ReceivedInvoices.Count, 0);
            Assert.IsNotNull(data.ReceivedInvoices.First().Period);
            Assert.IsNotEmpty(data.ReceivedInvoices.First().Period);
        }

        [Test]
        public async Task InvoicingForYearAsync_CurrentYear_ReturnsDataForGivenYear()
        {
            // Arrange
            var yearType = YearType.Actual;

            // Act
            var data = await _statisticsClient.InvoicingForYearAsync(yearType).AssertResult();

            // Assert
            Assert.Greater(data.IssuedInvoices.TotalWithVat, 0);
            Assert.Greater(data.ReceivedInvoices.TotalWithVat, 0);
        }

        [Test]
        public async Task QuarterSummaryAsync_ReturnsDataQuarters()
        {
            // Act
            var data = await _statisticsClient.QuarterSummaryAsync().AssertResult();

            // Assert
            Assert.Greater(data.Count, 0);
        }

        [Test]
        public async Task TopPartnersAsync_ReturnsTopPartners()
        {
            // Act
            var data = await _statisticsClient.TopPartnersAsync().AssertResult();

            // Assert
            Assert.Greater(data.Count, 0);
            Assert.Greater(data.First().TotalWithVatHc, 0);
        }

        [Test]
        public async Task AgendaSummaryAsync_ReturnsTopPartners()
        {
            // Act
            var data = await _statisticsClient.AgendaSummaryAsync().AssertResult();

            // Assert
            Assert.Greater(data.IssuedInvoices, 0);
            Assert.Greater(data.ReceivedInvoices, 0);
            Assert.Greater(data.SalesReceipts, 0);
        }

        [Test]
        public async Task StatisticForContactAsync_ReturnsTopPartners()
        {
            // Act
            var data = await _statisticsClient.StatisticForContactAsync(323823).AssertResult();

            // Assert
            Assert.Greater(data.IssuedInvoiceCount, 0);
            Assert.Greater(data.IssuedInvoiceTotalWithVat, 0);
        }
    }
}