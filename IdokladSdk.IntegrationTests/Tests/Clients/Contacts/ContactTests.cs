using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class ContactTests : TestBase
    {
        private readonly string _updatedCompanyName = "Solitea Slovensko, a.s.";
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
        public void Post_SuccessfullyPosted()
        {
            // Arrange
            _contactPostModel = ContactClient.Default().AssertResult();
            _contactPostModel.AccountNumber = "2102290124/2700";
            _contactPostModel.BankId = 18;
            _contactPostModel.City = "Brno";
            _contactPostModel.CompanyName = _updatedCompanyName;
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
            var data = ContactClient.Post(_contactPostModel).AssertResult();
            _newContactId = data.Id;

            // Assert
            Assert.Greater(data.Id, 0);
            AssertGetModel(data);
        }

        [Test]
        [Order(2)]
        public void GetDetail_ReturnsContact()
        {
            // Act
            var data = ContactClient.Detail(_newContactId).Get().AssertResult();

            // Assert
            Assert.AreEqual(_newContactId, data.Id);
            AssertGetModel(data);
        }

        [Test]
        [Order(3)]
        public void Update_SuccessfullyUpdatedContact()
        {
            // Arrange
            var contactPatchModel = new ContactPatchModel
            {
                AccountNumber = "2626708763/1100",
                BankId = 63,
                City = "Bratislava",
                CompanyName = "Solitea Slovensko, a.s.",
                CountryId = 1,
                DefaultInvoiceMaturity = 9,
                DeliveryAddresses = new List<DeliveryAddressPatchModel>
                {
                    new DeliveryAddressPatchModel
                    {
                        City = "Brno",
                        Name = "Money S5",
                        Id = 0,
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
            var data = ContactClient.Update(contactPatchModel).AssertResult();
            _dateLastChange = data.Metadata.DateLastChange;

            // Assert
            Assert.AreEqual(contactPatchModel.Id, data.Id);
            Assert.AreEqual(contactPatchModel.AccountNumber, data.AccountNumber);
            Assert.AreEqual(contactPatchModel.BankId.Value, data.BankId);
            Assert.AreEqual(contactPatchModel.City, data.City);
            Assert.AreEqual(contactPatchModel.CompanyName, data.CompanyName);
            Assert.AreEqual(contactPatchModel.CountryId, data.CountryId);
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
        public void GetListWithFilter_ReturnsList()
        {
            // Act
            var data = ContactClient
                .List()
                .Filter(f => f.CompanyName.Contains("Solitea"))
                .Filter(f => f.DateLastChange.IsGreaterThanOrEqual(_dateLastChange))
                .Get()
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.Greater(data.Items.Count(), 0);
            Assert.AreEqual(_newContactId, data.Items.ElementAt(0).Id);
        }

        [Test]
        [Order(5)]
        public void GetListWithSort_ReturnsList()
        {
            // Act
            var data = ContactClient
                .List()
                .Sort(f => f.CompanyName.Desc())
                .Get()
                .AssertResult();

            // Assert
            Assert.NotNull(data);
            Assert.Greater(data.Items.Count(), 2);
            Assert.AreEqual("Test company", data.Items.ElementAt(0).CompanyName);
            Assert.AreEqual(_updatedCompanyName, data.Items.ElementAt(1).CompanyName);
            Assert.AreEqual("Alza.cz a.s.", data.Items.ElementAt(2).CompanyName);
        }

        [Test]
        [Order(6)]
        public void Delete_SuccessfullyDeletedContact()
        {
            // Act
            var data = ContactClient.Delete(_newContactId).AssertResult();

            // Assert
            Assert.True(data);
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
