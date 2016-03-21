using System.Collections.Generic;

namespace Liq_UI.Analysis
{
    public class AnalysisFieldCatlog
    {
        /// <summary>
        /// Field catlog property name
        /// </summary>
        public string CatlogName { get; internal set; }

        /// <summary>
        /// Field catlog property value
        /// </summary>
        public string CatlogValue { get; internal set; }
        internal IEnumerable<AnalysisField> Targets { get; set; }
    }
}