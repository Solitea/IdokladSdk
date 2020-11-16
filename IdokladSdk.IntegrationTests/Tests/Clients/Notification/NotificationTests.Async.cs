using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core.Extensions;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Notification
{
    public partial class NotificationTests
    {
        [Test]
        public async Task DeleteAsync_NonExistingNotification_Fails()
        {
            // Act
            var result = await NotificationClient.DeleteAsync(NotificationToDeleteId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(result.Message, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetListAsync_BankStatementNotification_Success()
        {
            // Act
            var result = (await NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.BankStatement))
                .GetAsync())
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertBankStatementNotification(result.Items.First());
        }
    }
}
