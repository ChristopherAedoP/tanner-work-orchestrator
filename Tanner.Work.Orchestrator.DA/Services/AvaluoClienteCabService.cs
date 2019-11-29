using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanner.Telemetry.AppInsights;
using Tanner.Work.Orchestrator.DA.Contracts;
using Tanner.Work.Orchestrator.DA.Models;

namespace Tanner.Work.Orchestrator.DA.Services
{
    public class AvaluoClienteCabService : IDataAccess<AvaluoClienteCab>
    {
        private readonly IDataAccessHelper _dataAccess;
        private readonly ITraceHelper _traceHelper;

        public AvaluoClienteCabService() { }

        public AvaluoClienteCabService(IDataAccessHelper dataAccess, ITraceHelper traceHelper)
        {
            _dataAccess = dataAccess;
            _traceHelper = traceHelper;
        }

        public async Task<int> CreateAsync(AvaluoClienteCab obj)
        {
            int isCreate = 0;
            try
            {
                using (IDbConnection _conn = await _dataAccess.GetOpenConnectionAsync())
                {
                    try
                    {
                        string insert = @"
                                 IF NOT EXISTS (SELECT 1 FROM [INFORMECLIENTE].[V_AVALUO_BIEN] WHERE 
                                    [ID_INFORME_CONSULTADO] = @IdInformeConsultado AND [RUT_INFORME_CONSULTADO] =  @RutInformeConsultado AND [ID_AVALUO_BIEN] IS NOT NULL)
                                    BEGIN
                                            INSERT INTO [AVALUOBIEN].[TAVALUO_BIEN_CAB]
                                                       ([ID_INFORME_CONSULTADO]
                                                       ,[RUT_INFORME_CONSULTADO]
                                                       ,[EXISTE_DETALLE_AVALUO]
                                                       ,[NUMERO_PROPIEDADES]
                                                       ,[FECHA_CONSULTA_AVALUO])
                                                 VALUES
                                                       (@IdInformeConsultado,
                                                        @RutInformeConsultado,
                                                        @ExisteDetalleAvaluo,
                                                        @NumeroPropiedades,
                                                        @FechaConsultaAvaluo);
                                            SELECT CAST(SCOPE_IDENTITY() as int);
                                    END";

                        isCreate = (obj != null) ? await _conn.ExecuteScalarAsync<int>(insert, obj) : 0;
                    }
                    catch (SqlException sqlex)
                    {
                        isCreate = -1;
                        _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(AvaluoClienteCabService), new Dictionary<string, object>
                        {
                            [nameof(sqlex)] = sqlex
                        });
                    }
                    catch (Exception ex)
                    {
                        isCreate = -2;
                        _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(AvaluoClienteCabService), new Dictionary<string, object>
                        {
                            [nameof(ex)] = ex
                        });
                    }
                    finally
                    {
                        if (_conn != null)
                        {
                            _conn.Close();
                            _conn.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                isCreate = -3;
                _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(AvaluoClienteCabService), new Dictionary<string, object>
                {
                    [nameof(ex)] = ex
                });
            }
            return isCreate;
        }

        public Task<bool> CreateMultipleAsync(IEnumerable<AvaluoClienteCab> list)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(AvaluoClienteCab obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(AvaluoClienteCab obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AvaluoClienteCab>> ListAsync()
        {
            throw new NotImplementedException();

        }

        public Task<IEnumerable<AvaluoClienteCab>> ListQueryAsync(AvaluoClienteCab obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AvaluoClienteCab>> ListQueryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AvaluoClienteCab> ReadAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AvaluoClienteCab> ReadAsync(AvaluoClienteCab obj)
        {
            try
            {
                using (IDbConnection _conn = await _dataAccess.GetOpenConnectionAsync())
                {
                    try
                    {
                        string sqlQuery = @"
                               SELECT TOP 1 [ID_AVALUO_BIEN] AS [IdAvaluoBien]
                                       ,[ID_INFORME_CONSULTADO] AS [IdInformeConsultado]
                                       ,[RUT_INFORME_CONSULTADO] AS [RutInformeConsultado]
                                       ,[EXISTE_DETALLE_AVALUO] AS [ExisteDetalleAvaluo]
								       ,[NUMERO_PROPIEDADES] AS [NumeroPropiedades]
								       ,[FECHA_CONSULTA_AVALUO] AS [FechaConsultaAvaluo]
                                       ,NULL AS [InformeConsultado] 
                                  FROM [INFORMECLIENTE].[V_AVALUO_BIEN]
                                  WHERE [ID_INFORME_CONSULTADO] = @ID
									    AND [RUT_INFORME_CONSULTADO] = @RUT;";
                        var result = (obj != null) ? await _conn.QueryAsync<AvaluoClienteCab>(sqlQuery, new { ID = obj.IdInformeConsultado, RUT = obj.RutInformeConsultado }) : null;
                        AvaluoClienteCab cabecera = result?.FirstOrDefault();
                        return cabecera;
                    }
                    catch (SqlException sqlex)
                    {
                        _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(AvaluoClienteCabService), new Dictionary<string, object>
                        {
                            [nameof(sqlex)] = sqlex
                        });
                        return null;
                    }
                    catch (Exception ex)
                    {
                        _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(AvaluoClienteCabService), new Dictionary<string, object>
                        {
                            [nameof(ex)] = ex
                        });
                        return null;
                    }
                    finally
                    {
                        if (_conn != null)
                        {
                            _conn.Close();
                            _conn.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(AvaluoClienteCabService), new Dictionary<string, object>
                {
                    [nameof(ex)] = ex
                });
                return null;
            }
        }

        public Task<bool> UpdateAsync(AvaluoClienteCab obj)
        {
            throw new NotImplementedException();
        }
    }
}

