using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace diagnostic_dll
{
    internal class RamUsage : DiagnosticInfo
    {
        public RamUsage(PerformanceCounter PCounter) : base(PCounter, "RAM", "MB") { }

        public override double GetValue() => Math.Round(_diagnosticElement.NextValue() / 1024 / 1024, 2);      
    }
}
