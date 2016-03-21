﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Analysis
{
    class AnalysisField
    {
        public List<AnalysisFieldCatlog> CatlogPropertys { get; internal set; }

        //Field Description
        public string FieldDesc { get; internal set; }
        
        //Field Name
        public string FieldName { get; internal set; }

        //Ref Field Name 
        public string RefField { get; internal set; }

        //Ref Table Name
        public string RefTable { get; internal set; }
        public string TableAs { get; internal set; }
    }
}
