using System.Collections.Generic;
using System.Threading.Tasks;
using IdokladSdk.Enums;
using IdokladSdk.Models.Batch;

namespace IdokladSdk.NetCore.TestApp.Examples
{
    public class BatchExamples
    {
        private readonly DokladApi _api;

        public BatchExamples(DokladApi api)
        {
            _api = api;
        }

        public async Task SetExportedStateAsync(int invoiceId, int contactId, ExportedState state)
        {
            var batch = CreateBatch(invoiceId, contactId, state);

            var response = await _api.BatchClient.UpdateAsync(batch);
        }

        private static IList<UpdateExportedModel> CreateBatch(int invoiceId, int contactId, ExportedState state)
        {
            var models = new List<UpdateExportedModel>
            {
                new UpdateExportedModel
                {
                    Id = invoiceId,
                    EntityType = ExportableEntityType.IssuedInvoice,
                    Exported = state
                },
                new UpdateExportedModel
                {
                    Id = contactId,
                    EntityType = ExportableEntityType.Contact,
                    Exported = state
                }
            };

            return models;
        }
    }
}
