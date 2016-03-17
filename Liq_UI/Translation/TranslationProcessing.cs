﻿using System;
using System.Collections.Generic;
using Liq_UI.Analysis;

namespace Liq_UI.Translation
{
    internal class TranslationProcessing
    {
        //Analysis Result
        private AnalysisBase analysisResult;

        //Translation Base Info
        private TranslationBase translationBase;

        public TranslationProcessing(AnalysisBase analysisResult)
        {
            this.analysisResult = analysisResult;
        }

        public TranslationProcessing(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        internal List<TranslationSegment> GenerateCode()
        {
            List<TranslationSegment> segments = new List<TranslationSegment>();

            //Add each form processing implementation

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
                    segmentMapping.CodeLines.Add("\t\tMOVE " + readMapping.SourceTable.TableName + "-" + valueFieldMapping.SourceField.FieldName  + " TO "
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


            //Add Mix Form
            TranslationSegment segmentMix = new TranslationSegment("Processing_Mix", TranslationSegmentType.DBFetching);

            //Add Form Header
            segmentMix.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentMix.CodeLines.Add("*&      Form  " + analysisResult.MixFormImpl.FormName);
            segmentMix.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentMix.CodeLines.Add("*       " + analysisResult.MixFormImpl.FormDesc);
            segmentMix.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentMix.CodeLines.Add("*  -->  p1        text");
            segmentMix.CodeLines.Add("*  <--  p2        text");
            segmentMix.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentMix.CodeLines.Add("FORM " + analysisResult.MixFormImpl.FormName + " .");
            segmentMix.CodeLines.Add("");

            //LOOP AT T_TAB.
            segmentMapping.CodeLines.Add("LOOP AT " + analysisResult.MixFormImpl.InTable.TableName + ".");

            //Mix string
            string strMix = "";

            //Add Mixs
            foreach (AnalysisMix mix in analysisResult.MixFormImpl.Mixs)
            {
                strMix = analysisResult.MixFormImpl.InTable.TableName + "-"
                        + mix.TargetField.FieldName + " = ";
                //First item indicator
                bool firstItem;
                firstItem = true;
                //Add items
                foreach (AnalysisItem item in mix.Items)
                {
                    // "+/-" between items
                    if (!firstItem)
                    {
                        if(item.Cons >= 0)
                            strMix += " + ";
                        else
                            strMix += " - ";
                    }
                    //First element indicator
                    bool firstElement;
                    firstElement = true;
                    if (item.Cons != 1)
                    {
                        //Constanse Parameter
                        strMix += "\"" + item.Cons + "\"";
                        firstElement = false;
                    }
                    //Add elements
                    foreach (AnalysisElement element in item.Elements)
                    {
                        if (firstElement)
                        {
                            //Multiple Operator
                            if (element.Operator == AnalysisOperator.Multiple)
                                strMix += analysisResult.MixFormImpl.InTable.TableName + "-" + element.Field.FieldName;
                            //Divide Operator
                            else if(element.Operator == AnalysisOperator.Divide)
                                strMix += "1 / " + analysisResult.MixFormImpl.InTable.TableName + "-" + element.Field.FieldName;
                        }
                        else
                        {
                            //Multiple Operator
                            if (element.Operator == AnalysisOperator.Multiple)
                                strMix += " * " + analysisResult.MixFormImpl.InTable.TableName + "-" + element.Field.FieldName;
                            //Divide Operator
                            else if (element.Operator == AnalysisOperator.Divide)
                                strMix += " / " + analysisResult.MixFormImpl.InTable.TableName + "-" + element.Field.FieldName;
                        }
                        firstElement = false;
                    }
                    firstItem = false;
                }

                strMix += ".";

                segmentMapping.CodeLines.Add(strMix);
            }

            //MODIFY T_TAB.
            segmentMapping.CodeLines.Add("\tMODIFY " + analysisResult.MixFormImpl.InTable.TableName + ".");


            //ENDLOOP.
            segmentMapping.CodeLines.Add("ENDLOOP.");

            segmentMix.CodeLines.Add("ENDFORM                    \" " + analysisResult.MixFormImpl.FormName);

            segments.Add(segmentMix);

            //Add Splitter Form
            TranslationSegment segmentSplitter = new TranslationSegment("Processing_Splitter", TranslationSegmentType.DBFetching);

            //Add Form Header
            segmentSplitter.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentSplitter.CodeLines.Add("*&      Form  " + analysisResult.SplitterFormImpl.FormName);
            segmentSplitter.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentSplitter.CodeLines.Add("*       " + analysisResult.SplitterFormImpl.FormDesc);
            segmentSplitter.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentSplitter.CodeLines.Add("*  -->  p1        text");
            segmentSplitter.CodeLines.Add("*  <--  p2        text");
            segmentSplitter.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentSplitter.CodeLines.Add("FORM " + analysisResult.SplitterFormImpl.FormName + " .");
            segmentSplitter.CodeLines.Add("");

            //LOOP AT T_TAB.
            segmentMapping.CodeLines.Add("LOOP AT " + analysisResult.SplitterFormImpl.InTable.TableName + ".");

            //Mix string
            string strSplitter = "";

            //MODIFY T_TAB.
            segmentMapping.CodeLines.Add("\tMODIFY " + analysisResult.SplitterFormImpl.InTable.TableName + ".");
            
            //ENDLOOP.
            segmentMapping.CodeLines.Add("ENDLOOP.");

            segmentSplitter.CodeLines.Add("ENDFORM                    \" " + analysisResult.SplitterFormImpl.FormName);

            segments.Add(segmentSplitter);


            return segments;
        }
    }
}