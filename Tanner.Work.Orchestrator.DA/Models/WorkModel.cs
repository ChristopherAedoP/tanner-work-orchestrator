using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tanner.Work.Orchestrator.DA.Models
{
    [Table("T_TRABAJO")]
    public class WorkModel
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NOMBRE")]
        public int Name { get; set; }

        [Column("HORA_INICIO")]
        public DateTime StartTime { get; set; }

    }
}
