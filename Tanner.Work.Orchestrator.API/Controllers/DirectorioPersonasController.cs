using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tanner.Utils.Extensions;
using Tanner.Work.Orchestrator.API.Contracts;
using Tanner.Work.Orchestrator.API.Models;

namespace Tanner.Work.Orchestrator.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorioPersonasController : ControllerBase
    {
        private readonly IDirectorioPersonasBusiness _directorioPersonasBusiness;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="directorioPersonasBusiness"></param>
        public DirectorioPersonasController(IDirectorioPersonasBusiness directorioPersonasBusiness)
        {
            _directorioPersonasBusiness = directorioPersonasBusiness;
        }

        /// <summary>
        /// Retorna los datos asociados al Rut de consulta. 
        /// </summary>
        /// <param name="sysinfo"></param>
        /// <param name="info"></param>
        /// <param name="rut"></param>
        /// <param name="dv"></param>
        /// <response code="200">Respuesta exitosa de directorio de personas.</response>
        /// <response code="400">No se puede acceder a la información solicitada.</response>
        /// <response code="404">No se encuentra la información de la persona solicitada.</response>
        /// <response code="500">Error interno.</response>
        /// GET api/DirectorioPersonas/1000/1003/1/9
        [HttpGet("{sysinfo}/{info}/{rut}/{dv}")]
        [ProducesResponseType(typeof(DirectorioPersonasResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAsync(int sysinfo, int info, int rut, char dv)
        {
            bool enableService = await _directorioPersonasBusiness.ServiceVerifyAsync(sysinfo, info);
            if (!enableService)
            {
                return BadRequest();
            }
            else
            {
                if (string.IsNullOrEmpty($"{rut}-{dv}"))
                {
                    return BadRequest();
                }
                if (dv.ToString() != RUTExtensions.VerifierDigitRUT(rut))
                {
                    return BadRequest();
                }
                DirectorioPersonasResponse directorioPersonasResponse = await _directorioPersonasBusiness.ConsultaAsync(info, rut, dv);
                OkObjectResult result = Ok(directorioPersonasResponse);
                return result;
            }
        }
    }
}
