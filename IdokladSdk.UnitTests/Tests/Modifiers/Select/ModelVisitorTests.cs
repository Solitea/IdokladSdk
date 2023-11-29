using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using IdokladSdk.Models.Contact;
using IdokladSdk.Requests.Core.Modifiers.Select.Common;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Modifiers.Select
{
    [TestFixture]
    public class ModelVisitorTests
    {
        [Test]
        public void ModelVisitor_ReturnsCorrectPropertyName()
        {
            // Arrange
            var visitor = new ModelVisitor();
            Expression<Func<ContactGetModel, object>> selector = c => new
            {
                CompanyName = c.CompanyName.ToUpper(CultureInfo.InvariantCulture),
                Currency = c.Country.Currency.Name,
                Bank = c.Bank.Name,
                Name = c.Firstname + " " + c.Surname,
                Address = $"{c.Street} {c.City} {c.PostalCode}",
                Discount = c.CompanyName.Length > 10 ? 10.0m : c.DiscountPercentage
            };

            // Act
            visitor.Visit(selector);
            var memberNames = visitor.MemberNames.ToList();

            // Assert
            Assert.That(memberNames.Count, Is.EqualTo(12));
            Assert.That(memberNames, Contains.Item("CompanyName"));
            Assert.That(memberNames, Contains.Item("Country"));
            Assert.That(memberNames, Contains.Item("Country.Currency"));
            Assert.That(memberNames, Contains.Item("Country.Currency.Name"));
            Assert.That(memberNames, Contains.Item("Bank"));
            Assert.That(memberNames, Contains.Item("Bank.Name"));
            Assert.That(memberNames, Contains.Item("Firstname"));
            Assert.That(memberNames, Contains.Item("Surname"));
            Assert.That(memberNames, Contains.Item("Street"));
            Assert.That(memberNames, Contains.Item("City"));
            Assert.That(memberNames, Contains.Item("PostalCode"));
            Assert.That(memberNames, Contains.Item("DiscountPercentage"));
        }
    }
}
