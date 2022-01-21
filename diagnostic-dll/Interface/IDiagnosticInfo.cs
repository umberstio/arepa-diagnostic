using System;
using System.Collections.Generic;
using System.Text;

namespace diagnostic_dll
{
    public interface IDiagnosticInfo
    {
        string GetValue();
        string GetCounterName();
    }
}
