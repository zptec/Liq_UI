using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.IO
{
    class IOInputFile
    {
        /// <summary>
        /// Input Data Set
        /// </summary>
        public DataSet InputData { get; internal set; }

        /// <summary>
        /// Init File Processer
        /// </summary>
        internal void Init()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Read each File
        /// </summary>
        /// <returns></returns>
        internal bool ReadNextFile()
        {
            throw new NotImplementedException();
        }
    }
}
