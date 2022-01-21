using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace diagnostic_dll
{
    public class ProcessorUsage : DiagnosticInfo
    {
        public ProcessorUsage(PerformanceCounter PCounter) : base(PCounter, "CPU") { }

        public override string GetValue()
        {
            return String.Concat(Math.Round(DiagnosticElement.NextValue() / Environment.ProcessorCount, 2), " %");
        }
    }
}
