using System;
using IdokladSdk.Models.Common;
using IdokladSdk.Models.Contact;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;

namespace IdokladSdk.Requests.Core.Modifiers.Filters
{
    /// <summary>
    /// Filterable properties of <see cref="ContactListGetModel"/>.
    /// </summary>
    public class ContactFilter : IdFilter
    {
        /// <inheritdoc cref="Metadata.DateLastChange"/>
        public CompareFilterItem<DateTime> DateLastChange { get; set; } = new CompareFilterItem<DateTime>(nameof(Metadata.DateLastChange));

        /// <inheritdoc cref="ContactListGetModel.IdentificationNumber"/>
        public ContainFilterItem<string> IdentificationNumber { get; set; } = new ContainFilterItem<string>(nameof(ContactListGetModel.IdentificationNumber));

        /// <inheritdoc cref="ContactListGetModel.CompanyName"/>
        public ContainFilterItem<string> CompanyName { get; set; } = new ContainFilterItem<string>(nameof(ContactListGetModel.CompanyName));

        /// <inheritdoc cref="ContactListGetModel.Email"/>
        public ContainFilterItem<string> Email { get; set; } = new ContainFilterItem<string>(nameof(ContactListGetModel.Email));

        /// <inheritdoc cref="ContactListGetModel.VatIdentificationNumber"/>
        public ContainFilterItem<string> VatIdentificationNumber { get; set; } = new ContainFilterItem<string>(nameof(ContactListGetModel.VatIdentificationNumber));

        /// <inheritdoc cref="ContactListGetModel.VatIdentificationNumberSk"/>
        public ContainFilterItem<string> VatIdentificationNumberSk { get; set; } = new ContainFilterItem<string>(nameof(ContactListGetModel.VatIdentificationNumberSk));
    }
}
