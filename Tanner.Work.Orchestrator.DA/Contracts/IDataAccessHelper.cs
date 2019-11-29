using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Tanner.Work.Orchestrator.DA.Contracts
{
    public interface IDataAccessHelper
    {
        Task<SqlConnection> GetOpenConnectionAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
