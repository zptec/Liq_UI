using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Analysis
{
    class AnalysisElement
    {
        //Element Field
        public AnalysisField Field { get; internal set; }

        //Element Operator
        public AnalysisOperator Operator { get; internal set; }
    }
}
