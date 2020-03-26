using System.Linq;
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
    public partial class StatisticsTests : TestBase
    {
        private StatisticsClient _statisticsClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _statisticsClient = DokladApi.StatisticsClient;
        }

        [Test]
        public void InvoicingForPeriod_ReturnsDataForGivenPeriod()
        {
            // Arrange
            var periodType = PeriodType.Month;

            // Act
            var data = _statisticsClient.InvoicingForPeriod(periodType).AssertResult();

            // Assert
            Assert.Greater(data.IssuedInvoices.Count, 0);
            Assert.Greater(data.IssuedInvoices.First().Period, periodType.ToString());
            Assert.Greater(data.ReceivedInvoices.Count, 0);
            Assert.Greater(data.ReceivedInvoices.First().Period, periodType.ToString());
        }

        [Test]
        public void InvoicingForYear_ReturnsDataForGivenYear()
        {
            // Arrange
            var yearType = YearType.Actual;

            // Act
            var data = _statisticsClient.InvoicingForYear(yearType).AssertResult();

            // Assert
            Assert.Greater(data.IssuedInvoices.TotalWithVat, 0);
            Assert.Greater(data.ReceivedInvoices.TotalWithVat, 0);
        }

        [Test]
        public void QuarterSummary_ReturnsDataQuarters()
        {
            // Act
            var data = _statisticsClient.QuarterSummary().AssertResult();

            // Assert
            Assert.Greater(data.Count, 0);
        }

        [Test]
        public void TopPartners_ReturnsTopPartners()
        {
            // Act
            var data = _statisticsClient.TopPartners().AssertResult();

            // Assert
            Assert.Greater(data.Count, 0);
            Assert.Greater(data.First().TotalWithVatHc, 0);
        }

        [Test]
        public void AgendaSummary_ReturnsTopPartners()
        {
            // Act
            var data = _statisticsClient.AgendaSummary().AssertResult();

            // Assert
            Assert.Greater(data.IssuedInvoices, 0);
            Assert.Greater(data.ReceivedInvoices, 0);
            Assert.Greater(data.SalesReceipts, 0);
        }

        [Test]
        public void StatisticForContact_ReturnsTopPartners()
        {
            // Act
            var data = _statisticsClient.StatisticForContact(323823).AssertResult();

            // Assert
            Assert.Greater(data.IssuedInvoiceCount, 0);
            Assert.Greater(data.IssuedInvoiceTotalWithVat, 0);
        }
    }
}
