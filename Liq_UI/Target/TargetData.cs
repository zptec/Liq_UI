using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Target
{
    public class TargetData
    {
        /// <summary>
        /// Target Status
        /// </summary>
        public TargetStatus Status = new TargetStatus();

        /// <summary>
        /// Target Table
        /// </summary>
        public TargetTable TargetTable = new TargetTable();

        /// <summary>
        /// Get Target Data
        /// </summary>
        /// <param name="inputData">Input Data Set</param>
        /// <returns>Target of Input Data</returns>
        public static TargetData GetTarget(DataSet inputData)
        {
            throw new NotImplementedException();
        }
    }
}
