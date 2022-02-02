using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace diagnostic_dll
{
    internal class ProcessorUsage : DiagnosticInfo
    {
        public ProcessorUsage(PerformanceCounter PCounter) : base(PCounter, "CPU", "%") { }

        public override double GetValue() => Math.Round(_diagnosticElement.NextValue() / Environment.ProcessorCount, 2);      
    }
}
