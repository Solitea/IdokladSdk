using IdokladSdk.Clients;
using IdokladSdk.Models.Common;

namespace IdokladSdk.Serialization
{
    /// <summary>
    /// Serializer setting for Nullable property <see cref="NullableProperty{T}"/>.
    /// </summary>
    public class PatchRequestJsonSerializerSettings : CommonJsonSerializerSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatchRequestJsonSerializerSettings" /> class.
        /// </summary>
        public PatchRequestJsonSerializerSettings()
            : base()
        {
            ContractResolver = new ShouldSerializeContractResolver();
        }
    }
}
