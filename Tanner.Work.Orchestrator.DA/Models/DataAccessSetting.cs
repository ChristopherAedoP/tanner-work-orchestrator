using System;
using System.Collections.Generic;
using System.Text;

namespace Tanner.Work.Orchestrator.DA.Models
{
    public class DataAccessSetting
    {
        public static string SettingName = "ConnectionStrings";

        public string InformesClientes { get; set; }

        public string Retry { get; set; }

        public string RetryMiliseconds { get; set; }

        public string InfoSource { get; set; }
    }
}
