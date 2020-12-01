using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdokladSdk.Validation.Detailed.Model
{
    /// <summary>
    /// Results of validation of single property against all its validation attributes.
    /// </summary>
    public class PropertyValidationResult
    {
        /// <summary>
        /// Gets or sets property name.
        /// In case of nested model property it contains qualified name (e.g. MyDocumentAddress.City). In case of property
        /// of model which is contained in list it also contains index of a model instance within collection (e.g. Items[0].Name).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets validation context.
        /// Can be used to get model type, model instance, property display name etc.
        /// </summary>
        public ValidationContext ValidationContext { get; set; }

        /// <summary>
        /// Gets or sets list of results of validation against individual property attributes.
        /// It contains only attributes whose validation failed.
        /// </summary>
        public List<AttributeValidationResult> InvalidAttributes { get; set; }
    }
}
