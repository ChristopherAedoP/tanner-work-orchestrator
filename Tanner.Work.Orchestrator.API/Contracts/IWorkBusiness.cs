using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tanner.Work.Orchestrator.API.Models;
using Tanner.Work.Orchestrator.DA.Models;

namespace Tanner.Work.Orchestrator.API.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWorkBusiness
    {
        /// <summary>
        /// 
        /// </summary>

        /// <returns></returns>
        Task<IEnumerable<WorkModel>> ListAsync();


    }
}
