using System;
using IdokladSdk.Enums;

namespace IdokladSdk.Models.Log
{
    /// <summary>
    /// IssuedDocumentPaymentGetModel.
    /// </summary>
    public class LogGetModel
    {
        /// <summary>
        /// Gets or sets action type.
        /// </summary>
        public LogActionType ActionType { get; set; }

        /// <summary>
        /// Gets or sets entity type.
        /// </summary>
        public LogEntityType EntityType { get; set; }

        /// <summary>
        /// Gets or sets date of action.
        /// </summary>
        public DateTime DateOfAction { get; set; }

        /// <summary>
        /// Gets or sets entity id.
        /// </summary>
        public int Id { get; set; }
    }
}
