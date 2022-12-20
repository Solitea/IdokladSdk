using System;
using System.Threading.Tasks;
using IdokladSdk.Exceptions;
using IdokladSdk.IntegrationTests.Core;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Builders
{
    internal class DokladApiBuilderTests : TestBase
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDokladApi();
        }

        [Test]
        public void HttpClient_BaseAddressChanged_TokenCallThrows()
        {
            // Arrange
            AsyncTestDelegate action = async () => await DokladApi.AccountClient.Agendas.List().GetAsync();

            // Act
            DokladApi.ApiContext.HttpClient.BaseAddress = new Uri("https://api.idoklad.cz");

            // Assert
            Assert.That(action, Throws.Exception.AssignableTo<IdokladSdkException>()
                                .With.Message.EqualTo("HttpClient cannot have BaseAddress set."));
        }
    }
}