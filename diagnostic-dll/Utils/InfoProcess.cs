using System.Diagnostics;

namespace diagnostic_dll
{
    internal class InfoProcess
    {
        internal static string GetProcessName(Process process)
        {
            var name = string.Empty;
            var performanceCategory = new PerformanceCounterCategory("Process").GetInstanceNames();

            foreach (var instance in performanceCategory)
            {
                if (instance.StartsWith(process.ProcessName))
                {
                    using (var processId = new PerformanceCounter("Process", "ID Process", instance, true))
                    {
                        if (process.Id == (int)processId.RawValue)
                        {
                            name = instance;
                            break;
                        }
                    }
                }
            }
            performanceCategory = null;
            return name;
        }
    }
}
