using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Analysis
{
    class AnalysisFormImpl
    {
        public AnalysisTable ALVTable { get; internal set; }

        public List<AnalysisFixMapping> FixMappings { get; internal set; }

        public string FormDesc { get; internal set; }

        public string FormName { get; internal set; }

        public List<AnalysisTable> InTabes { get; internal set; }

        public AnalysisTable InTable { get; internal set; }

        public List<AnalysisMix> Mixs { get; internal set; }

        public List<AnalysisReadMapping> ReadMapping { get; internal set; }

        public List<AnalysisField> Splitters { get; internal set; }
    }
}