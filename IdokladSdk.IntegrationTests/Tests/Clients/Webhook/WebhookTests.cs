using System;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Webhook;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Webhook
{
    public class WebhookTests : TestBase
    {
        private int _newWebhookId;

        public WebhookClient Client { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            Client = DokladApi.WebhookClient;
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            var data = await Client.List().GetAsync().AssertResult();
            foreach (var item in data.Items)
            {
                await Client.DeleteAsync(item.Id).AssertResult();
            }
        }

        [Test]
        [Order(1)]
        public async Task PostAsync_SuccessfullyPosted()
        {
            // Arrange
            var model = new AgendaWebhookSettingsPostModel
            {
                ActionType = WebhookActionType.Insert,
                EntityType = WebhookEntityType.Contact,
                PublicId = new Guid("8747EE0F-652A-4735-9A48-1837EF992BA0")
            };

            // Act
            var data = await Client.PostAsync(model).AssertResult();
            _newWebhookId = data.Id;

            // Assert
            Assert.That(data.Id, Is.GreaterThan(0));
            Assert.That(data.PublicId, Is.EqualTo(model.PublicId));
            Assert.That(data.ActionType, Is.EqualTo(model.ActionType));
            Assert.That(data.EntityType, Is.EqualTo(model.EntityType));
        }

        [Test]
        [Order(2)]
        public async Task GetDetail_ReturnsWebhook()
        {
            // Act
            var data = await Client.Detail(_newWebhookId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(_newWebhookId));
        }

        [Test]
        [Order(3)]
        public async Task GetList_ReturnsWebhookList()
        {
            // Act
            var data = await Client.List().GetAsync().AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.Items.Count(), Is.GreaterThan(0));
            Assert.That(data.Items.ElementAt(0).Id, Is.EqualTo(_newWebhookId));
        }

        [Test]
        [Order(4)]
        public async Task DeleteAsync_WebhookDeleted()
        {
            // Act
            var data = await Client.DeleteAsync(_newWebhookId).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }
    }
}
