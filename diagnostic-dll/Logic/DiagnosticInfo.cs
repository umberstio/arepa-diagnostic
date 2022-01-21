
using System.Diagnostics;

namespace diagnostic_dll
{
    public abstract class DiagnosticInfo : IDiagnosticInfo
    {
        protected PerformanceCounter DiagnosticElement;
        protected string Name;
        public DiagnosticInfo(PerformanceCounter Counter, string NameCounter)
        {
            DiagnosticElement = Counter;
            Name = NameCounter;
        }

        public string GetCounterName() => Name;
        

        public abstract string GetValue();
    }
}