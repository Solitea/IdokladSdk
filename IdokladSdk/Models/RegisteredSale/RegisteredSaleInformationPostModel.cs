using System;
using System.ComponentModel.DataAnnotations;
using IdokladSdk.Models.Base;
using IdokladSdk.Validation.Attributes;

namespace IdokladSdk.Models.RegisteredSale
{
    /// <summary>
    /// RegisteredSaleInformation model for Post endpoints.
    /// </summary>
    public class RegisteredSaleInformationPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets taxpayers security code.
        /// </summary>
        [Required]
        [RegularExpression(@"^([0-9a-fA-F]{8}-){4}[0-9a-fA-F]{8}$")]
        public string Bkp { get; set; }

        /// <summary>
        /// Gets or sets Date of answer.
        /// </summary>
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DateOfAnswer { get; set; }

        /// <summary>
        /// Gets or sets Date of sale.
        /// </summary>
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DateOfSale { get; set; }

        /// <summary>
        /// Gets or sets Date of send.
        /// </summary>
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DateOfSend { get; set; }

        /// <summary>
        /// Gets or sets Fiscal identification code.
        /// </summary>
        [Required]
        [RegularExpression(@"^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-4[0-9a-fA-F]{3}-[89abAB][0-9a-fAF]{3}-[0-9a-fA-F]{12}-[0-9a-fA-F]{2}$")]
        public string Fik { get; set; }

        /// <summary>
        /// Gets or sets Taxpayers signature code.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(344, MinimumLength = 344)]
        public string Pkp { get; set; }

        /// <summary>
        /// Gets or sets Prices and calculations.
        /// </summary>
        [Required]
        public RegisteredSalePrices Prices { get; set; }

        /// <summary>
        /// Gets or sets Receipt number.
        /// </summary>
        [Required]
        [RegularExpression(@"^[0-9a-zA-Z\.,:;/#\-_ ]{1,20}$")]
        public string ReceiptNumber { get; set; }

        /// <summary>
        /// Gets or sets Sales office designation.
        /// </summary>
        [Required]
        [RegularExpression(@"^[1-9][0-9]{0,5}$")]
        public int SalesOfficeDesignation { get; set; }

        /// <summary>
        /// Gets or sets sales pos equipment.
        /// </summary>
        [NullableForeignKey]
        public int? SalesPosEquipmentId { get; set; }

        /// <summary>
        /// Gets or sets Universally unique identifier.
        /// </summary>
        [Required]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Gets or sets VAT of taxpayer.
        /// </summary>
        [Required]
        [RegularExpression(@"^CZ[0-9]{8,10}$")]
        public string VatIdentificationNumber { get; set; }
    }
}
