﻿using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Tests.Features.GetCustomModel.Model;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Features.GetCustomModel
{
    [TestFixture]
    public class SelectorTests : TestBase
    {
        protected const int ContactId = 323824;

        public ContactClient ContactClient { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
            ContactClient = DokladApi.ContactClient;
        }

        [Test]
        public async Task GetDetailAsync_WithLambdaReturningAnonymousType_Success()
        {
            // Act
            var contact = await ContactClient.Detail(ContactId)
                .Include(c => c.Bank, c => c.Country.Currency)
                .GetAsync(c => new
                {
                    CompanyName = c.CompanyName.ToUpper(CultureInfo.InvariantCulture),
                    Currency = c.Country.Currency.Name,
                    Bank = c.Bank.Name,
                    Name = c.Firstname + " " + c.Surname,
                    Address = $"{c.Street} {c.City} {c.PostalCode}",
                    Discount = c.CompanyName.Length > 10 ? 10.0m : c.DiscountPercentage
                }).AssertResult();

            // Assert
            Assert.IsNotEmpty(contact.CompanyName);
            Assert.IsNotEmpty(contact.Currency);
            Assert.IsNotEmpty(contact.Bank);
            Assert.IsNotEmpty(contact.Name);
            Assert.IsNotEmpty(contact.Address);
            Assert.NotNull(contact.Discount);
        }

        [Test]
        public async Task GetListAsync_WithLambdaReturningSpecificType_Success()
        {
            // Act
            var contacts = await ContactClient.List()
                .GetAsync(c => new CustomContactModel
                {
                    CompanyName = c.CompanyName.ToUpper(CultureInfo.InvariantCulture),
                    Name = c.Firstname + " " + c.Surname,
                    Address = $"{c.Street} {c.City} {c.PostalCode}",
                    Discount = c.CompanyName.Length > 10 ? 10.0m : c.DiscountPercentage
                }).AssertResult();

            // Assert
            Assert.IsNotEmpty(contacts.Items);
            var contact = contacts.Items.First(c => !string.IsNullOrWhiteSpace(c.Name));
            Assert.IsNotEmpty(contact.CompanyName);
            Assert.IsNotEmpty(contact.Name);
            Assert.IsNotEmpty(contact.Address);
            Assert.NotNull(contact.Discount);
        }
    }
}