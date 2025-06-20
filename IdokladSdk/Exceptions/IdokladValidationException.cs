using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using IdokladSdk.Validation.Detailed.Model;

namespace IdokladSdk.Exceptions
{
    /// <summary>
    /// Represents an exception that occurs when validation of a model fails in the iDoklad API.
    /// </summary>
    /// <remarks>This exception is thrown when one or more properties of a model fail validation. It provides
    /// detailed information about the invalid properties through the <see cref="InvalidProperties"/>
    /// property.</remarks>
    public class IdokladValidationException : ValidationException
    {
        private const string DefaultMessage = "Model is not valid.";

        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladValidationException"/> class.
        /// </summary>
        /// <param name="invalidProperties">List of invalid properties.</param>
        public IdokladValidationException(Dictionary<string, PropertyValidationResult> invalidProperties)
            : base(GetMessage(invalidProperties))
        {
            InvalidProperties = invalidProperties ?? throw new ArgumentNullException(nameof(invalidProperties));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdokladValidationException"/> class.
        /// </summary>
        /// <param name="message">List of invalid properties.</param>
        public IdokladValidationException(string message)
            : base(message)
        {
            InvalidProperties = new Dictionary<string, PropertyValidationResult>();
        }

        /// <summary>
        /// Gets all model invalid properties.
        /// </summary>
        public Dictionary<string, PropertyValidationResult> InvalidProperties { get; private set; }

        private static string GetMessage(Dictionary<string, PropertyValidationResult> invalidProperties)
        {
            if (invalidProperties == null || invalidProperties.Count == 0)
            {
                return DefaultMessage;
            }

            var message = new StringBuilder(DefaultMessage);
            message.AppendLine();

            foreach (var property in invalidProperties)
            {
                var propertyName = property.Value.Name;

                foreach (var attribute in property.Value.InvalidAttributes)
                {
                    message.AppendLine(attribute.ValidationAttribute?.FormatErrorMessage(propertyName));
                }
            }

            return message.Length > 0 ? message.Remove(message.Length - 2, 2).ToString() : message.ToString();
        }
    }
}
