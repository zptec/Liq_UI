using System.Collections.Generic;

namespace Liq_UI.Analysis
{
    public class AnalysisAppendFieldCatlogImpl
    {
        /// <summary>
        /// Catlog Property List
        /// </summary>
        public List<AnalysisFieldCatlog> CatlogProperties { get; internal set; }

        /// <summary>
        /// Form Description
        /// </summary>
        public string FormDesc { get; internal set; }

        /// <summary>
        /// Form Name
        /// </summary>
        public string FormName { get; internal set; }
    }
}