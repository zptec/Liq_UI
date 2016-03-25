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
        /// <summary>
        /// Source Status
        /// </summary>
        public SourceStatus Status = new SourceStatus();

        /// <summary>
        /// Source Tables List
        /// </summary>
        public List<SourceTable> TableList = new List<SourceTable>();

        /// <summary>
        /// Set table relations
        /// </summary>
        /// <returns></returns>
        public int SetTableRelations()
        {
            return 0;
        }

        /// <summary>
        /// Get Source
        /// </summary>
        /// <returns></returns>
        public SourceData GetSource()
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
