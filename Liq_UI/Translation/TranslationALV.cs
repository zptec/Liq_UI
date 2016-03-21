using Liq_UI.Analysis;
using System.Collections.Generic;

namespace Liq_UI.Translation
{
    internal class TranslationALV
    {
        //Analysis Result
        private AnalysisBase analysisResult;

        private TranslationBase translationBase;
        
        public TranslationALV(AnalysisBase analysisResult)
        {
            this.analysisResult = analysisResult;
        }

        public TranslationALV(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        internal List<TranslationSegment> GenerateCode()
        {
            List<TranslationSegment> segments = new List<TranslationSegment>();

            //Add Mapping Form
            TranslationSegment segmentALVCALL = new TranslationSegment("ALV_CALL", TranslationSegmentType.DBFetching);

            //Add Form Header
            segmentALVCALL.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentALVCALL.CodeLines.Add("*&      Form  " + analysisResult.ALVFormImpl.FormName);
            segmentALVCALL.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentALVCALL.CodeLines.Add("*       " + analysisResult.ALVFormImpl.FormDesc);
            segmentALVCALL.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentALVCALL.CodeLines.Add("*  -->  p1        text");
            segmentALVCALL.CodeLines.Add("*  <--  p2        text");
            segmentALVCALL.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentALVCALL.CodeLines.Add("FORM " + analysisResult.ALVFormImpl.FormName + " .");
            segmentALVCALL.CodeLines.Add("");

            segmentALVCALL.CodeLines.Add("\tIS_LAYOUT-COLWIDTH_OPTIMIZE = 'X'.");
            segmentALVCALL.CodeLines.Add("\tPERFORM APPEND_FIELDCAT USING:");
            //Add \t\t
            string strCatlog = "\t\t";
            //Add Fieldcatlogs
            for (int i = 0; i < analysisResult.OutputFields.Count; i++)
            {
                //Add catlog items
                for(int j = 0; j < analysisResult.OutputFields[i].CatlogPropertys.Count; j++)
                {
                    strCatlog += "'" + analysisResult.OutputFields[i].CatlogPropertys[j].CatlogValue + "' ";
                }
                if(i == analysisResult.OutputFields.Count - 1)
                    strCatlog += ".";
                else
                    strCatlog += ",";
            }
            segments.Add(segmentALVCALL);

            return segments;
        }
    }
}