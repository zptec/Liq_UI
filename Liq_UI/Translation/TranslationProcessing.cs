using System;
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
            segmentMix.CodeLines.Add("LOOP AT " + analysisResult.MixFormImpl.InTable.TableName + ".");

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

                segmentMix.CodeLines.Add(strMix);
            }

            //MODIFY T_TAB.
            segmentMix.CodeLines.Add("\tMODIFY " + analysisResult.MixFormImpl.InTable.TableName + ".");

            //ENDLOOP.
            segmentMix.CodeLines.Add("ENDLOOP.");

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

            //==================================================
            //  ABAP BELOW
            //==================================================
            //DATA LW_LAST_TAB LIKE I_TAB.
            //Data L_FIELD1_SUM LIKE I_TAB-FIELD1.
            //Data L_FIELD2_SUM LIKE I_TAB-FIELD2.
            //Data L_FIELD3_SUM LIKE I_TAB-FIELD3.
            //DATA L_SUM_INIT TYPE C.
            //CLEAR: LW_LAST_TAB,
            //       L_FIELD1_SUM,
            //       L_FIELD2_SUM,
            //       L_FIELD3_SUM.
            //  L_SUM_INIT = 'X'.
            //LOOP AT I_TAB.
            //  "At New Field
            //  IF L_FIELD1_SUM NE I_TAB-FIELD1
            //      OR L_FIELD2_SUM NE I_TAB-FIELD2
            //      OR L_FIELD3_SUM NE I_TAB-FIELD3 .
            //      MOVE I_TAB-FIELD1 TO L_FIELD1_SUM .
            //      MOVE I_TAB-FIELD2 TO L_FIELD2_SUM .
            //      MOVE I_TAB-FIELD3 TO L_FIELD3_SUM .
            //          IF L_SUM_INIT NE 'X'.
            //              MOVE L_FIELD1_SUM TO LW_LAST_TAB-FIELD1.
            //              MOVE L_FIELD2_SUM TO LW_LAST_TAB-FIELD2.
            //              MOVE L_FIELD3_SUM TO LW_LAST_TAB-FIELD3.
            //              CLEAR: LW_LAST_TAB-FIELD4,
            //                     LW_LAST_TAB-FIELD5,
            //                     LW_LAST_TAB-FIELD6.
            //              MOVE 'TOTAL:' TO LW_LAST_TAB-FIELD7.
            //              LW_LAST_TAB-FIELD8 = LW_LAST_TAB-FIELD9 * LW_LAST_TAB-FIELD10.
            //              APPEND LW_LAST_TAB TO T_ALV.
            //              CLEAR: L_FIELD1_SUM,
            //              CLEAR: L_FIELD2_SUM,
            //              CLEAR: L_FIELD3_SUM.
            //          ENDIF.
            //  ENDIF.
            //  APPEND I_TAB TO T_ALV.
            //  CLEAR L_SUM_INIT.
            //  CLEAR LW_LAST_TAB.
            //  MOVE CORRESPONDING I_TAB TO LW_LAST_TAB .
            //  ADD LW_LAST_TAB-FIELD1 TO L_FIELD1_SUM.
            //  ADD LW_LAST_TAB-FIELD2 TO L_FIELD2_SUM.
            //  ADD LW_LAST_TAB-FIELD3 TO L_FIELD3_SUM.
            //ENDLOOP.
            //
            //APPEND LW_LAST_TAB TO T_ALV.
            //
            //===================================================
            //  ABAP ABOVE
            //===================================================

            //Define DATA LW_LAST_TAB LIKE I_TAB.
            segmentSplitter.CodeLines.Add("\tDATA " + analysisResult.SplitterFormImpl.LastInWorkArea.TableName 
                + " LIKE " + analysisResult.SplitterFormImpl.InTable.TableName + ".");

            //Define splitter Fields
            foreach (AnalysisField splitterField in analysisResult.SplitterFormImpl.Splitters)
            {
                //Data L_FIELD1_SUM LIKE I_TAB-FIELD1.
                segmentSplitter.CodeLines.Add("\tDATA " + splitterField.FieldName + " LIKE "
                    + analysisResult.SplitterFormImpl.InTable.TableName + "-"
                    + splitterField.RefField + ".");
            }

            //Define L_SUM_INIT TYPE C.
            segmentSplitter.CodeLines.Add("\tDATA " + analysisResult.SplitterFormImpl.SUM_INIT_FLAG.FieldName 
                + " TYPE C.");


            //CLEAR LW_LAST_TAB LIKE I_TAB.
            segmentSplitter.CodeLines.Add("\tDATA " + analysisResult.SplitterFormImpl.LastInWorkArea.TableName
                + " LIKE " + analysisResult.SplitterFormImpl.InTable.TableName + ".");

            //CLEAR splitter Fields
            bool firstSplitterClear;
            firstSplitterClear = true;
            for (int i = 0; i < analysisResult.SplitterFormImpl.Splitters.Count; i++)
            {
                //Data L_FIELD1_SUM LIKE I_TAB-FIELD1.
                //First Line
                if (i == 0)
                    segmentSplitter.CodeLines.Add("\tCLEAR:\t" + analysisResult.SplitterFormImpl.Splitters[i].FieldName + " LIKE "
                        + analysisResult.SplitterFormImpl.InTable.TableName + "-"
                        + analysisResult.SplitterFormImpl.Splitters[i].RefField + ",");
                //Last Line
                else if (i == analysisResult.SplitterFormImpl.Splitters.Count - 1)
                    segmentSplitter.CodeLines.Add("\t\t" + analysisResult.SplitterFormImpl.Splitters[i].FieldName + " LIKE "
                        + analysisResult.SplitterFormImpl.InTable.TableName + "-"
                        + analysisResult.SplitterFormImpl.Splitters[i].RefField + ".");
                //Other Lines
                else
                    segmentSplitter.CodeLines.Add("\t\t" + analysisResult.SplitterFormImpl.Splitters[i].FieldName + " LIKE "
                        + analysisResult.SplitterFormImpl.InTable.TableName + "-"
                        + analysisResult.SplitterFormImpl.Splitters[i].RefField + ",");
                firstSplitterClear = false;
            }

            //MOVE 'X' TO L_SUM_INIT.
            segmentSplitter.CodeLines.Add("\tMOVE 'X' TO " + analysisResult.SplitterFormImpl.SUM_INIT_FLAG.FieldName + ".");

            //LOOP AT T_TAB.
            segmentSplitter.CodeLines.Add("LOOP AT " + analysisResult.SplitterFormImpl.InTable.TableName + ".");

            //Mix string
            string strSplitter = "";

            //"At New Field
            segmentSplitter.CodeLines.Add("\t\"At New Field");

            //IF L_FIELD1_SUM NE I_TAB-FIELD1
            //  OR L_FIELD2_SUM NE I_TAB-FIELD2
            //  OR L_FIELD3_SUM NE I_TAB-FIELD3 .
            for (int i = 0; i < analysisResult.SplitterFormImpl.Splitters.Count; i++)
            {
                //First Line
                if (i == 0)
                    segmentSplitter.CodeLines.Add("\tIF " + analysisResult.SplitterFormImpl.Splitters[i].FieldName + " NE "
                        + analysisResult.SplitterFormImpl.InTable.TableName + "-"
                        + analysisResult.SplitterFormImpl.Splitters[i].RefField);
                //Last Line
                else if (i == analysisResult.SplitterFormImpl.Splitters.Count - 1)
                    segmentSplitter.CodeLines.Add("\t\tOR " + analysisResult.SplitterFormImpl.Splitters[i].FieldName + " NE "
                        + analysisResult.SplitterFormImpl.InTable.TableName + "-"
                        + analysisResult.SplitterFormImpl.Splitters[i].RefField);
                //Other Lines
                else
                    segmentSplitter.CodeLines.Add("\t\tOR " + analysisResult.SplitterFormImpl.Splitters[i].FieldName + " NE "
                        + analysisResult.SplitterFormImpl.InTable.TableName + "-"
                        + analysisResult.SplitterFormImpl.Splitters[i].RefField + ".");
            }

            //      MOVE I_TAB-FIELD1 TO L_FIELD1_SUM .
            //      MOVE I_TAB-FIELD2 TO L_FIELD2_SUM .
            //      MOVE I_TAB-FIELD3 TO L_FIELD3_SUM .
            foreach (AnalysisField FilterAccumulate in analysisResult.SplitterFormImpl.Splitters)
            {
                segmentSplitter.CodeLines.Add("\t\tMOVE " + analysisResult.SplitterFormImpl.InTable.TableName + "-"
                    + FilterAccumulate.RefField + " TO " +
                    FilterAccumulate.FieldName + ".");
            }
            //          IF L_SUM_INIT NE 'X'.

            //MODIFY T_TAB.
            segmentSplitter.CodeLines.Add("\tAPPEND " + analysisResult.SplitterFormImpl.InTable.TableName +
                " TO " + analysisResult.SplitterFormImpl.ALVTable.TableName + ".");
            
            //ENDLOOP.
            segmentSplitter.CodeLines.Add("ENDLOOP.");

            segmentSplitter.CodeLines.Add("ENDFORM                    \" " + analysisResult.SplitterFormImpl.FormName);

            segments.Add(segmentSplitter);

            return segments;
        }
    }
}