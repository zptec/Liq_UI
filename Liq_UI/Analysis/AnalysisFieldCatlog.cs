using System.Collections.Generic;

namespace Liq_UI.Analysis
{
    public class AnalysisFieldCatlog
    {
        /// <summary>
        /// Field catlog property name
        /// </summary>
        public string CatlogName { get; public set; }

        /// <summary>
        /// Field catlog property value
        /// </summary>
        public string CatlogValue { get; public set; }
        public IEnumerable<AnalysisField> Targets { get; set; }
    }
}