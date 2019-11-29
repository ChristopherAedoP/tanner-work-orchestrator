using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationInsights;
using Newtonsoft.Json;

namespace Tanner.Telemetry.AppInsights
{
    public class TraceHelper : ITraceHelper
    {
        private readonly TelemetryClient _telemetry;

        public TraceHelper(TelemetryClient telemetry)
        {
            _telemetry = telemetry;
        }
        /// <summary>
        /// 
        /// </summary>
        public void TraceInfo(string method, IDictionary<string, object> parameters)
        {
            TraceRegister(TraceInfoTypes.Information, method, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        public void TraceInfo(string mensaje)
        {
            TraceRegister(TraceInfoTypes.Information, mensaje, new Dictionary<string, object>());
        }

        /// <summary>
        /// 
        /// </summary>
        public void TraceInfo(TraceInfoTypes type, string mensaje, IDictionary<string, object> parameters)
        {
            TraceRegister(type, mensaje, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        private void TraceRegister(TraceInfoTypes type, string method, IDictionary<string, object> parameters)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                
                IDictionary<string, string> CustomParameters = new Dictionary<string, string>();

                var sb = new StringBuilder(method);
                
                foreach (var parameter in parameters)
                {
                    sb.Append(" ");

                    if (parameter.Value == null)
                    {
                        sb.AppendFormat("[{0}=]", parameter.Key);
                        
                    }
                    else if (parameter.Value is IEnumerable)
                    {
                        sb.AppendFormat("[{0}=", parameter.Key);

                        foreach (object v in parameter.Value as IEnumerable)
                            sb.Append(v);

                        sb.Append("]");
                    }
                    else
                    {
                        Exception ex = parameter.Value as Exception;

                        if (ex != null)
                        {
                            CustomParameters.Add(parameter.Key, JsonConvert.SerializeObject(ex));
                        }
                        else
                        {
                            CustomParameters.Add(parameter.Key, JsonConvert.SerializeObject(parameter.Value) );
                        }
                    }
                }

                switch (type)
                {
                    case TraceInfoTypes.Error:
                        _telemetry.TrackException(new Exception(sb.ToString()), CustomParameters);
                        break;

                    case TraceInfoTypes.Warning:
                        _telemetry.TrackTrace(sb.ToString(), CustomParameters);
                        break;

                    case TraceInfoTypes.Information:
                    default:
                        _telemetry.TrackEvent(sb.ToString(), CustomParameters);
                        break;
                }
            });
        }
    }
}
