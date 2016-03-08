using System;
using System.Collections.Generic;
using Liq_UI.Analysis;

namespace Liq_UI.Translation
{
    internal class TranslationDefinition
    {
        //Analysis Result
        private AnalysisBase analysisResult;

        //Translation Base Info
        private TranslationBase translationBase;

        public TranslationDefinition(AnalysisBase analysisResult)
        {
            this.analysisResult = analysisResult;
        }

        public TranslationDefinition(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        //Generate ABAP definition code
        internal List<TranslationSegment> GenerateCode()
        {
            List<TranslationSegment> segments = new List<TranslationSegment>();

            //Heading Top
            TranslationSegment segment = new TranslationSegment("Definition_ALV", TranslationSegmentType.Heading);
            segment.CodeLines.Add("TYPE-POOLS: SLIS.");
            segment.CodeLines.Add("************************************************************************");
            segment.CodeLines.Add("\"DATA DEFINITION");
            segment.CodeLines.Add("************************************************************************");
            segment.CodeLines.Add("*---------------------------------------------------------------------*");
            segment.CodeLines.Add("\"Begin of ALV definition");
            segment.CodeLines.Add("*---------------------------------------------------------------------*");
            segment.CodeLines.Add("\"Layout");
            segment.CodeLines.Add("DATA IS_LAYOUT TYPE SLIS_LAYOUT_ALV.");
            segment.CodeLines.Add("");
            segment.CodeLines.Add("\"Fielcatlog");
            segment.CodeLines.Add("DATA IT_FIELDCAT TYPE  SLIS_T_FIELDCAT_ALV.");
            segment.CodeLines.Add("");
            segment.CodeLines.Add("\"Fielcatlog work area");
            segment.CodeLines.Add("DATA WA_FIELDCAT TYPE LINE OF SLIS_T_FIELDCAT_ALV.");
            segment.CodeLines.Add("*---------------------------------------------------------------------*");
            segment.CodeLines.Add("\"End of ALV definition");
            segment.CodeLines.Add("*---------------------------------------------------------------------*");
            segments.Add(segment);

            return segments;
        }
    }
}