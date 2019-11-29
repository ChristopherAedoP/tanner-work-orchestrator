using System;
using System.ComponentModel.DataAnnotations;


namespace Tanner.Work.Orchestrator.DA.Models
{
    public class AvaluoClienteCab
    {
        [Key]
        public int IdAvaluoBien { get; set; }

        public int IdInformeConsultado { get; set; }

        public int RutInformeConsultado { get; set; }

        public string ExisteDetalleAvaluo { get; set; }

        public int NumeroPropiedades { get; set; }

        public DateTime FechaConsultaAvaluo { get; set; }

      //  public InformeConsultado InformeConsultado { get; set; }
    }
}
