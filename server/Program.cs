using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calc;
using Grpc.Core;

namespace server
{
    class Program
    {
        const int Port = 50051;
        static void Main(string[] args)
        {
            Server server = null;

            try//Tentativa de conexão com servidor
            {
                server = new Server()
                {
                    Services = { CalcService.BindService(new CalculatorImpl())},
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure)}//Definição da porta do servidor
                };

                server.Start(); //Inicializando o servidor
                Console.WriteLine("The server is online on port: " + Port);
                Console.ReadKey();
            }
            catch (InvalidOperationException e) //Criando excessão para quando a conexão client-server apresentar erros
            {
                Console.WriteLine("The server failed to connect : " + e.Message);
                throw;
            }
            finally//Fechar servidor
            {
                if (server != null)
                    server.ShutdownAsync().Wait();
            }
        }
    }
}
