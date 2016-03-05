using System.Collections.Generic;

namespace Liq_UI
{
    internal class SourceRelateCell
    {
        //Relate reference
        TargetField RelateReference = new TargetField();
        //Relate Mode
        SourceRelateMode Mode = new SourceRelateMode();
        //Relate Parameters
        List<SourceRelateParameter> RelateParameters = new List<SourceRelateParameter>();
    }
}