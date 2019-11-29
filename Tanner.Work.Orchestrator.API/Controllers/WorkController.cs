using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tanner.Utils.Extensions;
using Tanner.Work.Orchestrator.API.Contracts;
using Tanner.Work.Orchestrator.API.Models;
using Tanner.Work.Orchestrator.DA.Models;

namespace Tanner.Work.Orchestrator.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkBusiness _workBusiness;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="workBusiness"></param>
        public WorkController(IWorkBusiness workBusiness)
        {
            _workBusiness = workBusiness;
        }

        /// <summary>
        /// Retorna los datos asociados al Rut de consulta. 
        /// </summary>
        /// <response code="200">Respuesta exitosa de directorio de personas.</response>
        /// <response code="400">No se puede acceder a la información solicitada.</response>
        /// <response code="404">No se encuentra la información de la persona solicitada.</response>
        /// <response code="500">Error interno.</response>
        /// GET api/DirectorioPersonas/1000/1003/1/9
        [HttpGet]
        [ProducesResponseType(typeof(WorkModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAsync()
        {
                var tasks = await _workBusiness.ListAsync();
                OkObjectResult result = Ok(tasks);
                return result;
         }
    }
}
