﻿using System;
using System.Collections.Generic;
using Liq_UI.Analysis;

namespace Liq_UI.Translation
{
    public class TranslationTableReading
    {
        //Analysis Result
        private AnalysisBase analysisResult;

        //Translation Base Info
        private TranslationBase translationBase;

        public TranslationTableReading(AnalysisBase analysisResult)
        {
            this.analysisResult = analysisResult;
        }

        public TranslationTableReading(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        public List<TranslationSegment> GenerateCode()
        {
            List<TranslationSegment> segments = new List<TranslationSegment>();

            //Add Mapping Form
            TranslationSegment segmentMapping = new TranslationSegment("Processing_Mapping", TranslationSegmentType.DBFetching);

            //Add Form Header
            segmentMapping.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentMapping.CodeLines.Add("*&      Form  " + analysisResult.MappingFormImpl.FormName);
            segmentMapping.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentMapping.CodeLines.Add("*       " + analysisResult.MappingFormImpl.FormDesc);
            segmentMapping.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentMapping.CodeLines.Add("*  -->  p1        text");
            segmentMapping.CodeLines.Add("*  <--  p2        text");
            segmentMapping.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentMapping.CodeLines.Add("FORM " + analysisResult.MappingFormImpl.FormName + " .");
            segmentMapping.CodeLines.Add("");

            //LOOP AT T_TAB.
            segmentMapping.CodeLines.Add("LOOP AT " + analysisResult.MappingFormImpl.InTable.TableName + ".");

            //Add fix mapping lines
            foreach (AnalysisFixMapping fixMapping in analysisResult.MappingFormImpl.FixMappings)
            {
                //SET FIX VALUE
                segmentMapping.CodeLines.Add("\tMOVE " + fixMapping.FixValue + " TO "
                    + analysisResult.MappingFormImpl.InTable.TableName + "-"
                    + fixMapping.TargetField.FieldName);
            }

            //Add Read table Mapping
            foreach (AnalysisReadMapping readMapping in analysisResult.MappingFormImpl.ReadMapping)
            {
                //Read table binary search
                string strReadTable = "";
                strReadTable = "\tREAD TABLE " + readMapping.SourceTable.TableName + " WITH KEY ";
                segmentMapping.CodeLines.Add(strReadTable);
                //Add each read key conditions
                foreach (AnalysisFieldMapping keyFieldMapping in readMapping.KeyList)
                {
                    //Add read table keys
                    segmentMapping.CodeLines.Add(keyFieldMapping.TargetField.FieldName + " = " + keyFieldMapping.SourceField.FieldName + " \"" + keyFieldMapping.SourceField.FieldDesc);
                }
                segmentMapping.CodeLines.Add("BINARY SEARCH.");
                segmentMapping.CodeLines.Add("\tIF SY-SUBRC EQ 0.");
                //Move each field of table into target workarea
                foreach (AnalysisFieldMapping valueFieldMapping in readMapping.ValueList)
                {
                    segmentMapping.CodeLines.Add("\t\tMOVE " + readMapping.SourceTable.TableName + "-" + valueFieldMapping.SourceField.FieldName + " TO "
                        + analysisResult.MappingFormImpl.InTable.TableName + "-"
                        + valueFieldMapping.TargetField.FieldName + ".");
                }
                //End of Read table
                segmentMapping.CodeLines.Add("\tENDIF.");
            }

            //MODIFY T_TAB.
            segmentMapping.CodeLines.Add("\tMODIFY " + analysisResult.MappingFormImpl.InTable.TableName + ".");

            //ENDLOOP.
            segmentMapping.CodeLines.Add("ENDLOOP.");

            segmentMapping.CodeLines.Add("ENDFORM                    \" " + analysisResult.MappingFormImpl.FormName);

            segments.Add(segmentMapping);

            return segments;
        }
    }
}