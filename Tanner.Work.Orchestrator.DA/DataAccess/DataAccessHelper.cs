using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tanner.Telemetry.AppInsights;
using Tanner.Work.Orchestrator.DA.Contracts;
using Tanner.Work.Orchestrator.DA.Models;

namespace Tanner.Work.Orchestrator.DA.DataAccess
{
    public class DataAccessHelper : IDataAccessHelper
    {
        private readonly DataAccessSetting _settingDA;
        private readonly ITraceHelper _traceHelper;
        public DataAccessHelper(DataAccessSetting settingDA, ITraceHelper traceHelper)
        {
            _settingDA = settingDA;
            _traceHelper = traceHelper;
        }

        public async Task<SqlConnection> GetOpenConnectionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SqlConnection conn = new SqlConnection();
            int retry = Convert.ToInt16(_settingDA.Retry ?? "0");
            do
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.ConnectionString = _settingDA.InformesClientes ?? string.Empty;
                        await conn.OpenAsync(cancellationToken).ConfigureAwait(false);
                        retry = 0;
                    }
                }
                catch (SqlException sqlex)
                {
                    if (retry <= 3)
                    {
                        var message = $"Ha ocurrido un error inesperado al intentar iniciar la conexión con la base de datos [{_settingDA.InformesClientes}]." + sqlex.Message;
                        _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(DataAccessHelper), new Dictionary<string, object>
                        {
                            [nameof(message)] = message,
                            [nameof(sqlex)] = sqlex
                        });
                    }
                    retry--;
                    Thread.Sleep(Convert.ToInt16(_settingDA.RetryMiliseconds ?? "1000"));
                }
                catch (Exception ex)
                {
                    var message = $"Ha ocurrido un error inesperado al intentar iniciar la conexión con la base de datos [{_settingDA.InformesClientes}]." + ex.Message;
                    _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(DataAccessHelper), new Dictionary<string, object>
                    {
                        [nameof(message)] = message,
                        [nameof(ex)] = ex
                    });
                }

            }
            while (retry > 0);
            return conn;
        }
    }
}
