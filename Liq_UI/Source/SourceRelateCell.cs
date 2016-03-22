using System.Collections.Generic;
using Liq_UI.Target;

namespace Liq_UI.Source
{
    internal class SourceRelateCell
    {
        /// <summary>
        /// Upper Object
        /// </summary>
        SourceTableField UpperObject = new SourceTableField();

        /// <summary>
        /// Relate reference
        /// </summary>
        TargetField RelateReference = new TargetField();

        /// <summary>
        /// Relate Mode
        /// </summary>
        SourceRelateMode Mode = new SourceRelateMode();

        /// <summary>
        /// Relate Parameters
        /// </summary>
        List<SourceRelateParameter> RelateParameters = new List<SourceRelateParameter>();
    }
}