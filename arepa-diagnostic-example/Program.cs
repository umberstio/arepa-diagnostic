using diagnostic_dll;
using System;
using System.Collections.Generic;
using System.Threading;

namespace arepa_diagnostic_example
{
    class Program
    {
        static void Main(string[] args)
        {
            var diagProcesor = DiagnosticProcessorCreator.Create(true, true);
            static void print(IEnumerable<DiagnosticResult> resultList)
            {
                foreach (var result in resultList)
                {
                    Console.WriteLine($"{result.Name} : {result.Value} {result.Symbol}");
                }
            }

            while (true)
            {
                diagProcesor.GetDiagnosticThread(print).Start();
                Thread.Sleep(1000);
            }

            

        }
    }
}
