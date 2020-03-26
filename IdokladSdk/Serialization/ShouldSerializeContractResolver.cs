using System.Reflection;
using IdokladSdk.Models.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Contract resolver for serialization.
    /// </summary>
    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        /// <inheritdoc/>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(NullableProperty<>))
            {
                property.ShouldSerialize = instance =>
                {
                    var nullableProperty = property.DeclaringType.GetProperty(property.PropertyName)?.GetValue(instance, null);
                    var isSet = nullableProperty.GetType()?.GetProperty(nameof(NullableProperty<int>.IsSet))?.GetValue(nullableProperty, null) ?? false;
                    return (bool)isSet;
                };
            }
            else
            {
                property.ShouldSerialize = instance =>
                {
                    var propertyValue = property.DeclaringType.GetProperty(property.PropertyName)?.GetValue(instance, null);
                    return propertyValue != null;
                };
            }

            return property;
        }
    }
}
