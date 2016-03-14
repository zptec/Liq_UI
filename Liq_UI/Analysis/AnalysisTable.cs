using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Analysis
{
    class AnalysisTable
    {
        internal List<AnalysisField> fields;

        public IEnumerable<AnalysisCondition> JoinCondition { get; internal set; }
        public AnalysisTable Entries { get; internal set; }
        public AnalysisJoinType JoinType { get; internal set; }
        public IEnumerable<AnalysisCondition> SelectionConditions { get; internal set; }
        public IEnumerable<AnalysisField> SelectionFields { get; internal set; }
        public IEnumerable<AnalysisTable> SelectionFrom { get; internal set; }
        public object TableAs { get; internal set; }
        public string TableDesc { get; internal set; }
        public string TableName { get; internal set; }
    }
}
