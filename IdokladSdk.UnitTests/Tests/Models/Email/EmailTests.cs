using System.Collections.Generic;
using IdokladSdk.Models.Email;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Models.Email;

[TestFixture]
public class EmailTests
{
    [Test]
    [TestCaseSource(nameof(GetSettings))]
    public void HasRecipients_Validate(EmailSettings settings, bool expected)
    {
        Assert.That(settings.HasRecipients(), Is.EqualTo(expected));
    }

    private static IEnumerable<object> GetSettings()
    {
        return new List<object>
        {
            new object[] { new CreditNoteEmailSettings(), false },
            new object[] { new CreditNoteEmailSettings { SendToAccountant = true }, true },
            new object[] { new CreditNoteEmailSettings { SendToPartner = true }, true },
            new object[] { new CreditNoteEmailSettings { SendToSelf = true }, true },
            new object[] { new CreditNoteEmailSettings { OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new CreditNoteEmailSettings { SendToAccountant = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new CreditNoteEmailSettings { SendToPartner = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new CreditNoteEmailSettings { SendToSelf = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new CreditNoteEmailSettings { SendToAccountant = true, SendToPartner = true, SendToSelf = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new IssuedInvoiceEmailSettings(), false },
            new object[] { new IssuedInvoiceEmailSettings { SendToAccountant = true }, true },
            new object[] { new IssuedInvoiceEmailSettings { SendToPartner = true }, true },
            new object[] { new IssuedInvoiceEmailSettings { SendToSelf = true }, true },
            new object[] { new IssuedInvoiceEmailSettings { OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new IssuedInvoiceEmailSettings { SendToAccountant = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new IssuedInvoiceEmailSettings { SendToPartner = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new IssuedInvoiceEmailSettings { SendToSelf = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new IssuedInvoiceEmailSettings { SendToAccountant = true, SendToPartner = true, SendToSelf = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new ProformaInvoiceEmailSettings(), false },
            new object[] { new ProformaInvoiceEmailSettings { SendToAccountant = true }, true },
            new object[] { new ProformaInvoiceEmailSettings { SendToPartner = true }, true },
            new object[] { new ProformaInvoiceEmailSettings { SendToSelf = true }, true },
            new object[] { new ProformaInvoiceEmailSettings { OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new ProformaInvoiceEmailSettings { SendToAccountant = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new ProformaInvoiceEmailSettings { SendToPartner = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new ProformaInvoiceEmailSettings { SendToSelf = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new ProformaInvoiceEmailSettings { SendToAccountant = true, SendToPartner = true, SendToSelf = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new ReceivedInvoiceEmailSettings(), false },
            new object[] { new ReceivedInvoiceEmailSettings { SendToAccountant = true }, true },
            new object[] { new ReceivedInvoiceEmailSettings { SendToSelf = true }, true },
            new object[] { new ReceivedInvoiceEmailSettings { OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new ReceivedInvoiceEmailSettings { SendToAccountant = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new ReceivedInvoiceEmailSettings { SendToSelf = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new ReceivedInvoiceEmailSettings { SendToAccountant = true,  SendToSelf = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new SalesOrderEmailSettings(), false },
            new object[] { new SalesOrderEmailSettings { SendToPartner = true }, true },
            new object[] { new SalesOrderEmailSettings { OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
            new object[] { new SalesOrderEmailSettings { SendToPartner = true, OtherRecipients = new List<string> { "qquc@furusato.tokyo" } }, true },
        };
    }
}
