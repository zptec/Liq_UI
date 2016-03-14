using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Analysis
{
    class AnalysisCondition
    {
        public string LFieldName { get; internal set; }
        public string LTableAs { get; internal set; }
        public string RFieldName { get; internal set; }
        public string RTableAs { get; internal set; }
    }
}
