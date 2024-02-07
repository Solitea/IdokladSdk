using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Contact;
using IdokladSdk.Models.DeliveryAddress;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Contacts
{
    /// <summary>
    /// ContactTests.
    /// </summary>
    [TestFixture]
    public class ContactTests : TestBase
    {
        private int _newContactId = 0;
        private string _newContactName;
        private string _updatedContactName;
        private ContactPostModel _contactPostModel;
        private DateTime _dateLastChange;

        public ContactClient ContactClient { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            ContactClient = DokladApi.ContactClient;
        }

        [Test]
        [Order(1)]
        public async Task Post_SuccessfullyPosted()
        {
            // Arrange
            _newContactName = CreateUniqueContactName();
            _contactPostModel = await ContactClient.DefaultAsync().AssertResult();
            _contactPostModel.AccountNumber = "2102290124";
            _contactPostModel.BankId = 18;
            _contactPostModel.City = "Brno";
            _contactPostModel.CompanyName = _newContactName;
            _contactPostModel.CountryId = 2;
            _contactPostModel.DefaultInvoiceMaturity = 15;
            _contactPostModel.DeliveryAddresses.Add(new DeliveryAddressPostModel
            {
                City = "Brno",
                Name = "iDoklad",
                IsDefault = true,
                PostalCode = "60200",
                Street = "Hilleho 4"
            });
            _contactPostModel.DiscountPercentage = 11;
            _contactPostModel.Email = "info@solitea.cz";
            _contactPostModel.Fax = "800 776 776";
            _contactPostModel.Firstname = "X.";
            _contactPostModel.Iban = "CZ2627000000002102290124";
            _contactPostModel.IdentificationNumber = "25568736";
            _contactPostModel.IsRegisteredForVatOnPay = false;
            _contactPostModel.Mobile = "604 123 456";
            _contactPostModel.Note = "Money S3";
            _contactPostModel.Phone = "800 776 776";
            _contactPostModel.PostalCode = "602 00";
            _contactPostModel.SendReminders = true;
            _contactPostModel.Street = "Drobného 49";
            _contactPostModel.Surname = "Y.";
            _contactPostModel.Swift = "BACXCZPP";
            _contactPostModel.Title = "Ing.";
            _contactPostModel.VatIdentificationNumber = "CZ25568736";
            _contactPostModel.VatIdentificationNumberSk = string.Empty;
            _contactPostModel.Www = "www.solitea.cz";

            // Act
            var data = await ContactClient.PostAsync(_contactPostModel).AssertResult();
            _newContactId = data.Id;

            // Assert
            Assert.That(data.Id, Is.GreaterThan(0));
            AssertGetModel(data);
        }

        [Test]
        [Order(2)]
        public async Task GetDetail_ReturnsContact()
        {
            // Act
            var data = await ContactClient.Detail(_newContactId).GetAsync().AssertResult();

            // Assert
            Assert.That(data.Id, Is.EqualTo(_newContactId));
            AssertGetModel(data);
        }

        [Test]
        [Order(3)]
        public async Task Update_SuccessfullyUpdatedContact()
        {
            // Arrange
            _updatedContactName = CreateUniqueContactName();
            var contactPatchModel = new ContactPatchModel
            {
                AccountNumber = "2626708763",
                BankId = 63,
                City = "Bratislava",
                CompanyName = _updatedContactName,
                CountryId = 1,
                DefaultInvoiceMaturity = 9,
                DeliveryAddresses = new List<DeliveryAddressPatchModel>
            {
                new DeliveryAddressPatchModel
                {
                    City = "Brno",
                    Name = "Money S5",
                    IsDefault = false,
                    PostalCode = "60200",
                    Street = "Okružní 732/5"
                }
            },
                DiscountPercentage = 8,
                Email = "info@solitea.sk",
                Fax = "+421 249 212 323",
                Firstname = "A.",
                Iban = "SK13 1100 0000 0026 2670 8763",
                Id = _newContactId,
                IdentificationNumber = "36237337",
                IsRegisteredForVatOnPay = true,
                Mobile = "+421 905 123 456",
                Note = "nic",
                Phone = "+421 249 212 323",
                PostalCode = "821 09",
                SendReminders = true,
                Street = "Plynárenská 7/C",
                Surname = "B.",
                Swift = "TATRSKBX",
                Title = "Mgr.",
                VatIdentificationNumber = string.Empty,
                VatIdentificationNumberSk = "SK2020193890",
                Www = "www.solitea.sk"
            };

            // Act
            var data = await ContactClient.UpdateAsync(contactPatchModel).AssertResult();
            _dateLastChange = data.Metadata.DateLastChange;

            // Assert
            Assert.That(data.Id, Is.EqualTo(contactPatchModel.Id));
            Assert.That(data.AccountNumber, Is.EqualTo(contactPatchModel.AccountNumber));
            Assert.That(data.BankId, Is.EqualTo(contactPatchModel.BankId.Value));
            Assert.That(data.City, Is.EqualTo(contactPatchModel.City));
            Assert.That(data.CompanyName, Is.EqualTo(contactPatchModel.CompanyName));
            Assert.That(data.CountryId, Is.EqualTo(contactPatchModel.CountryId.Value));
            Assert.That(data.DefaultInvoiceMaturity, Is.EqualTo(contactPatchModel.DefaultInvoiceMaturity.Value));
            AssertDeliveryAddress(data.DeliveryAddresses.First(), contactPatchModel.DeliveryAddresses.First());
            Assert.That(data.DiscountPercentage, Is.EqualTo(contactPatchModel.DiscountPercentage));
            Assert.That(data.Email, Is.EqualTo(contactPatchModel.Email));
            Assert.That(data.Fax, Is.EqualTo(contactPatchModel.Fax));
            Assert.That(data.Firstname, Is.EqualTo(contactPatchModel.Firstname));
            Assert.That(data.Iban, Is.EqualTo(contactPatchModel.Iban));
            Assert.That(data.IdentificationNumber, Is.EqualTo(contactPatchModel.IdentificationNumber));
            Assert.That(data.IsRegisteredForVatOnPay, Is.EqualTo(false));
            Assert.That(data.Mobile, Is.EqualTo(contactPatchModel.Mobile));
            Assert.That(data.Note, Is.EqualTo(contactPatchModel.Note));
            Assert.That(data.Phone, Is.EqualTo(contactPatchModel.Phone));
            Assert.That(data.PostalCode, Is.EqualTo(contactPatchModel.PostalCode));
            Assert.That(data.SendReminders, Is.EqualTo(contactPatchModel.SendReminders));
            Assert.That(data.Street, Is.EqualTo(contactPatchModel.Street));
            Assert.That(data.Surname, Is.EqualTo(contactPatchModel.Surname));
            Assert.That(data.Swift, Is.EqualTo(contactPatchModel.Swift));
            Assert.That(data.VatIdentificationNumber, Is.EqualTo(contactPatchModel.VatIdentificationNumber));
            Assert.That(data.VatIdentificationNumberSk, Is.EqualTo(contactPatchModel.VatIdentificationNumberSk));
            Assert.That(data.Www, Is.EqualTo(contactPatchModel.Www));
        }

        [Test]
        [Order(4)]
        public async Task GetListWithFilter_ReturnsList()
        {
            // Act
            var data = await ContactClient
                .List()
                .Filter(f => f.CompanyName.Contains(_updatedContactName) && f.DateLastChange.IsGreaterThanOrEqual(_dateLastChange))
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.Items.Count(), Is.GreaterThan(0));
            Assert.That(data.Items.ElementAt(0).Id, Is.EqualTo(_newContactId));
        }

        [Test]
        [Order(5)]
        public async Task GetAsync_ListWithSort_ReturnsList()
        {
            // Act
            var data = await ContactClient
                .List()
                .Sort(f => f.CompanyName.Desc())
                .GetAsync()
                .AssertResult();
            var lastItemIndex = data.Items.Count() - 1;

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.Items.Count(), Is.GreaterThan(3));
            Assert.That(data.Items.ElementAt(0).CompanyName, Is.EqualTo("Test company"));
            Assert.That(data.Items.ElementAt(lastItemIndex).CompanyName, Is.EqualTo("Alza.cz a.s."));
        }

        [Test]
        [Order(6)]
        public async Task DeleteAsync_SuccessfullyDeletedContact()
        {
            // Act
            var data = await ContactClient.DeleteAsync(_newContactId).AssertResult();

            // Assert
            Assert.That(data, Is.True);
        }

        [Test]
        public async Task GetAsync_ReturnsList()
        {
            // Act
            var data = await ContactClient.List().GetAsync().AssertResult();

            // Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.Items.Count(), Is.GreaterThan(0));
        }

        private static string CreateUniqueContactName()
        {
            var suffixToAvoidDuplicates = (long)DateTime.Now.TimeOfDay.TotalMilliseconds;
            return $"Seyfor Slovensko {suffixToAvoidDuplicates}";
        }

        private void AssertDeliveryAddress(DeliveryAddressGetModel returnedDeliveryAddress, DeliveryAddressPatchModel expectedDeliveryAddress)
        {
            Assert.That(returnedDeliveryAddress.City, Is.EqualTo(expectedDeliveryAddress.City));
            Assert.That(returnedDeliveryAddress.IsDefault, Is.EqualTo(expectedDeliveryAddress.IsDefault));
            Assert.That(returnedDeliveryAddress.Name, Is.EqualTo(expectedDeliveryAddress.Name));
            Assert.That(returnedDeliveryAddress.PostalCode, Is.EqualTo(expectedDeliveryAddress.PostalCode));
            Assert.That(returnedDeliveryAddress.Street, Is.EqualTo(expectedDeliveryAddress.Street));
            Assert.That(returnedDeliveryAddress.CountryId, Is.Not.Zero);
            Assert.That(returnedDeliveryAddress.Id, Is.Not.Zero);
        }

        private void AssertDeliveryAddress(DeliveryAddressGetModel returnedDeliveryAddress, DeliveryAddressPostModel expectedDeliveryAddress)
        {
            Assert.That(returnedDeliveryAddress.City, Is.EqualTo(expectedDeliveryAddress.City));
            Assert.That(returnedDeliveryAddress.IsDefault, Is.EqualTo(expectedDeliveryAddress.IsDefault));
            Assert.That(returnedDeliveryAddress.Name, Is.EqualTo(expectedDeliveryAddress.Name));
            Assert.That(returnedDeliveryAddress.PostalCode, Is.EqualTo(expectedDeliveryAddress.PostalCode));
            Assert.That(returnedDeliveryAddress.Street, Is.EqualTo(expectedDeliveryAddress.Street));
            Assert.That(returnedDeliveryAddress.CountryId, Is.Not.Zero);
            Assert.That(returnedDeliveryAddress.Id, Is.Not.Zero);
        }

        private void AssertGetModel(ContactGetModel data)
        {
            Assert.That(data.AccountNumber, Is.EqualTo(_contactPostModel.AccountNumber));
            Assert.That(data.BankId, Is.EqualTo(_contactPostModel.BankId));
            Assert.That(data.City, Is.EqualTo(_contactPostModel.City));
            Assert.That(data.CompanyName, Is.EqualTo(_contactPostModel.CompanyName));
            Assert.That(data.CountryId, Is.EqualTo(_contactPostModel.CountryId));
            Assert.That(data.DefaultInvoiceMaturity, Is.EqualTo(_contactPostModel.DefaultInvoiceMaturity));
            AssertDeliveryAddress(data.DeliveryAddresses.First(), _contactPostModel.DeliveryAddresses.First());
            Assert.That(data.DiscountPercentage, Is.EqualTo(_contactPostModel.DiscountPercentage));
            Assert.That(data.Email, Is.EqualTo(_contactPostModel.Email));
            Assert.That(data.Fax, Is.EqualTo(_contactPostModel.Fax));
            Assert.That(data.Firstname, Is.EqualTo(_contactPostModel.Firstname));
            Assert.That(data.Iban, Is.EqualTo(_contactPostModel.Iban));
            Assert.That(data.IdentificationNumber, Is.EqualTo(_contactPostModel.IdentificationNumber));
            Assert.That(data.IsRegisteredForVatOnPay, Is.EqualTo(_contactPostModel.IsRegisteredForVatOnPay));
            Assert.That(data.Mobile, Is.EqualTo(_contactPostModel.Mobile));
            Assert.That(data.Note, Is.EqualTo(_contactPostModel.Note));
            Assert.That(data.Phone, Is.EqualTo(_contactPostModel.Phone));
            Assert.That(data.PostalCode, Is.EqualTo(_contactPostModel.PostalCode));
            Assert.That(data.SendReminders, Is.EqualTo(_contactPostModel.SendReminders));
            Assert.That(data.Street, Is.EqualTo(_contactPostModel.Street));
            Assert.That(data.Surname, Is.EqualTo(_contactPostModel.Surname));
            Assert.That(data.Swift, Is.EqualTo(_contactPostModel.Swift));
            Assert.That(data.VatIdentificationNumber, Is.EqualTo(_contactPostModel.VatIdentificationNumber));
            Assert.That(data.VatIdentificationNumberSk, Is.EqualTo(_contactPostModel.VatIdentificationNumberSk));
            Assert.That(data.Www, Is.EqualTo(_contactPostModel.Www));
        }
    }
}
