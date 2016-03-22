using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liq_UI.Filter;
using Liq_UI.Source;
using Liq_UI.Target;
using Liq_UI.Translation;

namespace Liq_UI.Analysis
{
    class AnalysisBase
    {
        /// <summary>
        /// ALV Output Fields
        /// </summary>
        public List<AnalysisField> OutputFields { get; internal set; }

        /// <summary>
        /// Tables
        /// </summary>
        public List<AnalysisTable> Tables { get; internal set; }

        /// <summary>
        /// Auxi Tables
        /// </summary>
        public List<AnalysisTable> AuxiTables { get; internal set; }

        /// <summary>
        /// Work areas
        /// </summary>
        public List<AnalysisWorkArea> WorkArea { get; internal set; }

        /// <summary>
        /// Variables
        /// </summary>
        public List<AnalysisVariable> Variable { get; internal set; }

        /// <summary>
        /// Form Call List
        /// </summary>
        public List<AnalysisFormCall> FormCalls { get; internal set; }

        /// <summary>
        /// Form Implementation List
        /// </summary>
        public List<AnalysisFormImpl> FormImpl { get; internal set; }

        /// <summary>
        /// Mapping Form Implementation
        /// </summary>
        public AnalysisFormImpl MappingFormImpl { get; internal set; }

        /// <summary>
        /// Mix Form Implementation
        /// </summary>
        public AnalysisFormImpl MixFormImpl { get; internal set; }

        /// <summary>
        /// Splitter Form Implementation
        /// </summary>
        public AnalysisFormImpl SplitterFormImpl { get; internal set; }

        /// <summary>
        /// Start Analysis
        /// </summary>
        /// <param name="sourceData">Source Data</param>
        /// <param name="targetData">Target Data</param>
        /// <param name="filterData">Filter Data</param>
        /// <returns>Analysis Result</returns>
        internal static AnalysisBase StartAnalysis(SourceData sourceData, TargetData targetData, FilterData filterData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ALV Field Catlog Form Implementation
        /// </summary>
        public AnalysisAppendFieldCatlogImpl AppendFieldCatlogImpl { get; internal set; }

        /// <summary>
        /// ALV Spec Form Implementation
        /// </summary>
        public AnalysisALVSpecImpl ALVSpecImpl { get; internal set; }

        /// <summary>
        /// ALV Call Form Implementation
        /// </summary>
        public AnalysisALVCallImpl ALVCallImpl { get; internal set; }

        //Five Directions:
        //Get North ( Prev Union )
        int GetNorth()
        {
            return 0;
        }

        //Get South ( Next Union )
        int GetSouth()
        {
            return 0;
        }

        //Get West ( Left Join )
        int GetWest()
        {
            return 0;
        }

        //Get East ( Right Join )
        int GetEast()
        {
            return 0;
        }

        //Get Center ( Inner Join )
        int GetCenter()
        {
            return 0;
        }
    }
}
