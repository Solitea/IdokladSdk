using System.ComponentModel.DataAnnotations;
using IdokladSdk.Enums;
using IdokladSdk.Models.Base;

namespace IdokladSdk.Models.RegisteredSale
{
    /// <summary>
    /// ElectronicRecordsOfSales model for Post endpoints.
    /// </summary>
    public class ElectronicRecordsOfSalesPostModel : ValidatableModel
    {
        /// <summary>
        /// Gets or sets eet status.
        /// </summary>
        public ElectronicRecordsOfSalesStatus? EetStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the document is registered in EET.
        /// </summary>
        [Required]
        public bool IsEet { get; set; }

        /// <summary>
        /// Gets or sets eet Registered sale.
        /// </summary>
        public RegisteredSaleInformationPostModel RegisteredSale { get; set; }

        /// <summary>
        /// Gets or sets eet who is responsible for recording sales.
        /// </summary>
        [Required]
        public EetResponsibility EetResponsibility { get; set; }
    }
}
