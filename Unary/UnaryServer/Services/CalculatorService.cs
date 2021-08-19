using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace UnaryServer.Services
{
    public class CalculatorService : Calculator.CalculatorBase
    {
        private readonly ILogger<CalculatorService> _logs;
        public CalculatorService(ILogger<CalculatorService> logs)
        {
            _logs = logs;
        }

        public override Task<OperationResult> SumValue(Values request, ServerCallContext context)
        {
            _logs.LogDebug($"Adding values {request.A} + {request.B}");
            
            return Task.FromResult(new OperationResult()
            {
                Result = request.A + request.B
            });
        }

        public override Task<OperationResult> SubtractValue(Values request, ServerCallContext context)
        {
            _logs.LogDebug($"Subtracting values {request.A} + {request.B}");

            return Task.FromResult(new OperationResult()
            {
                Result = request.A - request.B
            });
        }
    }
}
