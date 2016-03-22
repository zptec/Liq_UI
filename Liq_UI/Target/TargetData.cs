using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Target
{
    class TargetData
    {
        //Target Status
        TargetStatus Status = new TargetStatus();

        //Target Table
        TargetTable TargetTable = new TargetTable();

        internal TargetData GetTarget()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Target Data
        /// </summary>
        /// <param name="inputData">Input Data Set</param>
        /// <returns>Target of Input Data</returns>
        internal static TargetData GetTarget(DataSet inputData)
        {
            throw new NotImplementedException();
        }
    }
}
