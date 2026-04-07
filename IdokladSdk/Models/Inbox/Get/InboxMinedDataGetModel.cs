using IdokladSdk.Enums;

namespace IdokladSdk.Models.Inbox.Get
{
    /// <summary>
    /// Inbox mined data get model.
    /// </summary>
    public class InboxMinedDataGetModel
    {
        /// <summary>
        /// Gets or sets raw mined document data.
        /// </summary>
        public string DocumentData { get; set; }

        /// <summary>
        /// Gets or sets mined document id.
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// Gets or sets mining source state.
        /// </summary>
        public MiningSourceState MiningSourceState { get; set; }

        /// <summary>
        /// Gets or sets mining source type.
        /// </summary>
        public MiningSourceType MiningSourceType { get; set; }
    }
}
