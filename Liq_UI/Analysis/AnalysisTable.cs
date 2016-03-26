using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Analysis
{
    public class AnalysisTable
    {
        public List<AnalysisField> fields;

        public IEnumerable<AnalysisCondition> JoinCondition { get; public set; }
        public AnalysisTable Entries { get; public set; }
        public AnalysisJoinType JoinType { get; public set; }
        public IEnumerable<AnalysisCondition> SelectionConditions { get; public set; }
        public IEnumerable<AnalysisField> SelectionFields { get; public set; }
        public IEnumerable<AnalysisTable> SelectionFrom { get; public set; }
        public object TableAs { get; public set; }
        public string TableDesc { get; public set; }
        public string TableName { get; public set; }
        public IEnumerable<AnalysisField> TableKeys { get; public set; }
    }
}
