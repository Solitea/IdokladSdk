using IdokladSdk.Models.Common;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Serializer for Nullable property <see cref="NullableProperty{T}"/>.
    /// </summary>
    public class PatchRequestJsonSerializer : CommonJsonSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatchRequestJsonSerializer"/> class.
        /// </summary>
        public PatchRequestJsonSerializer()
        {
            Serializer.ContractResolver = new ShouldSerializeContractResolver();
        }
    }
}
