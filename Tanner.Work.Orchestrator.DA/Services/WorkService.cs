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
    public class WorkService : IDataAccess<WorkModel>
    {
        private readonly IDataAccessHelper _dataAccess;
        private readonly ITraceHelper _traceHelper;
        public WorkService() { }

        public WorkService(IDataAccessHelper dataAccess, ITraceHelper traceHelper)
        {
            _dataAccess = dataAccess;
            _traceHelper = traceHelper;
        }

        public async Task<int> CreateAsync(WorkModel obj)
        {
            int isCreate = 0;
            try
            {
                using (IDbConnection _conn = await _dataAccess.GetOpenConnectionAsync())
                {
                    try
                    {
                        string insert = @"
                                IF NOT EXISTS (SELECT 1 FROM [DBINFORMESCLIENTES].[INFORMECLIENTE].[V_DIRECTORIO_PERSONA] WHERE 
                                   [ID_INFORME_CONSULTADO] = @IdInformeConsultado AND [RUT_INFORME_CONSULTADO] = @RutInformeConsultado 
                                    AND [ID_DIRECTORIO_PERSONA] IS NOT NULL)
                                    BEGIN
                                        INSERT INTO [DIRECTORIOPERSONA].[TDIRECTORIO_PERSONA_CAB]
                                                   ([ID_INFORME_CONSULTADO]
                                                   ,[RUT_INFORME_CONSULTADO]
                                                   ,[TIPO_PERSONA]
                                                   ,[RESULTADO_CONSULTA]
                                                   ,[FECHA_CONSULTA_PERSONA])
                                             VALUES
                                                   (@IdInformeConsultado
                                                   ,@RutInformeConsultado
                                                   ,@TipoPersona
                                                   ,@ResultadoConsulta
                                                   ,@FechaConsultaPersona);
                                        SELECT CAST(SCOPE_IDENTITY() as int);
                                    END;";
                        isCreate = (obj != null) ? await _conn.ExecuteScalarAsync<int>(insert, obj) : 0;


                    }
                    catch (SqlException sqlex)
                    {
                        isCreate = -1;
                        _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(CreateAsync), new Dictionary<string, object>
                        {
                            [nameof(sqlex)] = sqlex
                        });
                    }
                    catch (Exception ex)
                    {
                        isCreate = -2;
                        _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(CreateAsync), new Dictionary<string, object>
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
                _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(CreateAsync), new Dictionary<string, object>
                {
                    [nameof(ex)] = ex
                });
            }
            return isCreate;
        }

        public Task<bool> CreateMultipleAsync(IEnumerable<WorkModel> list)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(WorkModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(WorkModel obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WorkModel>> ListAsync()
        {
            try
            {
                using (IDbConnection _conn = await _dataAccess.GetOpenConnectionAsync())
                {
                    try
                    {

                        string sqlQuery = @" 
                                    SELECT
                                      tb.ID
                                     ,tb.NOMBRE
                                     ,tb.HORA_INICIO
                                    FROM dbo.T_TRABAJO tb";

                        var result = await _conn.QueryAsync<WorkModel>(sqlQuery);

                       // var work = result?.FirstOrDefault();
                        return result.ToList();
                    }
                    catch (SqlException sqlex)
                    {
                        _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(WorkService), new Dictionary<string, object>
                        {
                            [nameof(sqlex)] = sqlex
                        });
                        return null;
                    }
                    catch (Exception ex)
                    {
                        _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(WorkService), new Dictionary<string, object>
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
                _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(WorkService), new Dictionary<string, object>
                {
                    [nameof(ex)] = ex
                });
                return null;
            }
        }

        public Task<IEnumerable<WorkModel>> ListQueryAsync(WorkModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkModel>> ListQueryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WorkModel> ReadAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<WorkModel> ReadAsync(WorkModel obj)
        {
            try
            {
                using (IDbConnection _conn = await _dataAccess.GetOpenConnectionAsync())
                {
                    try
                    {

                        string sqlQuery = @" 
                                    SELECT
                                      tb.ID
                                     ,tb.NOMBRE
                                     ,tb.HORA_INICIO
                                    FROM dbo.T_TRABAJO tb
                                    WHERE tb.ID =  @ID;";

                        var result = (obj != null) ? await _conn.QueryAsync<WorkModel>(sqlQuery, new { ID = obj.Id }) : null;

                        WorkModel work = result?.FirstOrDefault();
                        return work;
                    }
                    catch (SqlException sqlex)
                    {
                        _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(WorkService), new Dictionary<string, object>
                        {
                            [nameof(sqlex)] = sqlex
                        });
                        return null;
                    }
                    catch (Exception ex)
                    {
                        _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(WorkService), new Dictionary<string, object>
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
                _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(WorkService), new Dictionary<string, object>
                {
                    [nameof(ex)] = ex
                });
                return null;
            }
        }

        public Task<bool> UpdateAsync(WorkModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
