using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tanner.Work.Orchestrator.DA.Models
{
    [Table("T_TRABAJO_FLUJO")]
    public class WorkflowModel
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ID_TRABAJO")]
        public int IdWork { get; set; }

        public WorkModel Work { get; set; }

        [Column("ID_TAREA")]
        public int IdTask { get; set; }

        public TaskModel Task { get; set; }

        [Column("ID_TAREA_DEPENDENCIA")]
        public int IdDependentTask { get; set; }

        [Column("ORDEN")]
        public int Order { get; set; }

        [Column("HORA")]
        public DateTime Time { get; set; }
    }
}
