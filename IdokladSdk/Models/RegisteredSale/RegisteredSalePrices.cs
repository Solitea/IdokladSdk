using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Models.RegisteredSale
{
    /// <summary>
    /// Prices of registered sale.
    /// </summary>
    public class RegisteredSalePrices
    {
        /// <summary>
        /// Gets or sets Base tax basic rate.
        /// </summary>
        [Required]
        public decimal BaseTaxBasicRateHc { get; set; }

        /// <summary>
        /// Gets or sets Base tax first reduced rate.
        /// </summary>
        [Required]
        public decimal BaseTaxReducedRate1Hc { get; set; }

        /// <summary>
        /// Gets or sets Base tax second reduced rate.
        /// </summary>
        [Required]
        public decimal BaseTaxReducedRate2Hc { get; set; }

        /// <summary>
        /// Gets or sets Base tax zero rate.
        /// </summary>
        [Required]
        public decimal BaseTaxZeroRateHc { get; set; }

        /// <summary>
        /// Gets or sets Tax basic rate.
        /// </summary>
        [Required]
        public decimal TaxBasicRateHc { get; set; }

        /// <summary>
        /// Gets or sets Tax first reduced rate.
        /// </summary>
        [Required]
        public decimal TaxReducedRate1Hc { get; set; }

        /// <summary>
        /// Gets or sets Tax second reduced rate.
        /// </summary>
        [Required]
        public decimal TaxReducedRate2Hc { get; set; }

        /// <summary>
        /// Gets or sets Total advance payment.
        /// </summary>
        [Required]
        public decimal TotalAdvancePayment { get; set; }

        /// <summary>
        /// Gets or sets Total from advance payment.
        /// </summary>
        [Required]
        public decimal TotalFromAdvancePayment { get; set; }

        /// <summary>
        /// Gets or sets Total travel service.
        /// </summary>
        [Required]
        public decimal TotalTravelServiceHc { get; set; }

        /// <summary>
        /// Gets or sets Total used goods.
        /// </summary>
        [Required]
        public decimal TotalUsedGoodsBasicRateHc { get; set; }

        /// <summary>
        /// Gets or sets Total used goods first reduced rate.
        /// </summary>
        [Required]
        public decimal TotalUsedGoodsReducedRate1Hc { get; set; }

        /// <summary>
        /// Gets or sets Total used goods second reduced rate.
        /// </summary>
        [Required]
        public decimal TotalUsedGoodsReducedRate2Hc { get; set; }

        /// <summary>
        /// Gets or sets Total with vat.
        /// </summary>
        [Required]
        public decimal TotalWithVatHc { get; set; }
    }
}
