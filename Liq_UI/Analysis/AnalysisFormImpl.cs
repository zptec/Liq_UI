using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Analysis
{
    class AnalysisFormImpl
    {
        public string FormDesc { get; internal set; }
        public string FormName { get; internal set; }
        public IEnumerable<AnalysisTable> InTabes { get; internal set; }
    }
}