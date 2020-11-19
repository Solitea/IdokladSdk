using System;
using System.Linq;
using IdokladSdk.Models.Notification.List;
using IdokladSdk.Models.Notification.NotificationData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IdokladSdk.Serialization
{
    /// <summary>
    /// JSON converter for <see cref="NotificationListGetModel"/>.
    /// </summary>
    public class NotificationJsonConverter : JsonConverter
    {
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (serializer is null)
            {
                throw new ArgumentNullException(nameof(serializer));
            }

            JObject jObject = JObject.Load(reader);

            var notification = new NotificationListGetModel();
            serializer.Populate(jObject.CreateReader(), notification);
            notification.NotificationData = GetNotificationData(jObject, serializer);

            return notification;
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            if (objectType is null)
            {
                throw new ArgumentNullException(nameof(objectType));
            }

            return objectType == typeof(NotificationListGetModel);
        }

        private NotificationDataGetModel GetNotificationData(JObject jObject, JsonSerializer serializer)
        {
            var notificationType = GetNotificationDataType(jObject);

            if (notificationType != null)
            {
                var notificationData = jObject[nameof(NotificationListGetModel.NotificationData)] as JObject;
                var instance = Activator.CreateInstance(notificationType);
                serializer.Populate(notificationData.CreateReader(), instance);
                return instance as NotificationDataGetModel;
            }

            return null;
        }

        private Type GetNotificationDataType(JObject jObject)
        {
            var typeName = jObject[nameof(NotificationListGetModel.NotificationType)].Value<string>();
            var fullName = $"{typeof(NotificationDataGetModel).Namespace}.{typeName}";
            return GetType().Assembly.DefinedTypes.FirstOrDefault(t => t.FullName == fullName);
        }
    }
}
