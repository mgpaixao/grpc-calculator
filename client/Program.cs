using Calc;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        const string address = "127.0.0.1:50051"; //Endereço do servidor
        static void Main(string[] args)
        {
            Channel channel = new Channel(address, ChannelCredentials.Insecure); //Indicando endereço para o Canal do servidor.

            channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("Welcome to Calculator");
            });

            var client = new CalcService.CalcServiceClient(channel);

            var calc = new CalcRequest();
    
            Console.WriteLine("Write the first number of the sum: ");
            calc.Value1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Write the Second number of the sum: ");
            calc.Value2 = Convert.ToDouble(Console.ReadLine());
            var response = client.Calcservice(calc);

            Console.WriteLine(response.Result);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("What is you email address?");
            calc.Email = Console.ReadLine();
            var resp = client.CreditCardservice(calc);
            Console.WriteLine(resp.Ccresult);

            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }
    }
}
