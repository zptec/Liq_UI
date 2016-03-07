using System.Collections.Generic;
using Liq_UI.Target;

namespace Liq_UI.Source
{
    internal class SourceRelateCell
    {
        //Upper Object
        SourceTableField UpperObject = new SourceTableField();
        //Relate reference
        TargetField RelateReference = new TargetField();
        //Relate Mode
        SourceRelateMode Mode = new SourceRelateMode();
        //Relate Parameters
        List<SourceRelateParameter> RelateParameters = new List<SourceRelateParameter>();
    }
}