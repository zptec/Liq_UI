using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Analysis
{
    public class AnalysisField
    {
        /// <summary>
        /// Catlog Property List
        /// </summary>
        public List<AnalysisFieldCatlog> CatlogProperties { get; public set; }

        //Field Description
        public string FieldDesc { get; public set; }
        
        //Field Name
        public string FieldName { get; public set; }

        //Ref Field Name 
        public string RefField { get; public set; }

        //Ref Table Name
        public string RefTable { get; public set; }
        public string TableAs { get; public set; }
    }
}
