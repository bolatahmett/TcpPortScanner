using Jaeger;
using OpenTracing;

namespace PortScanTool.Model.Log
{
    public static class LogHelper
    {
        public static void Log(ITracer tracer,string message)
        {
            var operationName = "Log";
            var builder = tracer.BuildSpan(operationName);

            using (var scope = builder.StartActive(true))
            {
                var span = scope.Span;
                span.Log(message);
            }
        }
    }
}
