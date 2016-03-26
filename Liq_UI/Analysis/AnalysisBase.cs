using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liq_UI.Filter;
using Liq_UI.Source;
using Liq_UI.Target;
using Liq_UI.Translation;
using Liq_UI.Searching;

namespace Liq_UI.Analysis
{
    public class AnalysisBase
    {
        /// <summary>
        /// ALV Output Fields
        /// </summary>
        public List<AnalysisField> OutputFields { get; public set; }

        /// <summary>
        /// Tables
        /// </summary>
        public List<AnalysisTable> Tables { get; public set; }

        /// <summary>
        /// Auxi Tables
        /// </summary>
        public List<AnalysisTable> AuxiTables { get; public set; }

        /// <summary>
        /// Work areas
        /// </summary>
        public List<AnalysisWorkArea> WorkArea { get; public set; }

        /// <summary>
        /// Variables
        /// </summary>
        public List<AnalysisVariable> Variable { get; public set; }

        /// <summary>
        /// Form Call List
        /// </summary>
        public List<AnalysisFormCall> FormCalls { get; public set; }

        /// <summary>
        /// Form Implementation List
        /// </summary>
        public List<AnalysisFormImpl> FormImpl { get; public set; }

        /// <summary>
        /// Mapping Form Implementation
        /// </summary>
        public AnalysisFormImpl MappingFormImpl { get; public set; }

        /// <summary>
        /// Mix Form Implementation
        /// </summary>
        public AnalysisFormImpl MixFormImpl { get; public set; }

        /// <summary>
        /// Splitter Form Implementation
        /// </summary>
        public AnalysisFormImpl SplitterFormImpl { get; public set; }

        /// <summary>
        /// Start Analysis
        /// </summary>
        /// <param name="sourceData">Source Data</param>
        /// <param name="targetData">Target Data</param>
        /// <param name="filterData">Filter Data</param>
        /// <returns>Analysis Result</returns>
        public static AnalysisBase StartAnalysis(SourceData sourceData, TargetData targetData, FilterData filterData)
        {
            //Search the match fields between filter and source data
            SearchingBase.Filter2Source(filterData, sourceData);
        }

        /// <summary>
        /// ALV Field Catlog Form Implementation
        /// </summary>
        public AnalysisAppendFieldCatlogImpl AppendFieldCatlogImpl { get; public set; }

        /// <summary>
        /// ALV Spec Form Implementation
        /// </summary>
        public AnalysisALVSpecImpl ALVSpecImpl { get; public set; }

        /// <summary>
        /// ALV Call Form Implementation
        /// </summary>
        public AnalysisALVCallImpl ALVCallImpl { get; public set; }

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
