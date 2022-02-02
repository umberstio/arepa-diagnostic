using System;
using Xunit;
using diagnostic_dll;
using System.Linq;
using System.Threading;

namespace arepa_diagnostic_test
{
    public class Testing
    {
        private static DiagnosticProcessor GetDiagnosticProcessor(string measurable) => measurable.ToLower() switch
        {
            "cpu" => DiagnosticProcessorCreator.Create(true, false),
            "ram" => DiagnosticProcessorCreator.Create(false, true),
            _ => throw new NotImplementedException()
        };


        [Theory]
        [InlineData("cpu")]
        [InlineData("ram")]
        public void Names(string measurable)
        {
            var diagnosticProcessor = GetDiagnosticProcessor(measurable);

            DiagnosticResult result = null;
            var thread = diagnosticProcessor.GetDiagnosticThread((resultList) =>
            {
                result = resultList.First();
            });

            thread.Start();
            thread.Join();

            Assert.Equal(measurable.ToUpper(), result.Name);
        }

        [Theory]
        [InlineData("cpu")]
        [InlineData("ram")]
        public void Results(string measurable)
        {
            var diagnosticProcessor = GetDiagnosticProcessor(measurable);

            DiagnosticResult result = null;
            var thread = diagnosticProcessor.GetDiagnosticThread((resultList) =>
            {
                result = resultList.First();
            });

            thread.Start();
            thread.Join();

            Assert.True(result.Value > 0);
        }

        [Theory]
        [InlineData("cpu", "%")]
        [InlineData("ram", "MB")]
        public void Symbols(string measurable, string expected)
        {
            var diagnosticProcessor = GetDiagnosticProcessor(measurable);

            DiagnosticResult result = null;
            var thread = diagnosticProcessor.GetDiagnosticThread((resultList) =>
            {
                result = resultList.First();
            });

            thread.Start();
            thread.Join();

            Assert.True(result.Symbol == expected);
        }


    }
}
