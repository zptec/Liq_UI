﻿using Liq_UI.Analysis;
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
            TranslationDefinition DefTranslator = new TranslationDefinition(this);
            //Translator for ABAP selection screen
            TranslationSelection SelectionTranslator = new TranslationSelection(this);
            //Translator for ABAP DB fetching
            TranslationDBFetching DBFetchingTranslator = new TranslationDBFetching(this);
            //Translator for ABAP table reading
            TranslationTableReading ReadingTranslator = new TranslationTableReading(this);
            return 0;
        }
    }
}
