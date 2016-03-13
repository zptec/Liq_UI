using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liq_UI.Translation;

namespace Liq_UI.Analysis
{
    class AnalysisBase
    {
        public List<AnalysisField> OutputFields { get; internal set; }
        public List<AnalysisTable> Tables { get; internal set; }
        public List<AnalysisTable> AuxiTables { get; internal set; }
        public IEnumerable<AnalysisWorkArea> WorkArea { get; internal set; }
        public IEnumerable<AnalysisVariable> Variable { get; internal set; }

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
