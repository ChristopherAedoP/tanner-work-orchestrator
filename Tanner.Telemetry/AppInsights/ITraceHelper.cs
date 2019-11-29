using System.Collections.Generic;

namespace Tanner.Telemetry.AppInsights
{
    public interface ITraceHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mensaje"></param>
        /// <param name="parameters"></param>
        void TraceInfo(TraceInfoTypes type, string mensaje, IDictionary<string, object> parameters);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        void TraceInfo(string method, IDictionary<string, object> parameters);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        void TraceInfo(string mensaje);

    }
}
