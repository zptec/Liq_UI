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
    class AnalysisFormImpl
    {
        /// <summary>
        /// Alv table name
        /// </summary>
        public AnalysisTable ALVTable { get; internal set; }
        
        /// <summary>
        /// Fix(Const) parameter Mappings
        /// </summary>
        public List<AnalysisFixMapping> FixMappings { get; internal set; }
        
        /// <summary>
        /// Form Description
        /// </summary>
        public string FormDesc { get; internal set; }
        
        /// <summary>
        /// Form Technical Name
        /// </summary>
        public string FormName { get; internal set; }
        
        /// <summary>
        /// Internal Tables of DB fetching
        /// </summary>
        public List<AnalysisTable> InTabes { get; internal set; }
        
        /// <summary>
        /// Internal table Name
        /// </summary>
        public AnalysisTable InTable { get; internal set; }
        
        /// <summary>
        /// Last internal WorkArea
        /// </summary>
        public AnalysisTable LastInWorkArea { get; internal set; }
        
        /// <summary>
        /// Mix relation List
        /// </summary>
        public List<AnalysisMix> Mixs { get; internal set; }
        
        /// <summary>
        /// Read Mapping List
        /// </summary>
        public List<AnalysisReadMapping> ReadMapping { get; internal set; }

        /// <summary>
        /// Split Fix Lines
        /// </summary>
        public IEnumerable<AnalysisField> SplitFixLines { get; internal set; }

        /// <summary>
        /// Splitter Clear Field List
        /// </summary>
        public List<AnalysisField> SplitterClears { get; internal set; }

        /// <summary>
        /// Splitter List
        /// </summary>
        public List<AnalysisField> Splitters { get; internal set; }

        /// <summary>
        /// SUM init flag field
        /// </summary>
        public AnalysisField SUM_INIT_FLAG { get; internal set; }
    }
}