using System.Collections.Generic;
using System.Data;

namespace Liq_UI.Source
{
    public class SourceTable
    {
        /// <summary>
        /// Upper Object
        /// </summary>
        public SourceData Upper = new SourceData();

        /// <summary>
        /// Table Fields
        /// </summary>
        public List<string> TableFields = new List<string>();

        /// <summary>
        /// Table Contents 
        /// </summary>
        public List<SourceTableLine> TableContents = new List<SourceTableLine>();

        public string TableName { get; internal set; }
    }
}
