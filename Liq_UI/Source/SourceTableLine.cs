using System.Collections.Generic;

namespace Liq_UI.Source
{
    public class SourceTableLine
    {
        /// <summary>
        /// Upper Object
        /// </summary>
        public SourceTable UpperObject = new SourceTable();

        /// <summary>
        /// Field Data List
        /// </summary>
        public List<SourceTableField> FieldDataList = new List<SourceTableField>();
    }
}