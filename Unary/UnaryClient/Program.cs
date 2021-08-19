using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace UnaryClient
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var grpcChannel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Calculator.CalculatorClient(grpcChannel);

            var sumResult = await client.SumValueAsync(new Values() { A = 10, B = 20 });
            Console.WriteLine($"10 + 20 = {sumResult.Result}");

            var substractionResult = await client.SubtractValueAsync(new Values() { A = 10, B = 5 });
            Console.WriteLine($"10 - 5 = {substractionResult.Result}");

            Console.ReadLine();
        }
    }
}
