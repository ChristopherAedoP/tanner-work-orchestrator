using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tanner.Telemetry.AppInsights;
using Tanner.Work.Orchestrator.API.Contracts;
using Tanner.Work.Orchestrator.DA.Contracts;
using Tanner.Work.Orchestrator.DA.Models;

namespace Tanner.Work.Orchestrator.API.Business
{
    public class WorkBusiness : IWorkBusiness
    {

        private readonly IDataAccess<WorkModel> _dataAccessWork;
        private readonly ITraceHelper _traceHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAccessWork"></param>
        public WorkBusiness( IDataAccess<WorkModel> dataAccessWork , ITraceHelper traceHelper)
        {
            _dataAccessWork = dataAccessWork;
            _traceHelper = traceHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<WorkModel>> ListAsync()
        {
            List<WorkModel> result = null;
            try
            {

                return await _dataAccessWork.ListAsync();
                
            }
            catch (Exception ex)
            {
                _traceHelper.TraceInfo(TraceInfoTypes.Error, nameof(ListAsync), new Dictionary<string, object>
                {
                    [nameof(ex)] = ex
                });
            }

            return result;

        }
    }
}
