using System;
using System.Collections.Generic;
using Liq_UI.Analysis;

namespace Liq_UI.Translation
{
    internal class TranslationDBFetching
    {
        private object abapTable;

        //Analysis Result
        private AnalysisBase analysisResult;

        //Translation Base Info
        private TranslationBase translationBase;

        public TranslationDBFetching(AnalysisBase analysisResult)
        {
            this.analysisResult = analysisResult;
        }

        public TranslationDBFetching(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        internal List<TranslationSegment> GenerateCode()
        {
            List<TranslationSegment> segments = new List<TranslationSegment>();

            //Add START-OF-SELECTION
            TranslationSegment segmentStartOfSelection = new TranslationSegment("DBFetching_STARTOFSELECTION", TranslationSegmentType.DBFetching);
            segmentStartOfSelection.CodeLines.Add("*---------------------------------------------------------------------*");
            segmentStartOfSelection.CodeLines.Add("\" START OF SELECTION");
            segmentStartOfSelection.CodeLines.Add("*---------------------------------------------------------------------*");
            segmentStartOfSelection.CodeLines.Add("START OF SELECTION");
            segmentStartOfSelection.CodeLines.Add("");
            //Add each form call
            foreach (AnalysisFormCall abapFormCall in analysisResult.FormCalls)
            {
                segmentStartOfSelection.CodeLines.Add("\"" + abapFormCall.Index + " " + abapFormCall.FormDesc);
                segmentStartOfSelection.CodeLines.Add("PERFORM " + abapFormCall.FormName + ".");
            }
            segments.Add(segmentStartOfSelection);

            //Add each of Form implementation
            TranslationSegment segmentFormImpl = new TranslationSegment("DBFetching_FormImpl", TranslationSegmentType.DBFetching);
            foreach (AnalysisFormImpl abapFormImpl in analysisResult.FormImpl)
            {
                //Add Form Header
                segmentFormImpl.CodeLines.Add("*&---------------------------------------------------------------------*");
                segmentFormImpl.CodeLines.Add("*&      Form  " + abapFormImpl.FormName);
                segmentFormImpl.CodeLines.Add("*&---------------------------------------------------------------------*");
                segmentFormImpl.CodeLines.Add("*       " + abapFormImpl.FormDesc);
                segmentFormImpl.CodeLines.Add("*&---------------------------------------------------------------------*");
                segmentFormImpl.CodeLines.Add("*  -->  p1        text");
                segmentFormImpl.CodeLines.Add("*  <--  p2        text");
                segmentFormImpl.CodeLines.Add("*&---------------------------------------------------------------------*");
                segmentFormImpl.CodeLines.Add("FORM " + abapFormImpl.FormName + " .");
                segmentFormImpl.CodeLines.Add("");

                //Indicate the First Fetching DB Table
                bool firstFetchingTable;
                firstFetchingTable = true;
                foreach (AnalysisTable abapTable in abapFormImpl.InTabes)
                {
                    //Add Table Crear
                    segmentFormImpl.CodeLines.Add("Clear " + abapTable.TableName + "[].");
                    //Add Entries header
                    if (abapTable.Entries != null)
                        segmentFormImpl.CodeLines.Add("IF " + abapTable.Entries.TableName + "[] IS NOT INITIAL.");
                    //Add Comment
                    segmentFormImpl.CodeLines.Add("\"" + abapTable.TableDesc);
                    //Add SQL
                    segmentFormImpl.CodeLines.Add("SELECT");
                    //Add selection fields
                    foreach (AnalysisField selectionField in abapTable.SelectionFields)
                    {
                        if(selectionField.TableAs != null)
                            segmentFormImpl.CodeLines.Add("\t" + selectionField.TableAs + "~" + selectionField.FieldName + "\"" + selectionField.FieldDesc);
                        else
                            segmentFormImpl.CodeLines.Add("\t" + selectionField.FieldName + "\"" + selectionField.FieldDesc);
                    }
                    bool firstFromTable;
                    firstFromTable = true;
                    //Add selection From
                    foreach (AnalysisTable selectionFrom in abapTable.SelectionFrom)
                    {
                        if (firstFromTable)
                        {
                            //From ZTable as A
                            if (selectionFrom.TableAs != null)
                                segmentFormImpl.CodeLines.Add("\tFROM " + selectionFrom.TableName + " AS " + selectionFrom.TableAs);
                            //From ZTable as A
                            else
                                segmentFormImpl.CodeLines.Add("\tFROM " + selectionFrom.TableName);
                        }
                        else
                        {
                            //Innter Join / Left Join / Right Join ZTable as A 
                            segmentFormImpl.CodeLines.Add("\t" + selectionFrom.JoinType.ToString() + " " + selectionFrom.TableName + " AS " + selectionFrom.TableAs);
                            bool firstJoinOn;
                            firstJoinOn = true;
                            foreach (AnalysisCondition abapCondition in selectionFrom.JoinCondition)
                            {
                                if (firstJoinOn)
                                    //ON A~FIELD1 EQ B~FIELD1
                                    segmentFormImpl.CodeLines.Add("ON " + abapCondition.LTableAs + "~" + abapCondition.LFieldName + " EQ " + abapCondition.RTableAs + "~" + abapCondition.RFieldName);
                                else
                                    //AND A~FIELD1 EQ B~FIELD1
                                    segmentFormImpl.CodeLines.Add("AND " + abapCondition.LTableAs + "~" + abapCondition.LFieldName + " EQ " + abapCondition.RTableAs + "~" + abapCondition.RFieldName);
                                firstJoinOn = false;
                            }
                        }
                        firstFromTable = false;
                    }
                    //Add Into Table Statement
                    if(firstFetchingTable)
                        segmentFormImpl.CodeLines.Add("INTO CORRESPONDING FIELDS OF TABLE " + abapTable.TableName);
                    else
                        segmentFormImpl.CodeLines.Add("APPENDING CORRESPONDING FIELDS OF TABLE " + abapTable.TableName);
                    //Add For All Entries Line
                    if (abapTable.Entries != null)
                        segmentFormImpl.CodeLines.Add("FOR ALL ENTRIES IN " + abapTable.Entries);
                    //Add selection Contions
                    bool firstCondition;
                    firstCondition = true;
                    foreach (AnalysisCondition selectionCondition in abapTable.SelectionConditions)
                    {
                        if (firstCondition)
                            //ON A~FIELD1 EQ B~FIELD1
                            segmentFormImpl.CodeLines.Add("WHERE " + selectionCondition.LTableAs + "~" + selectionCondition.LFieldName + " EQ " + selectionCondition.RTableAs + "~" + selectionCondition.RFieldName);
                        else
                            //AND A~FIELD1 EQ B~FIELD1
                            segmentFormImpl.CodeLines.Add("AND " + selectionCondition.LTableAs + "~" + selectionCondition.LFieldName + " EQ " + selectionCondition.RTableAs + "~" + selectionCondition.RFieldName);
                        firstCondition = false;
                    }
                    segmentFormImpl.CodeLines.Add(".");
                    //Add Entries foot
                    if (abapTable.Entries != null)
                        segmentFormImpl.CodeLines.Add("ENDIF .");
                    //Add Sort
                    string TableSortStr = "";
                    TableSortStr = "SORT " + abapTable.TableName + " BY ";
                    foreach (AnalysisField TableKey in abapTable.TableKeys)
                    {
                        TableSortStr += TableKey.FieldName + " ";
                    }
                    TableSortStr += ".";
                    segmentFormImpl.CodeLines.Add(TableSortStr);
                    segmentFormImpl.CodeLines.Add("");
                    //Indicate the First Fetching DB Table
                    firstFetchingTable = false;
                }
                segmentFormImpl.CodeLines.Add("ENDFORM                    \" " + abapFormImpl.FormName );
            }
            return segments;
        }
    }
}