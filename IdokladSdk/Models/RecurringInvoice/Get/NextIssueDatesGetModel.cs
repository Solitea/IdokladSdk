using System;
using System.Collections.Generic;

namespace IdokladSdk.Models.RecurringInvoice
{
    /// <summary>
    /// NextIssueDatesGetModel.
    /// </summary>
    public class NextIssueDatesGetModel
    {
        /// <summary>
        /// Gets or sets list of recurring invoice next issue dates.
        /// </summary>
        public List<DateTime> NextIssueDates { get; set; }
    }
}
