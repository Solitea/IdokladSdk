using System.Collections.Generic;
using IdokladSdk.Models.Common;

namespace IdokladSdk.IntegrationTests.Core.Tags.Model
{
    public class EntityTags
    {
        public int Id { get; set; }

        public List<TagDocumentListGetModel> Tags { get; set; }
    }
}
