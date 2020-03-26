using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Requests.SalesOffice;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with sales office endpoints.
    /// </summary>
    public class SalesOfficeClient :
        BaseClient,
        IEntityDetail<SalesOfficeDetail>,
        IEntityList<SalesOfficeList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOfficeClient"/> class.
        /// </summary>
        /// <param name="apiContext">Api context.</param>
        public SalesOfficeClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc />
        public override string ResourceUrl { get; } = "/SalesOffices";

        /// <inheritdoc />
        public SalesOfficeDetail Detail(int id)
        {
            return new SalesOfficeDetail(id, this);
        }

        /// <inheritdoc />
        public SalesOfficeList List()
        {
            return new SalesOfficeList(this);
        }
    }
}
