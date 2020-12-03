﻿using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Models.ProformaInvoice
{
    /// <summary>
    /// ProformaInvoiceItemPatchModel.
    /// </summary>
    public class ProformaInvoiceItemPatchModel : ValidatableModel, IEntityId
    {
        /// <summary>
        /// Gets or sets item amount.
        /// </summary>
        [Range(0.0, double.MaxValue)]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets item code.
        /// </summary>
        public string Code { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets item name.
        /// </summary>
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price type.
        /// </summary>
        public PriceType? PriceType { get; set; }

        /// <summary>
        /// Gets or sets unit of measure.
        /// </summary>
        [StringLength(20)]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets vat code id.
        /// </summary>
        public NullableProperty<int> VatCodeId { get; set; }

        /// <summary>
        /// Gets or sets vAT rate type.
        /// </summary>
        public VatRateType? VatRateType { get; set; }
    }
}
