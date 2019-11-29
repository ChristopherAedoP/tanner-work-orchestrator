using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tanner.Work.Orchestrator.API.Models;

namespace Tanner.Work.Orchestrator.API.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDirectorioPersonasBusiness
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="rut"></param>
        /// <param name="dv"></param>
        /// <returns></returns>
        Task<DirectorioPersonasResponse> ConsultaAsync(int info, int rut, char dv);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sysinfo"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        Task<bool> ServiceVerifyAsync(int sysinfo, int info);
    }
}
