using System.Collections.Generic;

namespace Liq_UI.Source
{
    internal class SourceTableField
    {
        //Upper Object
        SourceTableLine UpperObject = new SourceTableLine();
        //Field Value
        string FieldValue = "";
        //Relate Cells
        List<SourceRelateCell> RelateCells = new List<SourceRelateCell>();
        //Relate Filters
        List<SourceRelateFilter> RelateFilter = new List<SourceRelateFilter>();
    }
}