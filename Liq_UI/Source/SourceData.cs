using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Source
{
    class SourceData
    {
        //Source Status
        SourceStatus Status = new SourceStatus();

        //Source Tables List
        List<SourceTable> TableList = new List<SourceTable>();

        //Set table relations
        int SetTableRelations()
        {
            return 0;
        }

        internal SourceData GetSource()
        {
            throw new NotImplementedException();
        }
    }
}
