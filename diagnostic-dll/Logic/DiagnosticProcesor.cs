using System;
using System.Collections.Generic;
using System.Threading;

namespace diagnostic_dll
{
    public class DiagnosticProcessor
    {
        private readonly List<IDiagnosticInfo> Counters;
        public DiagnosticProcessor()
        {
            Counters = new List<IDiagnosticInfo>();
        }

        public void AddCounter(IDiagnosticInfo Counter)
        {
            Counters.Add(Counter);
        }

        public Thread GetDiagnosticThread(Action<IEnumerable<DiagnosticResult>> callBack, Action<string> callBackError = null)
        {
            return new Thread(() =>
            {
                try
                {
                    callBack(GetValues());

                }
                catch (Exception e)
                {
                    callBackError?.Invoke(e.Message);
                }

                
            });
        }

        private IEnumerable<DiagnosticResult> GetValues()
        {
            // desechamos las primeras lecturas
            foreach (var counter in Counters)
                counter.GetValue();

            // Esperamos para tener lecturas precisas
            Thread.Sleep(500);

            // Retornamos las lecturas posta
            foreach (var counter in Counters)
                yield return new DiagnosticResult() { Name = counter.GetCounterName(), Value = counter.GetValue() };
        }
    }
}