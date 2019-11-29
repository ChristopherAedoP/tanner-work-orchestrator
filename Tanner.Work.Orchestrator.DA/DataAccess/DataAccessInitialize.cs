using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tanner.Work.Orchestrator.DA.Contracts;
using Tanner.Work.Orchestrator.DA.Models;

namespace Tanner.Work.Orchestrator.DA.DataAccess
{
    public static class DataAccessInitialize
    {
        public static void AddDataAccess(this IServiceCollection serviceCollection,
           IConfiguration configuration)
        {
            DataAccessSetting option = configuration.GetSection(DataAccessSetting.SettingName).Get<DataAccessSetting>();
            serviceCollection.AddSingleton(option);
            serviceCollection.AddSingleton<IDataAccessHelper, DataAccessHelper>();
            //serviceCollection.AddSingleton<IDataAccess<InformeConsultado>, InformeConsultadoService>();
            //serviceCollection.AddSingleton<IDataAccess<AvaluoClienteCab>, AvaluoClienteCabService>();
            //serviceCollection.AddSingleton<IDataAccess<AvaluoClienteDet>, AvaluoClienteDetService>();
            //serviceCollection.AddSingleton<IDataAccess<InformeCliente>, InformeClienteService>();
        }
    }
}
