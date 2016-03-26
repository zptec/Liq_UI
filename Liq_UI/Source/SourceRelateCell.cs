using System.Collections.Generic;
using Liq_UI.Target;

namespace Liq_UI.Source
{
    public class SourceRelateCell
    {
        /// <summary>
        /// Upper Object
        /// </summary>
        public SourceTableField UpperObject = new SourceTableField();

        /// <summary>
        /// Relate reference
        /// </summary>
        public TargetField RelateReference = new TargetField();

        /// <summary>
        /// Relate Mode
        /// </summary>
        public SourceRelateMode Mode = new SourceRelateMode();

        /// <summary>
        /// Relate Parameters
        /// </summary>
        public List<SourceRelateParameter> RelateParameters = new List<SourceRelateParameter>();
    }
}