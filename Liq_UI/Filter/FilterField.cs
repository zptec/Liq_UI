using Liq_UI.Analysis;
using Liq_UI.Searching;
using System.Collections.Generic;

namespace Liq_UI.Filter
{
    public class FilterField
    {
        /// <summary>
        /// Filter Field Text
        /// </summary>
        public string FilterFieldText = "";

        /// <summary>
        /// Filter Field Value
        /// </summary>
        public string FilterFieldValue = "";

        /// <summary>
        /// AnalisisField
        /// </summary>
        public SearchingTableFieldMapping RefTableField { get; internal set; }
    }
}