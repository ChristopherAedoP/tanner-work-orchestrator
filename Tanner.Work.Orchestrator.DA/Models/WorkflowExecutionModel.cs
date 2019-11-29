using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tanner.Work.Orchestrator.DA.Models
{
    [Table("T_TRABAJO_EJECUCION")]
    public class WorkflowExecutionModel
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ID_FLUJO")]
        public int IdWorkflow { get; set; }

        public WorkflowModel Workflow { get; set; }

        [Column("INICIO")]
        public DateTime Start { get; set; }

        [Column("FIN")]
        public DateTime End { get; set; }

        [Column("ESTADO")]
        public int State { get; set; }
               
    }
}
