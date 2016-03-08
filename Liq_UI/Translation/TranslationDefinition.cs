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

            //Add Definition of ALV information
            TranslationSegment segmentALVDef = new TranslationSegment("Definition_ALV_Info", TranslationSegmentType.Heading);
            segmentALVDef.CodeLines.Add("TYPE-POOLS: SLIS.");
            segmentALVDef.CodeLines.Add("************************************************************************");
            segmentALVDef.CodeLines.Add("\"DATA DEFINITION");
            segmentALVDef.CodeLines.Add("************************************************************************");
            segmentALVDef.CodeLines.Add("*---------------------------------------------------------------------*");
            segmentALVDef.CodeLines.Add("\"Begin of ALV definition");
            segmentALVDef.CodeLines.Add("*---------------------------------------------------------------------*");
            segmentALVDef.CodeLines.Add("\"Layout");
            segmentALVDef.CodeLines.Add("DATA IS_LAYOUT TYPE SLIS_LAYOUT_ALV.");
            segmentALVDef.CodeLines.Add("");
            segmentALVDef.CodeLines.Add("\"Fielcatlog");
            segmentALVDef.CodeLines.Add("DATA IT_FIELDCAT TYPE  SLIS_T_FIELDCAT_ALV.");
            segmentALVDef.CodeLines.Add("");
            segmentALVDef.CodeLines.Add("\"Fielcatlog work area");
            segmentALVDef.CodeLines.Add("DATA WA_FIELDCAT TYPE LINE OF SLIS_T_FIELDCAT_ALV.");
            segmentALVDef.CodeLines.Add("*---------------------------------------------------------------------*");
            segmentALVDef.CodeLines.Add("\"End of ALV definition");
            segmentALVDef.CodeLines.Add("*---------------------------------------------------------------------*");
            segmentALVDef.CodeLines.Add("DATA: BEGIN OF T_ALV OCCURS 1,");
            segmentALVDef.CodeLines.Add("\tCHECK TYPE C, \"CHECK BOX");
            segments.Add(segmentALVDef);

            //Add ALV fields
            TranslationSegment segmentALVfields = new TranslationSegment("Definition_ALV_Fields", TranslationSegmentType.Heading);
            foreach (AnalysisField field in analysisResult.OutputFields)
                segmentALVfields.CodeLines.Add("\t\t" + field.FieldName + " TYPE " + field.RefTable + "-" + field.RefField + ",\t\"" + field.FieldDesc);
            segmentALVfields.CodeLines.Add("\tEND OF T_ALV,");
            segments.Add(segmentALVfields);

            //
            return segments;
        }
    }
}