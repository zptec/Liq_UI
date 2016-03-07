﻿using Liq_UI.Filter;
using Liq_UI.Target;
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

        //Set relation to Filter
        int SetFilterRelation(ref FilterData FilterData)
        {
            return 0;
        }

        //Set relation to Target Cell
        int SetTargetRelation(ref TargetData TargetData)
        {
            return 0;
        }
    }
}