using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Analysis
{
    class AnalysisReadMapping
    {
        public List<AnalysisFieldMapping> KeyList { get; internal set; }

        public AnalysisTable SourceTable { get; internal set; }

        public List<AnalysisFieldMapping> ValueList { get; internal set; }
    }
}
