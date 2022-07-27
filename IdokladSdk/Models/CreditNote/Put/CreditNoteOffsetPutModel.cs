using System;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.CreditNote.Put
{
    /// <summary>
    /// CreditNoteOffsetPutModel.
    /// </summary>
    public class CreditNoteOffsetPutModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets date of payment.
        /// </summary>
        [DateGreaterOrEqualThan(Constants.DefaultDateTimeString, true)]
        public DateTime? DateOfPayment { get; set; }
    }
}
