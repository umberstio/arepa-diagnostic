using System;
using System.Collections.Generic;
using System.Text;

namespace diagnostic_dll
{
    internal interface IDiagnosticInfo
    {
        double GetValue();
        string GetCounterName();
        string GetSymbol();
    }
}
