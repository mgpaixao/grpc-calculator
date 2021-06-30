using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Importar
using Calc;
using Grpc.Core;

namespace server
{
    public class CalculatorImpl : CalcService.CalcServiceBase
    {
        public override Task<CalcResponse> Calcservice(CalcRequest request, ServerCallContext context)
        {
            
            double sum = request.Value1 + request.Value2;//Soma dos 2 valores
            
            string result = String.Format("Result : {0}", sum); //Modelo de resposta pro sistema

            return Task.FromResult(new CalcResponse() { Result = result }); //Retorno do método Task que retornara a resposta para o client
            
        }
        public override Task<CreditCardResponse> CreditCardservice(CalcRequest request, ServerCallContext context)
        {
            string cc;
            Random rnd = new Random();
            int c1 = rnd.Next(1000, 9999);
            int c2 = rnd.Next(1000, 9999);
            int c3 = rnd.Next(1000, 9999);
            int c4 = rnd.Next(1000, 9999);
            cc = $"{c1} {c2} {c3} {c4}";

            return Task.FromResult(new CreditCardResponse() { Ccresult = cc });
        }

    }
}
