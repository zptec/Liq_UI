using Liq_UI.Searching;
using System.Collections.Generic;

namespace Liq_UI.Target
{
    public class TargetField
    {
        /// <summary>
        /// Field Value
        /// </summary>
        public string FieldValue = "";

        /// <summary>
        /// Relate Cells
        /// </summary>
        public List<TargetRelateCell> RelateCells = new List<TargetRelateCell>();

        /// <summary>
        /// Relate Filters
        /// </summary>
        public List<TargetRelateFilter> RelateFilter = new List<TargetRelateFilter>();

        /// <summary>
        /// Table Field Mapping
        /// </summary>
        public SearchingTableFieldMapping RefTableField { get; internal set; }
    }
}