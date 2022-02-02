using System;
using System.Collections.Generic;
using System.Threading;

namespace diagnostic_dll
{
    public class DiagnosticProcessor
    {
        private readonly List<IDiagnosticInfo> _counters;
        public DiagnosticProcessor()
        {
            _counters = new List<IDiagnosticInfo>();
        }

        internal void AddCounter(IDiagnosticInfo Counter)
        {
            _counters.Add(Counter);
        }

        public Thread GetDiagnosticThread(Action<IEnumerable<DiagnosticResult>> callBack, Action<string> callBackError = null)
        {
            if (_counters.Count == 0)
                throw new Exception("Empty counters");

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
            foreach (var counter in _counters)
                counter.GetValue();

            // Esperamos para tener lecturas precisas
            Thread.Sleep(500);

            // Retornamos las lecturas posta
            foreach (var counter in _counters)
                yield return new DiagnosticResult() { Name = counter.GetCounterName(), Value = counter.GetValue(), Symbol=counter.GetSymbol() };
        }
    }
}