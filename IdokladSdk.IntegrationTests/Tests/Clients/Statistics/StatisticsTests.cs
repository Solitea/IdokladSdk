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

        [Test]
        public async Task DebtIntervals_ReturnsDebtIntervalsStatistics()
        {
            // Act
            var data = await _statisticsClient.DebtIntervals().AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.Issue, Is.Not.Null);
            Assert.That(data.Entry, Is.Not.Null);
        }

        [Test]
        public async Task TopDebtors_ReturnsTopDebtors()
        {
            // Arrange
            var countOfDebtors = 4;

            // Act
            var data = await _statisticsClient.TopDebtors(countOfDebtors).AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.Count, Is.EqualTo(countOfDebtors));
        }

        [Test]
        public async Task VatPayerProgress_ReturnsDataForVatPayerProgress()
        {
            // Act
            var data = await _statisticsClient.VatPayerProgress().AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.VatPayerLimit, Is.GreaterThan(0));
        }

        [TestCase(VatPeriod.Quarter)]
        [TestCase(VatPeriod.Month)]
        public async Task VatTotals(VatPeriod vatPeriod)
        {
            // Act
            var data = await _statisticsClient.VatTotals(vatPeriod, true).AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
        }
    }
}
