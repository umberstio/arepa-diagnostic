using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace diagnostic_dll
{
    public class RamUsage : DiagnosticInfo
    {
        public RamUsage(PerformanceCounter PCounter) : base(PCounter, "RAM") { }

        public override string GetValue()
        {
            return String.Concat(Math.Round(DiagnosticElement.NextValue() / 1024 / 1024, 2), " MB");
        }
    }
}
