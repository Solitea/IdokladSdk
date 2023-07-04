using System;
using System.Collections.Generic;
using System.Text;

namespace IdokladSdk.Enums
{
    public enum IssuedDocumentTemplateItemType
    {
        /// <summary>
        /// Normal issued document template item
        /// </summary>
        ItemTypeNormal = 0,

        /// <summary>
        /// Round issued document template item
        /// </summary>
        ItemTypeRound = 1,

        /// <summary>
        /// Reduced item for accounted by proforma invoices
        /// </summary>
        ItemTypeReduce = 2
    }
}
