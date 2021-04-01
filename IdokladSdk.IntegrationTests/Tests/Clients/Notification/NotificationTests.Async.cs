using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Notification.Put;
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

        [Test]
        public async Task GetNotificationsCountAsync_Success()
        {
            // Act
            var result = (await NotificationClient.GetNewNotificationCountAsync()).AssertResult();

            // Assert
            Assert.Greater(result.NewNotificationsCount, 0);
        }

        [Test]
        public async Task SetNotificationStatusAsync_StatusSetSuccessfully()
        {
            // Arrange
            var notificationId = 527012;
            var notification = NotificationClient
                .List()
                .Filter(e => e.Id.IsEqual(notificationId))
                .Get().Data.Items.First();

            var notificationStatus = (NotificationUserStatus)new List<int> { 0, 1 }
                .First(e => e != (int)notification.Status);

            var model = new List<NotificationPutModel>()
            {
                new NotificationPutModel
                {
                    Id = notificationId,
                    Status = notificationStatus
                },
            };

            // Act
            var result = (await NotificationClient.ChangeStatusAsync(model)).AssertResult();

            // Assert
            Assert.IsNotNull(result.First());
            Assert.AreEqual(notificationStatus, result.First().Status);
        }
    }
}
