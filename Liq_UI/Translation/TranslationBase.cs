using Liq_UI.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Translation
{
    class TranslationBase
    {
        //Translate Status
        TranslationStatus Status = new TranslationStatus();

        //Final Code
        string FinalCode = "";

        //Translate to final code
        int Translate2Code(ref AnalysisBase analysisResult)
        {
            //Translator for ABAP data definition
            TranslationDefinition TransDef = new TranslationDefinition(this);

            return 0;
        }
    }
}
