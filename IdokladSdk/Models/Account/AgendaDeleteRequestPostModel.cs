﻿using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.Account
{
    /// <summary>
    /// AgendaDeleteRequestPostModel.
    /// </summary>
    public class AgendaDeleteRequestPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether changing to a competing product.
        /// </summary>
        public bool IsCompetingProductReason { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether application had few features.
        /// </summary>
        public bool IsFunctionsReason { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether there is other reason.
        /// </summary>
        public bool IsOtherReason { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether application is too expensive.
        /// </summary>
        public bool IsPriceReason { get; set; }

        /// <summary>
        /// Gets or sets changing to a competing product - details.
        /// </summary>
        [StringLength(50)]
        public string TextCompetingProductReason { get; set; }

        /// <summary>
        /// Gets or sets application had few features - details.
        /// </summary>
        [StringLength(900)]
        public string TextFunctionsReason { get; set; }

        /// <summary>
        /// Gets or sets other reason - details.
        /// </summary>
        [StringLength(900)]
        public string TextOtherReason { get; set; }
    }
}
