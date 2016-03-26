using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Analysis
{
    class AnalysisReadMapping
    {
        public List<AnalysisFieldMapping> KeyList { get; public set; }

        public AnalysisTable SourceTable { get; public set; }

        public List<AnalysisFieldMapping> ValueList { get; public set; }
    }
}
