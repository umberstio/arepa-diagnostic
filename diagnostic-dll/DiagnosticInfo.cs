
using System.Diagnostics;

namespace diagnostic_dll
{
    internal abstract class DiagnosticInfo : IDiagnosticInfo
    {
        protected readonly PerformanceCounter _diagnosticElement;
        protected readonly string _name;
        protected readonly string _symbol;
        public DiagnosticInfo(PerformanceCounter Counter, string NameCounter, string symbol)
        {
            _symbol = symbol;
            _name = NameCounter;
            _diagnosticElement = Counter;
        }

        public string GetCounterName() => _name;
        public string GetSymbol() => _symbol;
        public abstract double GetValue();
    }
}