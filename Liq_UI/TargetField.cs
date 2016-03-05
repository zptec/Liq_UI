using System.Collections.Generic;

namespace Liq_UI
{
    internal class TargetField
    {
        //Field Value
        string FieldValue = "";
        //Relate Cells
        List<TargetRelateCell> RelateCells = new List<TargetRelateCell>();
        //Relate Filters
        List<TargetRelateFilter> RelateFilter = new List<TargetRelateFilter>();
    }
}