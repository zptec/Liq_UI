using System;
using System.Collections.Generic;
using System.Data;
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

        /// <summary>
        /// Get Source Data
        /// </summary>
        /// <param name="inputData">Input Data Set</param>
        /// <returns>Source of Input Data</returns>
        internal static SourceData GetSource(DataSet inputData)
        {
            throw new NotImplementedException();
        }
    }
}
