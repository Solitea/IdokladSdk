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
            _contactPostModel = await ContactClient.DefaultAsync().AssertResult();
            _contactPostModel.AccountNumber = "2102290124";
            _contactPostModel.BankId = 18;
            _contactPostModel.City = "Brno";
            _contactPostModel.CompanyName = "Seyfor Slovensko, a.s.";
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
            Assert.Greater(data.Id, 0);
            AssertGetModel(data);
        }

        [Test]
        [Order(2)]
        public async Task GetDetail_ReturnsContact()
        {
            // Act
            var data = await ContactClient.Detail(_newContactId).GetAsync().AssertResult();

            // Assert
            Assert.AreEqual(_newContactId, data.Id);
            AssertGetModel(data);
        }

        [Test]
        [Order(3)]
        public async Task Update_SuccessfullyUpdatedContact()
        {
            // Arrange
            var contactPatchModel = new ContactPatchModel
            {
                AccountNumber = "2626708763",
                BankId = 63,
                City = "Bratislava",
                CompanyName = "Seyfor Česko, a.s.",
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
            Assert.AreEqual(contactPatchModel.Id, data.Id);
            Assert.AreEqual(contactPatchModel.AccountNumber, data.AccountNumber);
            Assert.AreEqual(contactPatchModel.BankId.Value, data.BankId);
            Assert.AreEqual(contactPatchModel.City, data.City);
            Assert.AreEqual(contactPatchModel.CompanyName, data.CompanyName);
            Assert.AreEqual(contactPatchModel.CountryId.Value, data.CountryId);
            Assert.AreEqual(contactPatchModel.DefaultInvoiceMaturity.Value, data.DefaultInvoiceMaturity);
            AssertDeliveryAddress(data.DeliveryAddresses.First(), contactPatchModel.DeliveryAddresses.First());
            Assert.AreEqual(contactPatchModel.DiscountPercentage, data.DiscountPercentage);
            Assert.AreEqual(contactPatchModel.Email, data.Email);
            Assert.AreEqual(contactPatchModel.Fax, data.Fax);
            Assert.AreEqual(contactPatchModel.Firstname, data.Firstname);
            Assert.AreEqual(contactPatchModel.Iban, data.Iban);
            Assert.AreEqual(contactPatchModel.IdentificationNumber, data.IdentificationNumber);
            Assert.AreEqual(false, data.IsRegisteredForVatOnPay);
            Assert.AreEqual(contactPatchModel.Mobile, data.Mobile);
            Assert.AreEqual(contactPatchModel.Note, data.Note);
            Assert.AreEqual(contactPatchModel.Phone, data.Phone);
            Assert.AreEqual(contactPatchModel.PostalCode, data.PostalCode);
            Assert.AreEqual(contactPatchModel.SendReminders, data.SendReminders);
            Assert.AreEqual(contactPatchModel.Street, data.Street);
            Assert.AreEqual(contactPatchModel.Surname, data.Surname);
            Assert.AreEqual(contactPatchModel.Swift, data.Swift);
            Assert.AreEqual(contactPatchModel.VatIdentificationNumber, data.VatIdentificationNumber);
            Assert.AreEqual(contactPatchModel.VatIdentificationNumberSk, data.VatIdentificationNumberSk);
            Assert.AreEqual(contactPatchModel.Www, data.Www);
        }

        [Test]
        [Order(4)]
        public async Task GetListWithFilter_ReturnsList()
        {
            // Act
            var data = await ContactClient
                .List()
                .Filter(f => f.CompanyName.Contains("Seyfor"))
                .Filter(f => f.DateLastChange.IsGreaterThanOrEqual(_dateLastChange))
                .GetAsync()
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.Greater(data.Items.Count(), 0);
            Assert.AreEqual(_newContactId, data.Items.ElementAt(0).Id);
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
            Assert.NotNull(data);
            Assert.Greater(data.Items.Count(), 3);
            Assert.AreEqual("Test company", data.Items.ElementAt(0).CompanyName);
            Assert.AreEqual("Alza.cz a.s.", data.Items.ElementAt(lastItemIndex).CompanyName);
        }

        [Test]
        [Order(6)]
        public async Task DeleteAsync_SuccessfullyDeletedContact()
        {
            // Act
            var data = await ContactClient.DeleteAsync(_newContactId).AssertResult();

            // Assert
            Assert.True(data);
        }

        [Test]
        public async Task GetAsync_ReturnsList()
        {
            // Act
            var data = await ContactClient.List().GetAsync().AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.Greater(data.Items.Count(), 0);
        }

        private void AssertDeliveryAddress(DeliveryAddressGetModel returnedDeliveryAddress, DeliveryAddressPatchModel expecredDeliveryAddress)
        {
            Assert.AreEqual(expecredDeliveryAddress.City, returnedDeliveryAddress.City);
            Assert.AreEqual(expecredDeliveryAddress.IsDefault, returnedDeliveryAddress.IsDefault);
            Assert.AreEqual(expecredDeliveryAddress.Name, returnedDeliveryAddress.Name);
            Assert.AreEqual(expecredDeliveryAddress.PostalCode, returnedDeliveryAddress.PostalCode);
            Assert.AreEqual(expecredDeliveryAddress.Street, returnedDeliveryAddress.Street);
            Assert.NotZero(returnedDeliveryAddress.CountryId);
            Assert.NotZero(returnedDeliveryAddress.Id);
        }

        private void AssertDeliveryAddress(DeliveryAddressGetModel returnedDeliveryAddress, DeliveryAddressPostModel expecredDeliveryAddress)
        {
            Assert.AreEqual(expecredDeliveryAddress.City, returnedDeliveryAddress.City);
            Assert.AreEqual(expecredDeliveryAddress.IsDefault, returnedDeliveryAddress.IsDefault);
            Assert.AreEqual(expecredDeliveryAddress.Name, returnedDeliveryAddress.Name);
            Assert.AreEqual(expecredDeliveryAddress.PostalCode, returnedDeliveryAddress.PostalCode);
            Assert.AreEqual(expecredDeliveryAddress.Street, returnedDeliveryAddress.Street);
            Assert.NotZero(returnedDeliveryAddress.CountryId);
            Assert.NotZero(returnedDeliveryAddress.Id);
        }

        private void AssertGetModel(ContactGetModel data)
        {
            Assert.AreEqual(_contactPostModel.AccountNumber, data.AccountNumber);
            Assert.AreEqual(_contactPostModel.BankId, data.BankId);
            Assert.AreEqual(_contactPostModel.City, data.City);
            Assert.AreEqual(_contactPostModel.CompanyName, data.CompanyName);
            Assert.AreEqual(_contactPostModel.CountryId, data.CountryId);
            Assert.AreEqual(_contactPostModel.DefaultInvoiceMaturity, data.DefaultInvoiceMaturity);
            AssertDeliveryAddress(data.DeliveryAddresses.First(), _contactPostModel.DeliveryAddresses.First());
            Assert.AreEqual(_contactPostModel.DiscountPercentage, data.DiscountPercentage);
            Assert.AreEqual(_contactPostModel.Email, data.Email);
            Assert.AreEqual(_contactPostModel.Fax, data.Fax);
            Assert.AreEqual(_contactPostModel.Firstname, data.Firstname);
            Assert.AreEqual(_contactPostModel.Iban, data.Iban);
            Assert.AreEqual(_contactPostModel.IdentificationNumber, data.IdentificationNumber);
            Assert.AreEqual(_contactPostModel.IsRegisteredForVatOnPay, data.IsRegisteredForVatOnPay);
            Assert.AreEqual(_contactPostModel.Mobile, data.Mobile);
            Assert.AreEqual(_contactPostModel.Note, data.Note);
            Assert.AreEqual(_contactPostModel.Phone, data.Phone);
            Assert.AreEqual(_contactPostModel.PostalCode, data.PostalCode);
            Assert.AreEqual(_contactPostModel.SendReminders, data.SendReminders);
            Assert.AreEqual(_contactPostModel.Street, data.Street);
            Assert.AreEqual(_contactPostModel.Surname, data.Surname);
            Assert.AreEqual(_contactPostModel.Swift, data.Swift);
            Assert.AreEqual(_contactPostModel.VatIdentificationNumber, data.VatIdentificationNumber);
            Assert.AreEqual(_contactPostModel.VatIdentificationNumberSk, data.VatIdentificationNumberSk);
            Assert.AreEqual(_contactPostModel.Www, data.Www);
        }
    }
}
