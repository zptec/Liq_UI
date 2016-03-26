using Liq_UI.Filter;
using Liq_UI.Target;
using System.Collections.Generic;

namespace Liq_UI.Source
{
    public class SourceTableField
    {
        //Upper Object
        public SourceTableLine UpperObject = new SourceTableLine();

        //Field Value
        public string FieldValue = "";

        //Relate Cells
        public List<SourceRelateCell> RelateCells = new List<SourceRelateCell>();

        //Relate Filters
        public List<SourceRelateFilter> RelateFilter = new List<SourceRelateFilter>();

        /// <summary>
        /// Set relation to Filter
        /// </summary>
        /// <param name="FilterData">Filter Data</param>
        /// <returns>Filter Relation</returns>
        public int SetFilterRelation(ref FilterData FilterData)
        {
            return 0;
        }

        //Set relation to Target Cell
        public int SetTargetRelation(ref TargetData TargetData)
        {
            return 0;
        }
    }
}