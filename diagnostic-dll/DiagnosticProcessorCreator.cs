using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace diagnostic_dll
{
    public class DiagnosticProcessorCreator
    {
        public static DiagnosticProcessor Create(bool CPU, bool RAM)
        {
            //var thisProcessName = InfoProcess.GetProcessName(Process.GetCurrentProcess());
            var thisProcessName = Process.GetCurrentProcess().ProcessName;
            var output = new DiagnosticProcessor();

            if (CPU)
                output.AddCounter(new ProcessorUsage(new PerformanceCounter("Process", "% Processor Time", thisProcessName, true)));

            if (RAM)
                output.AddCounter(new RamUsage(new PerformanceCounter("Process", "Private Bytes", thisProcessName, true)));

            return output;
        }
    }
}
