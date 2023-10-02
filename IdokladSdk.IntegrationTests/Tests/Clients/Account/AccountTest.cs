using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Account;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Account
{
    public class AccountTest : TestBase
    {
        private const int AgendaId = 187854;
        private const string ImageFileName = "Solitea.png";
        private const string ImagePath = "Tests/Clients/Account/Solitea.png";
        private const int UserId = 161205;
        private const string Street = "Drobného 555/49";
        private const string DefaultItemsTextPrefix = "Fakturujeme Vám za dodané zboží či služby:";
        private const string DefaultItemsTextSuffix = "Dovolujeme si Vás upozornit, že v případně nedodržení data splatnosti uvedeného na faktuře Vám můžeme účtovat zákonný úrok z prodlení.";
        private const string DefaultProformaItemsPrefixText = "Zasíláme Vám zálohovou fakturu na objednané zboží či služby:";
        private const string DefaultProformaItemsSuffixText = "Zboží Vám pošleme obratem po přijetí platby na náš účet";

        private AccountClient _accountClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            _accountClient = DokladApi.AccountClient;
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await ResetAgenda();
        }

        [Test]
        public async Task AgendaListAsync_SuccessfullyGetAgendaList()
        {
            // Act
            var data = await _accountClient.Agendas.List().GetAsync().AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            var agenda = data.Items.FirstOrDefault();
            Assert.NotNull(agenda);
            Assert.AreEqual(AgendaId, agenda.Id);
            Assert.NotNull(agenda.Contact);
            Assert.AreEqual(Street, agenda.Contact.Street);
        }

        [Test]
        public async Task SubscriptionsListAsync_FilteredByDateFromSuccessfullyGetSubscription()
        {
            // Act
            var data = await _accountClient.Subscriptions.List().Filter(f => f.DateFrom.IsGreaterThan(new DateTime(2020, 3, 1))).GetAsync().AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.GreaterThan(2));
        }

        [Test]
        public async Task SubscriptionsListAsync_FilteredByIsCanceledSuccessfullyGetSubscription()
        {
            // Act
            var data = await _accountClient.Subscriptions
                .List()
                .Filter(f => f.IsCanceled.IsEqual(true))
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data.TotalItems, Is.EqualTo(0));
        }

        [Test]
        public async Task AgendaDetailAsync_SuccessfullyGetAgendaDetail()
        {
            // Act
            var data = await _accountClient.Agendas.Detail(AgendaId).GetAsync().AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.AreEqual(AgendaId, data.Id);
            Assert.AreEqual("Solitea Česká republika, a.s.", data.Name);
            Assert.NotNull(data.Contact);
            Assert.AreEqual(Street, data.Contact.Street);
            Assert.That(data.HasVatRegimeOss, Is.True);
        }

        [Test]
        public async Task AgendaCurrentAsync_SuccessfullyGetAgendaCurrentDetail()
        {
            // Act
            var data = await _accountClient.Agendas.Current().GetAsync().AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.AreEqual(AgendaId, data.Id);
            Assert.AreEqual("Solitea Česká republika, a.s.", data.Name);
            Assert.NotNull(data.Contact);
            Assert.AreEqual(Street, data.Contact.Street);
        }

        [Test]
        public async Task AgendaDeleteRequestAsync_DoesNotFail()
        {
            // Arrange
            var model = new AgendaDeleteRequestPostModel();

            // Act
            var data = await _accountClient.Agendas.DeleteRequestAsync(model).AssertResult();

            // Assert
            Assert.True(data);
        }

        [Test]
        public async Task AgendaUpdate_ItemsPrefixAndSuffix_DoesNotFail()
        {
            // Arrange
            var itemsTextPrefix = $"{DefaultItemsTextPrefix}xxx";
            var itemsTextSuffix = $"{DefaultItemsTextSuffix}xxx";
            var proformaItemsPrefixText = $"{DefaultProformaItemsPrefixText}xxx";
            var proformaItemsSuffixText = $"{DefaultProformaItemsSuffixText}xxx";
            var setupModel = new AgendaPatchModel
            {
                SalesSettings = new SalesSettingsPatchModel
                {
                    ItemsTextPrefix = itemsTextPrefix,
                    ItemsTextSuffix = itemsTextSuffix,
                    ProformaItemsPrefixText = proformaItemsPrefixText,
                    ProformaItemsSuffixText = proformaItemsSuffixText,
                }
            };

            // Act
            var result = await _accountClient.Agendas.UpdateAsync(setupModel);

            // Assert
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.SalesSettings?.ItemsTextPrefix, Is.EqualTo(itemsTextPrefix));
            Assert.That(result.Data.SalesSettings?.ItemsTextSuffix, Is.EqualTo(itemsTextSuffix));
            Assert.That(result.Data.SalesSettings?.ProformaItemsPrefixText, Is.EqualTo(proformaItemsPrefixText));
            Assert.That(result.Data.SalesSettings?.ProformaItemsSuffixText, Is.EqualTo(proformaItemsSuffixText));
        }

        [Test]
        public async Task AgendaUpdateAsync_DoesNotFail()
        {
            // Arrange
            var model = new AgendaPatchModel();

            // Act
            var data = await _accountClient.Agendas.UpdateAsync(model).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.NotNull(data.AutomaticPairPaymentsSettings);
            Assert.True(data.BankAccounts.Any());
            Assert.True(data.CashRegisters.Any());
            Assert.NotNull(data.Contact);
            Assert.NotNull(data.PurchaseSettings);
            Assert.NotNull(data.SalesSettings);
            Assert.NotNull(data.SendReminderSettings);
            Assert.NotNull(data.Subscription);
        }

        [Test]
        public async Task AgendaUpdateAsync_ValidIdentification_DoesNotFail()
        {
            // Arrange
            var model = new AgendaPatchModel
            {
                Contact = new AgendaContactPatchModel
                {
                    IdentificationNumber = string.Empty,
                    HasNoIdentificationNumber = true
                }
            };

            // Act
            var hasIdentificationData = await _accountClient.Agendas.UpdateAsync(model).AssertResult();

            // Assert
            var contact = hasIdentificationData.Contact;
            Assert.That(contact.IdentificationNumber, Is.Empty);
            Assert.That(contact.HasNoIdentificationNumber, Is.True);

            var identificationNumber = "25568736";
            model.Contact.IdentificationNumber = identificationNumber;
            model.Contact.HasNoIdentificationNumber = false;

            // Act
            var data = (await _accountClient.Agendas.UpdateAsync(model)).AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.NotNull(data.Contact);
            Assert.That(data.Contact.IdentificationNumber, Is.EqualTo(identificationNumber));
            Assert.That(data.Contact.HasNoIdentificationNumber, Is.False);
        }

        [Test]
        public void AgendaUpdateAsync_InValidIdentification_UpdateFailed()
        {
            // Arrange
            var model = new AgendaPatchModel
            {
                Contact = new AgendaContactPatchModel
                {
                    IdentificationNumber = "invalid",
                    HasNoIdentificationNumber = false
                }
            };

            // Assert
            Assert.ThrowsAsync<ValidationException>(async () => await _accountClient.Agendas.UpdateAsync(model));
        }

        [Test]
        public async Task Agenda_GenerateBankStatementMailAsync_ReturnsEmailAddress()
        {
            // Act
            var data = await _accountClient.Agendas.GenerateBankStatementMailAsync().AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task LogoGetAsync_SuccessfullyGet()
        {
            // Act
            var data = await _accountClient.Agendas.GetLogoAsync().AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.NotNull(data.FileBytes);
        }

        [Test]
        public async Task LogoSignatureAsync_SuccessfullyGet()
        {
            // Act
            var data = await _accountClient.Agendas.GetSignatureAsync().AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.NotNull(data.FileBytes);
        }

        [Test]
        public async Task LogoDeleteAsync_SuccessfullyDeleted()
        {
            // Act
            var data = await _accountClient.Agendas.DeleteLogoAsync().AssertResult();

            // Assert
            Assert.True(data);
        }

        [Test]
        public async Task LogoSignatureAsync_SuccessfullyDeleted()
        {
            // Act
            var data = await _accountClient.Agendas.DeleteSignatureAsync().AssertResult();

            // Assert
            Assert.True(data);
        }

        [Test]
        public async Task LogoUpdateAsync_SuccessfullyUpdated()
        {
            // Arrange
            var model = new LogoPostModel
            {
                FileBytes = File.ReadAllBytes($"{TestContext.CurrentContext.TestDirectory}/{ImagePath}"),
                FileName = ImageFileName,
                HighResolution = true
            };

            // Act
            var data = await _accountClient.Agendas.UploadLogoAsync(model).AssertResult();

            // Assert
            Assert.True(data);
        }

        [Test]
        public async Task SignatureUpdateAsync_SuccessfullyUpdated()
        {
            // Arrange
            var model = new SignaturePostModel()
            {
                FileBytes = File.ReadAllBytes($"{TestContext.CurrentContext.TestDirectory}/{ImagePath}"),
                FileName = ImageFileName,
            };

            // Act
            var data = await _accountClient.Agendas.UploadSignatureAsync(model).AssertResult();

            // Assert
            Assert.True(data);
        }

        [Test]
        public async Task UserListAsync_SuccessfullyGetUserList()
        {
            // Act
            var data = await _accountClient.Users.List().GetAsync().AssertResult();

            // Assert
            Assert.Greater(data.TotalItems, 0);
            var user = data.Items.FirstOrDefault();
            Assert.NotNull(user);
            Assert.AreEqual(UserId, user.Id);
        }

        [Test]
        public async Task UserDetailAsync_SuccessfullyGetUserDetail()
        {
            // Act
            var data = await _accountClient.Users.Detail(UserId).GetAsync().AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.AreEqual(UserId, data.Id);
            Assert.AreEqual("qquc@furusato.tokyo", data.Username);
            Assert.AreEqual(UserRight.Admin, data.Rights);
        }

        [Test]
        public async Task UserCurrentAsync_SuccessfullyGetUserCurrentDetail()
        {
            // Act
            var data = await _accountClient.Users.Current().GetAsync().AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.AreEqual(UserId, data.Id);
            Assert.AreEqual("qquc@furusato.tokyo", data.Username);
            Assert.AreEqual(UserRight.Admin, data.Rights);
        }

        [Test]
        public async Task UserUpdateAsync_DoesNotFail()
        {
            // Arrange
            var model = new UserPatchModel();

            // Act
            var data = await _accountClient.Users.UpdateAsync(model).AssertResult();

            // Assert
            Assert.NotNull(data);
        }

        [Test]
        public async Task GetSubscriptionListAsync_SubscriptionListGotSuccessfully()
        {
            // Act
            var result = await _accountClient.Subscriptions.List()
                .Sort(x => x.DateOfIssue.Desc())
                .GetAsync().AssertResult();

            // Assert
            Assert.NotNull(result);
            Assert.Greater(result.TotalItems, 0);
        }

        private async Task ResetAgenda()
        {
            var defaultModel = new AgendaPatchModel
            {
                SalesSettings = new SalesSettingsPatchModel
                {
                    ItemsTextPrefix = DefaultItemsTextPrefix,
                    ItemsTextSuffix = DefaultItemsTextSuffix,
                    ProformaItemsPrefixText = DefaultProformaItemsPrefixText,
                    ProformaItemsSuffixText = DefaultProformaItemsSuffixText,
                }
            };

            await _accountClient.Agendas.UpdateAsync(defaultModel);
        }
    }
}
