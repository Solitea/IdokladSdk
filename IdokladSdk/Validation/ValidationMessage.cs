using System.Collections.Generic;

namespace IdokladSdk
{
    /// <summary>
    /// Validation message with member names.
    /// </summary>
    public class ValidationMessage
    {
        /// <summary>
        /// Gets or sets collection of affected members.
        /// </summary>
        public IEnumerable<string> MemberNames { get; set; }

        /// <summary>
        /// Gets or sets explained validation message based on data annotations.
        /// </summary>
        public string Message { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Message;
        }
    }
}
