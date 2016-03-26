using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Analysis
{
    /// <summary>
    /// Form Implementation Detail
    /// </summary>
    public class AnalysisFormImpl
    {
        /// <summary>
        /// Alv table name
        /// </summary>
        public AnalysisTable ALVTable { get; public set; }
        
        /// <summary>
        /// Fix(Const) parameter Mappings
        /// </summary>
        public List<AnalysisFixMapping> FixMappings { get; public set; }
        
        /// <summary>
        /// Form Description
        /// </summary>
        public string FormDesc { get; public set; }
        
        /// <summary>
        /// Form Technical Name
        /// </summary>
        public string FormName { get; public set; }
        
        /// <summary>
        /// public Tables of DB fetching
        /// </summary>
        public List<AnalysisTable> InTabes { get; public set; }
        
        /// <summary>
        /// public table Name
        /// </summary>
        public AnalysisTable InTable { get; public set; }
        
        /// <summary>
        /// Last public WorkArea
        /// </summary>
        public AnalysisTable LastInWorkArea { get; public set; }
        
        /// <summary>
        /// Mix relation List
        /// </summary>
        public List<AnalysisMix> Mixs { get; public set; }
        
        /// <summary>
        /// Read Mapping List
        /// </summary>
        public List<AnalysisReadMapping> ReadMapping { get; public set; }

        /// <summary>
        /// Split Fix Lines
        /// </summary>
        public IEnumerable<AnalysisField> SplitFixLines { get; public set; }

        /// <summary>
        /// Splitter Clear Field List
        /// </summary>
        public List<AnalysisField> SplitterClears { get; public set; }

        /// <summary>
        /// Splitter List
        /// </summary>
        public List<AnalysisField> Splitters { get; public set; }

        /// <summary>
        /// SUM init flag field
        /// </summary>
        public AnalysisField SUM_INIT_FLAG { get; public set; }
    }
}