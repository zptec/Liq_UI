using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Analysis
{
    class AnalysisItem
    {
        //Constans parameter
        public double Cons { get; internal set; }
        
        //Elements
        public List<AnalysisElement> Elements { get; internal set; }
    }
}
