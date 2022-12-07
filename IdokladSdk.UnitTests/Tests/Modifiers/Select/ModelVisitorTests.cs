using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using IdokladSdk.Models.Contact;
using IdokladSdk.Requests.Core.Modifiers.Select.Common;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Modifiers.Select;

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
        Assert.AreEqual(12, memberNames.Count);
        Assert.Contains("CompanyName", memberNames);
        Assert.Contains("Country", memberNames);
        Assert.Contains("Country.Currency", memberNames);
        Assert.Contains("Country.Currency.Name", memberNames);
        Assert.Contains("Bank", memberNames);
        Assert.Contains("Bank.Name", memberNames);
        Assert.Contains("Firstname", memberNames);
        Assert.Contains("Surname", memberNames);
        Assert.Contains("Street", memberNames);
        Assert.Contains("City", memberNames);
        Assert.Contains("PostalCode", memberNames);
        Assert.Contains("DiscountPercentage", memberNames);
    }
}
