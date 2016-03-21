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

            //Add Fieldcatlog Form
            TranslationSegment segmentFieldcatlog = new TranslationSegment("ALV_FIELDCATLOG", TranslationSegmentType.ALV);

            //Add Form Header
            segmentFieldcatlog.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentFieldcatlog.CodeLines.Add("*&      Form  " + analysisResult.ALVSpecImpl.FormName);
            segmentFieldcatlog.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentFieldcatlog.CodeLines.Add("*       " + analysisResult.ALVSpecImpl.FormDesc);
            segmentFieldcatlog.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentFieldcatlog.CodeLines.Add("*  -->  p1        text");
            segmentFieldcatlog.CodeLines.Add("*  <--  p2        text");
            segmentFieldcatlog.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentFieldcatlog.CodeLines.Add("FORM " + analysisResult.ALVSpecImpl.FormName + " .");
            segmentFieldcatlog.CodeLines.Add("");

            segmentFieldcatlog.CodeLines.Add("\tIS_LAYOUT-COLWIDTH_OPTIMIZE = 'X'.");
            segmentFieldcatlog.CodeLines.Add("\tPERFORM APPEND_FIELDCAT USING:");

            //Add Fieldcatlogs
            for (int i = 0; i < analysisResult.OutputFields.Count; i++)
            {
                //Add \t\t
                string strCatlog = "\t\t";

                //Add catlog items
                for (int j = 0; j < analysisResult.OutputFields[i].CatlogProperties.Count; j++)
                {
                    strCatlog += "'" + analysisResult.OutputFields[i].CatlogProperties[j].CatlogValue + "' ";
                }
                if (i == analysisResult.OutputFields.Count - 1)
                    strCatlog += ".\t\"[" + i.ToString() + "]" + analysisResult.OutputFields[i].FieldDesc;
                else
                    strCatlog += ",\t\"[" + i.ToString() + "]" + analysisResult.OutputFields[i].FieldDesc;

                segmentFieldcatlog.CodeLines.Add(strCatlog);
            }
            segmentFieldcatlog.CodeLines.Add("ENDFORM                    \" " + analysisResult.ALVSpecImpl.FormName);
            
            segments.Add(segmentFieldcatlog);

            //Add Fieldcatlog Comments
            TranslationSegment segmentALVFieldComments = new TranslationSegment("ALV_Field_Comments", TranslationSegmentType.ALV);

            segmentFieldcatlog.CodeLines.Add("************************************************************************");
            segmentFieldcatlog.CodeLines.Add("*OUTPUT FIELDS");
            segmentFieldcatlog.CodeLines.Add("************************************************************************");
            
            //Add Fieldcatlog comments
            for (int i = 0; i < analysisResult.OutputFields.Count; i++)
                segmentFieldcatlog.CodeLines.Add("\"[" + i.ToString() + "]" + analysisResult.OutputFields[i].FieldDesc);
            
            segments.Add(segmentALVFieldComments);

            //Add Fieldcatlog APPEND_FIELDCAT Form
            TranslationSegment segmentALVCALL = new TranslationSegment("ALV_CALL", TranslationSegmentType.ALV);

            //Add Form Header
            segmentALVCALL.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentALVCALL.CodeLines.Add("*&      Form  " + analysisResult.AppendFieldCatlogImpl.FormName);
            segmentALVCALL.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentALVCALL.CodeLines.Add("*       " + analysisResult.AppendFieldCatlogImpl.FormDesc);
            segmentALVCALL.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentALVCALL.CodeLines.Add("*  -->  p1        text");
            segmentALVCALL.CodeLines.Add("*  <--  p2        text");
            segmentALVCALL.CodeLines.Add("*&---------------------------------------------------------------------*");
            
            //Add Form USING Parameters
            for (int i = 0; i < analysisResult.AppendFieldCatlogImpl.CatlogProperties.Count; i++)
            {
                //First Line
                if(i == 0)
                    segmentALVCALL.CodeLines.Add("FORM " 
                        + analysisResult.AppendFieldCatlogImpl.FormName 
                        + " USING VALUE(" + analysisResult.AppendFieldCatlogImpl.CatlogProperties[i].CatlogName
                        + ")");
                //Last Line
                else if (i == analysisResult.AppendFieldCatlogImpl.CatlogProperties.Count - 1)
                    segmentALVCALL.CodeLines.Add("\t\t\t"
                        + analysisResult.AppendFieldCatlogImpl.FormName
                        + " USING VALUE(" + analysisResult.AppendFieldCatlogImpl.CatlogProperties[i].CatlogName
                        + ").");
                //Center Line
                else
                    segmentALVCALL.CodeLines.Add("\t\t\t"
                        + analysisResult.AppendFieldCatlogImpl.FormName
                        + " USING VALUE(" + analysisResult.AppendFieldCatlogImpl.CatlogProperties[i].CatlogName
                        + ")");
            }

            //Add Field catlog assign statement
            foreach (AnalysisFieldCatlog FieldcatProp in analysisResult.AppendFieldCatlogImpl.CatlogProperties)
            {
                string strCatlogPropAssign = "\t";
                foreach (AnalysisField PropTargetField in FieldcatProp.Targets)
                {
                    strCatlogPropAssign += "IT_FIELDCAT-" + PropTargetField.FieldName + " = "; 
                }
                strCatlogPropAssign += FieldcatProp.CatlogName;
            }

            //  APPEND IT_FIELDCAT.
            segmentALVCALL.CodeLines.Add("\tAPPEND IT_FIELDCAT.");

            //  CLEAR IT_FIELDCAT.
            segmentALVCALL.CodeLines.Add("\tCLEAR IT_FIELDCAT.");

            //ENDFORM
            segmentALVCALL.CodeLines.Add("ENDFORM                    \" " + analysisResult.AppendFieldCatlogImpl.FormName);

            return segments;
        }
    }
}