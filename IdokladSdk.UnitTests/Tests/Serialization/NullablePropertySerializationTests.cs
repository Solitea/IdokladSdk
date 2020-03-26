using System;
using IdokladSdk.Clients;
using IdokladSdk.UnitTests.Tests.Serialization.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Serialization
{
    /// <summary>
    /// NullablePropertySerializationTests.
    /// </summary>
    [TestFixture]
    public class NullablePropertySerializationTests
    {
        [Test]
        public void NullableProperties_AreCorrectlySerialized()
        {
            // Arrange
            var entity1 = new EntityWithNormalProperties
            {
                Date = new DateTime(2020, 04, 22, 10, 30, 30),
                Decimal = 314159.26m
            };
            var entity2 = new EntityWithNullableProperties()
            {
                Date = new DateTime(2020, 04, 22, 10, 30, 30),
                Decimal = 314159.26m
            };

            // Act
            var json1 = Serialize(entity1);
            var json2 = Serialize(entity2);

            // Assert
            Assert.AreEqual(json1, json2);
        }

        [Test]
        public void NullableProperty_Unset_IsNotSerialized()
        {
            // Arrange
            var entity = new TestEntity();

            // Act
            var json = Serialize(entity);

            // Assert
            Assert.False(json.Contains(nameof(TestEntity.OtherEntityId)));
        }

        [Test]
        public void NullableProperty_Set_IsSerialized()
        {
            // Arrange
            var entity = new TestEntity
            {
                OtherEntityId = 1
            };

            // Act
            var json = Serialize(entity);

            // Assert
            Assert.True(json.Contains(nameof(TestEntity.OtherEntityId)));
        }

        [Test]
        public void NullableProperty_SetToNull_IsSerialized()
        {
            // Arrange
            var entity = new TestEntity
            {
                OtherEntityId = null
            };

            // Act
            var json = Serialize(entity);

            // Assert
            Assert.True(json.Contains(nameof(TestEntity.OtherEntityId)));
        }

        private string Serialize(object entity)
        {
            return JsonConvert.SerializeObject(entity, new JsonSerializerSettings
            {
                ContractResolver = new ShouldSerializeContractResolver()
            });
        }
    }
}
