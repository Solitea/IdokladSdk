using System;
using System.Collections.Generic;
using IdokladSdk.Enums;
using IdokladSdk.Models.Batch;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Tests.Features.Validation
{
    public partial class ApiResultValidatorTests
    {
        [Test]
        public void ApiResult_CallsHandler_ThrowsExceptionAsync()
        {
            // Arrange
            var issuedInvoiceClient = DokladApi.IssuedInvoiceClient;

            // Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await issuedInvoiceClient.DeleteAsync(NotFoundIssuedInvoiceId));
        }

        [Test]
        public void ApiBatchResult_CallsHandler_ThrowsExceptionAsync()
        {
            // Arrange
            var batchClient = DokladApi.BatchClient;
            var modelsToUpdate = new List<UpdateExportedModel>()
            {
                new UpdateExportedModel
                {
                    Id = -1,
                    EntityType = ExportableEntityType.Contact,
                    Exported = ExportedState.Exported
                },
                new UpdateExportedModel
                {
                    Id = -1,
                    EntityType = ExportableEntityType.CreditNote,
                    Exported = ExportedState.NotExported
                }
            };

            // Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await batchClient.UpdateAsync(modelsToUpdate));
        }
    }
}
