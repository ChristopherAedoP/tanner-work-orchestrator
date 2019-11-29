using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tanner.Work.Orchestrator.DA.Models
{
    public class DirectorioPersonaCab
    {
        [Key]
        public int IdDirectorioPersona { get; set; }

        public int IdInformeConsultado { get; set; }

        public int RutInformeConsultado { get; set; }

        public string TipoPersona { get; set; }

        public string ResultadoConsulta { get; set; }

        public DateTime FechaConsultaPersona { get; set; }

        //public InformeConsultado InformeConsultado { get; set; }

    }
}
