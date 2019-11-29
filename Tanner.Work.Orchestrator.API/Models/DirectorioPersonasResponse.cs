using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tanner.Work.Orchestrator.API.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class DirectorioPersonasResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public string CodigoRetorno { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TipoPersona { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ResultadoConsulta { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        //public PersonaNatural PersonaNatural { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        //public PersonaJuridica PersonaJuridica { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Comuna { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Ciudad { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DetalleGiros { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DetalleProfesiones { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        //public List<Detalle> Detalles { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        //public List<DetallesGiros> DetallesGiros { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        //public static implicit operator DirectorioPersonasResponse(SNCR4401.RespuestaSNCR4401 data)
        //{
        //    var response = new DirectorioPersonasResponse()
        //    {
        //        CodigoRetorno = data?.CodigoRetorno?.TrimTab(),
        //        TipoPersona = data?.TipoPersona?.TrimTab(),
        //        ResultadoConsulta = data?.ResultadoConsulta?.TrimTab(),
        //        Direccion = data?.Direccion?.TrimTab(),
        //        Comuna = data?.Comuna?.TrimTab(),
        //        Ciudad = data?.Ciudad?.TrimTab(),
        //        DetalleGiros = data?.DetalleGiros?.TrimTab(),
        //        DetalleProfesiones = data?.DetalleProfesiones?.TrimTab()
        //    };
        //    return response;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        //public static implicit operator DirectorioPersonasResponse(DirectorioPersonaDet data)
        //{
        //    var response = new DirectorioPersonasResponse()
        //    {
        //        CodigoRetorno = data?.DirectorioPersonaCab?.InformeConsultado?.CodigoRetornoInforme?.TrimTab(),
        //        TipoPersona = data?.DirectorioPersonaCab?.TipoPersona?.TrimTab(),
        //        ResultadoConsulta = data?.DirectorioPersonaCab?.ResultadoConsulta?.TrimTab(),
        //        Direccion = data?.DireccionDirPersona?.TrimTab(),
        //        Comuna = data?.ComunaDirPersona?.TrimTab(),
        //        Ciudad = data?.CiudadDirPersona?.TrimTab(),
        //        DetalleGiros = data?.DetalleGiroDirPersona?.TrimTab(),
        //        DetalleProfesiones = data?.DetalleProfesionalesDirPersona?.TrimTab()
        //    };
        //    return response;
        //}
    }
}
