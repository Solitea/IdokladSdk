using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Notification.List;
using IdokladSdk.Models.Notification.NotificationData;
using IdokladSdk.Models.Notification.Put;
using IdokladSdk.Response;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Notification
{
    [TestFixture]
    public partial class NotificationTests : TestBase
    {
        private const int NotificationToDeleteId = 1;

        public NotificationClient NotificationClient { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            NotificationClient = DokladApi.NotificationClient;
        }

        [Test]
        public void Delete_NonExistingNotification_Fails()
        {
            // Act
            var result = NotificationClient.Delete(NotificationToDeleteId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(result.Message, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void GetList_ApiLimitNotification_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.ApiLimit))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertApiLimitNotification(result.Items.First());
        }

        [Test]
        public void GetList_BankStatementNotification_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.BankStatement))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertBankStatementNotification(result.Items.First());
        }

        [Test]
        public void GetList_DocumentLinkActivatedNotification_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.DocumentLinkActivated))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertDocumentLinkActivatedNotification(result.Items.First());
        }

        [Test]
        public void GetList_EetCertificateNotification_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.EetCertificate))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertEetCertificateNotification(result.Items.First());
        }

        [Test]
        public void GetList_EetUnregisteredSalesNotification_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.EetUnregisteredSales))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertEetUnregisteredSalesNotification(result.Items.First());
        }

        [Test]
        public void GetList_FilterByDateCreated_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.DateCreated.IsGreaterThan(DateTime.MinValue))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
        }

        [Test]
        public void GetList_FilterById_Success()
        {
            // Arrange
            var notifications = NotificationClient.List().Get().AssertResult().Items;
            var id = notifications.First().Id;

            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Id.IsEqual(id))
                .Get()
                .AssertResult();

            // Assert
            Assert.That(result.TotalItems, Is.EqualTo(1));
            Assert.That(result.TotalPages, Is.EqualTo(1));
            var notification = result.Items.First();
            Assert.That(notification.Id, Is.EqualTo(id));
        }

        [Test]
        public void GetList_FilterBySeverityType_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.SeverityType.IsEqual(NotificationSeverityType.Warning))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
        }

        [Test]
        public void GetList_FilterByStatus_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Status.IsEqual(NotificationUserStatus.New))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
        }

        [Test]
        public void GetList_ProformaPaymentNotAccountedMessage_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.ProformaPaymentNotAccounted))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertProformaPaymentNotAccountedNotification(result.Items.First());
        }

        [Test]
        public void GetList_RecurringInvoiceNotification_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.RecurringInvoice))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertRecurringInvoiceNotification(result.Items.First());
        }

        [Test]
        public void GetList_RecurringOrderNotification_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.RecurringOrder))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertRecurringOrderNotification(result.Items.First());
        }

        [Test]
        public void GetList_ReferralExpiredSoonNotification_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.ReferralExpiredSoon))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertReferralExpiredSoonNotification(result.Items.First());
        }

        [Test]
        public void GetList_ReferralPointsManualNotification_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.ReferralPointsManual))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertReferralPointsManualNotification(result.Items.First());
        }

        [Test]
        public void GetList_ReferralPromoCodeExpiredSoonNotification_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.ReferralPromoCodeExpiredSoon))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertReferralPromoCodeExpiredSoonNotification(result.Items.First());
        }

        [Test]
        public void GetList_RemindedInvoiceNotification_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.RemindedInvoice))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertRemindedInvoiceNotification(result.Items.First());
        }

        [Test]
        public void GetList_RemindersDisabledNotification_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.RemindersDisabled))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertRemindersDisabledNotification(result.Items.First());
        }

        [Test]
        public void GetList_SupportNotification_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.Support))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertSupportNotification(result.Items.First());
        }

        [Test]
        public void GetList_VatPayerLimitReachedNotification_Success()
        {
            // Act
            var result = NotificationClient.List()
                .Filter(n => n.Type.IsEqual(NotificationType.VatPayerLimitReached))
                .Get()
                .AssertResult();

            // Assert
            AssertNonEmptyListResult(result);
            AssertVatPayerLimitReachedNotification(result.Items.First());
        }

        [Test]
        public void GetNewNotificationCount_Success()
        {
            // Act
            var result = NotificationClient.GetNewNotificationCount().AssertResult();

            // Assert
            Assert.Greater(result.NewNotificationsCount, 0);
        }

        [Test]
        public void SetNotificationStatus_StatusSetSuccessfully()
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
            var result = NotificationClient.ChangeStatus(model).AssertResult();

            // Assert
            Assert.IsNotNull(result.First());
            Assert.AreEqual(notificationStatus, result.First().Status);
        }

        private void AssertApiLimitNotification(NotificationListGetModel notification)
        {
            AssertNotification(notification);
            var notificationData = notification.NotificationData as ApiLimitExceededNotificationV1GetModel;
            Assert.That(notificationData, Is.Not.Null);
            Assert.That(notificationData.ActualRequestCount, Is.Not.Zero);
            Assert.That(notificationData.DateOfRenewal, Is.Not.EqualTo(DateTime.MinValue));
            Assert.That(notificationData.LimitValue, Is.Not.Zero);
        }

        private void AssertBankStatementNotification(NotificationListGetModel notification)
        {
            AssertNotification(notification);
            var notificationData = notification.NotificationData as BankStatementNotificationV1GetModel;
            Assert.That(notificationData, Is.Not.Null);
            Assert.That(notificationData.CurrencySymbol, Is.Not.Null.And.Not.Empty);
            Assert.That(notificationData.PairedDocumentType, Is.EqualTo(DocumentType.IssuedInvoice));
            Assert.That(notificationData.PairedInvoiceDocumentNumber, Is.Not.Null);
            Assert.That(notificationData.VariableSymbol, Is.Not.Null);
        }

        private void AssertDocumentLinkActivatedNotification(NotificationListGetModel notification)
        {
            AssertNotification(notification);
            var notificationData = notification.NotificationData as DocumentLinkNotificationV1GetModel;
            Assert.That(notificationData, Is.Not.Null);
            Assert.That(notificationData.CompanyName, Is.Not.Null.And.Not.Empty);
            Assert.That(notificationData.DocumentNumber, Is.Not.Null.And.Not.Empty);
            Assert.That(notificationData.DateOfActivation, Is.Not.EqualTo(DateTime.MinValue));
            Assert.That(notificationData.DocumentId, Is.Not.Zero);
            Assert.That(notificationData.DocumentType, Is.EqualTo(DocumentType.IssuedInvoice));
            Assert.That(notificationData.RecepientEmail, Is.Not.Null.And.Not.Empty);
        }

        private void AssertEetCertificateNotification(NotificationListGetModel notification)
        {
            AssertNotification(notification);
            var notificationData = notification.NotificationData as EetCertificateExpireSoonNotificationV1GetModel;
            Assert.That(notificationData, Is.Not.Null);
            Assert.That(notificationData.ExpireDate, Is.Not.EqualTo(DateTime.MinValue));
            Assert.That(notificationData.Name, Is.Not.Null.And.Not.Message);
        }

        private void AssertEetUnregisteredSalesNotification(NotificationListGetModel notification)
        {
            AssertNotification(notification);
            var notificationData = notification.NotificationData as EetUnregisteredSalesNotificationV1GetModel;
            Assert.That(notificationData, Is.Not.Null);
            Assert.That(notificationData.CountUnregistered, Is.Not.Zero);
        }

        private void AssertNonEmptyListResult(Page<NotificationListGetModel> result)
        {
            Assert.That(result.TotalItems, Is.GreaterThan(0));
            Assert.That(result.TotalPages, Is.GreaterThan(0));
        }

        private void AssertNotification(NotificationListGetModel notification)
        {
            Assert.That(notification.Body, Is.Not.Null.And.Not.Empty);
            Assert.That(notification.DateCreated, Is.Not.EqualTo(DateTime.MinValue));
            Assert.That(notification.Id, Is.Not.Zero);
            Assert.That(notification.NotificationData, Is.Not.Null);
            Assert.That(notification.NotificationType, Is.Not.Null.And.Not.Empty);
            Assert.That(notification.SeverityType, Is.Not.Zero);
            Assert.That(notification.Title, Is.Not.Null.And.Not.Empty);
        }

        private void AssertProformaPaymentNotAccountedNotification(NotificationListGetModel notification)
        {
            AssertNotification(notification);
            var notificationData = notification.NotificationData as ProformaPaymentNotAccountedMessageModelV1GetModel;
            Assert.That(notificationData, Is.Not.Null);
            Assert.That(notificationData.DateOfPayment, Is.Not.EqualTo(DateTime.MinValue));
            Assert.That(notificationData.DocumentNumber, Is.Not.Null.And.Not.Empty);
            Assert.That(notificationData.ProformaId, Is.Not.Zero);
        }

        private void AssertRecurringInvoiceNotification(NotificationListGetModel notification)
        {
            AssertNotification(notification);
            var notificationData = notification.NotificationData as RecurringInvoiceNotificationV1GetModel;
            Assert.That(notificationData, Is.Not.Null);
            Assert.That(notificationData.DocumentType, Is.EqualTo(DocumentType.IssuedInvoice));
            Assert.That(notificationData.DocumentNumber, Is.Not.Null.And.Not.Empty);
            Assert.That(notificationData.InvoiceId, Is.Not.Zero);
            Assert.That(notificationData.PurchaserName, Is.Not.Null.And.Not.Empty);
        }

        private void AssertRecurringOrderNotification(NotificationListGetModel notification)
        {
            AssertNotification(notification);
            var notificationData = notification.NotificationData as RecurringOrderNotificationV1GetModel;
            Assert.That(notificationData, Is.Not.Null);
            Assert.That(notificationData.PaymentState, Is.EqualTo(RecurringPaymentState.RecurringPaymentDeactivated));
        }

        private void AssertReferralExpiredSoonNotification(NotificationListGetModel notification)
        {
            AssertNotification(notification);
            var notificationData = notification.NotificationData as ReferralExpiredSoonNotificationV1GetModel;
            Assert.That(notificationData, Is.Not.Null);
            Assert.That(notificationData.DateCreated, Is.Not.EqualTo(DateTime.MinValue));
            Assert.That(notificationData.Points, Is.Not.Zero);
        }

        private void AssertReferralPointsManualNotification(NotificationListGetModel notification)
        {
            AssertNotification(notification);
            var notificationData = notification.NotificationData as ReferralPointsManualNotificationV1GetModel;
            Assert.That(notificationData, Is.Not.Null);
            Assert.That(notificationData.Points, Is.Not.Zero);
            Assert.That(notificationData.TotalPoints, Is.Not.Zero);
        }

        private void AssertReferralPromoCodeExpiredSoonNotification(NotificationListGetModel notification)
        {
            AssertNotification(notification);
            var notificationData =
                notification.NotificationData as ReferralPromoCodeExpiredSoonNotificationV1GetModel;
            Assert.That(notificationData, Is.Not.Null);
            Assert.That(notificationData.Amount, Is.Not.Zero);
            Assert.That(notificationData.CurrencySymbol, Is.Not.Null.And.Not.Empty);
            Assert.That(notificationData.DateExpiration, Is.Not.EqualTo(DateTime.MinValue));
        }

        private void AssertRemindedInvoiceNotification(NotificationListGetModel notification)
        {
            AssertNotification(notification);
            var notificationData = notification.NotificationData as RemindedInvoiceNotificationV1GetModel;
            Assert.That(notificationData, Is.Not.Null);
            Assert.That(notificationData.DocumentNumber, Is.Not.Null.And.Not.Empty);
            Assert.That(notificationData.DocumentType, Is.EqualTo(DocumentType.IssuedInvoice));
            Assert.That(notificationData.InvoiceId, Is.Not.Zero);
            Assert.That(notificationData.PurchaserMail, Is.Not.Null.And.Not.Empty);
            Assert.That(notificationData.PurchaserName, Is.Not.Null.And.Not.Empty);
        }

        private void AssertRemindersDisabledNotification(NotificationListGetModel notification)
        {
            AssertNotification(notification);
            var notificationData = notification.NotificationData as RemindersDisabledNotificationV1GetModel;
            Assert.That(notificationData, Is.Not.Null);
            Assert.That(notificationData.DateOfDisabled, Is.Not.EqualTo(DateTime.MinValue));
        }

        private void AssertSupportNotification(NotificationListGetModel notification)
        {
            AssertNotification(notification);
            var notificationData = notification.NotificationData as SupportNotificationV1GetModel;
            Assert.That(notificationData, Is.Not.Null);
            Assert.That(notificationData.Author, Is.Not.Null.And.Not.Empty);
            Assert.That(notificationData.DateOfAction, Is.Not.EqualTo(DateTime.MinValue));
            Assert.That(notificationData.ThreadGuid, Is.Not.EqualTo(Guid.Empty));
            Assert.That(notificationData.ThreadItemType, Is.EqualTo(ThreadItemType.Question));
            Assert.That(notificationData.ThreadName, Is.Not.Null.And.Not.Empty);
        }

        private void AssertVatPayerLimitReachedNotification(NotificationListGetModel notification)
        {
            AssertNotification(notification);
            var notificationData = notification.NotificationData as VatPayerLimitReachedNotificationV1GetModel;
            Assert.That(notificationData, Is.Not.Null);
            Assert.That(notificationData.AccountingType, Is.EqualTo(AccountingType.ActualExpenses));
            Assert.That(notificationData.DateOfEvent, Is.Not.EqualTo(DateTime.MinValue));
            Assert.That(notificationData.Legislation, Is.Not.Zero);
        }
    }
}
