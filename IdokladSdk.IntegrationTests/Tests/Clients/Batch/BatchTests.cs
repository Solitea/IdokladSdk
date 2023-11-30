using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.IntegrationTests.Core;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.Models.Batch;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Clients.Batch
{
    public class BatchTests : TestBase
    {
        private IReadOnlyList<(int Id, ExportableEntityType Type)> _entities;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            InitDokladApi();
            _entities = new List<(int, ExportableEntityType)>()
        {
            (913242, ExportableEntityType.IssuedInvoice),
            (323823, ExportableEntityType.Contact)
        }.AsReadOnly();
        }

        [Test]
        public async Task UpdateAsync_SucessfullySetExportedState_Exported()
        {
            // Arrange
            var modelsToUpdate = new List<UpdateExportedModel>();
            var exportedState = ExportedState.Exported;

            foreach (var (id, type) in _entities)
            {
                modelsToUpdate.Add(new UpdateExportedModel
                {
                    Id = id,
                    EntityType = type,
                    Exported = exportedState
                });
            }

            // Act
            var results = await DokladApi.BatchClient.UpdateAsync(modelsToUpdate).AssertResult();

            // Assert
            Assert.Multiple(() =>
            {
                foreach (var result in results)
                {
                    Assert.That(result.Exported, Is.EqualTo(exportedState));
                }
            });
        }

        [Test]
        public async Task Update_SucessfullySetExportedState_NotExported()
        {
            // Arrange
            var modelsToUpdate = new List<UpdateExportedModel>();
            var exportedState = ExportedState.NotExported;

            foreach (var (id, type) in _entities)
            {
                modelsToUpdate.Add(new UpdateExportedModel
                {
                    Id = id,
                    EntityType = type,
                    Exported = exportedState
                });
            }

            // Act
            var results = await DokladApi.BatchClient.UpdateAsync(modelsToUpdate).AssertResult();

            // Assert
            Assert.Multiple(() =>
            {
                foreach (var result in results)
                {
                    Assert.That(result.Exported, Is.EqualTo(exportedState));
                }
            });
        }

        [Test]
        public void Update_ValidationFails_MinimumItemCount()
        {
            // Arrange
            var modelsToUpdate = new List<UpdateExportedModel>();

            // Act + Assert
            Assert.ThrowsAsync<ValidationException>(async () => await DokladApi.BatchClient.UpdateAsync(modelsToUpdate));
        }

        [Test]
        public void Update_ValidationFails_MaximumItemCount()
        {
            // Arrange
            var modelsToUpdate = new List<UpdateExportedModel>();

            for (int i = 0; i < 51; i++)
            {
                modelsToUpdate.Add(new UpdateExportedModel());
            }

            // Act + Assert
            Assert.ThrowsAsync<ValidationException>(async () => await DokladApi.BatchClient.UpdateAsync(modelsToUpdate));
        }
    }
}
