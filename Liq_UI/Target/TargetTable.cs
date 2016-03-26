using System.Collections.Generic;

namespace Liq_UI.Target
{
    public class TargetTable
    {
        /// <summary>
        /// Upper Object
        /// </summary>
        TargetData UpperObject = new TargetData();

        /// <summary>
        /// Table Content
        /// </summary>
        public List<TargetTableLine> TableContent { get; internal set; }

        /// <summary>
        /// Table Fields
        /// </summary>
        public List<string> TableFields { get; internal set; }

        /// <summary>
        /// Set table cell relations
        /// </summary>
        /// <returns></returns>
        int SetCellRelations()
        {
            return 0;
        }
    }
}