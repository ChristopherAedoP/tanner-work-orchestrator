using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tanner.Work.Orchestrator.DA.Models
{
    [Table("T_TAREA")]
    public class TaskModel
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NOMBRE")]
        public string Name { get; set; }

        [Column("URL_REQUEST")]
        public string UrlRequest { get; set; }

        [Column("URL_RESPONSE")]
        public string UrlResponse { get; set; }

    }
}
