using System.Collections.Generic;

namespace Liq_UI
{
    internal class SourceTableField
    {
        //Field Value
        string FieldValue = "";
        //Relate Cells
        List<SourceRelateCell> RelateCells = new List<SourceRelateCell>();
        //Relate Filters
        List<SourceRelateFilter> RelateFilter = new List<SourceRelateFilter>();
    }
}