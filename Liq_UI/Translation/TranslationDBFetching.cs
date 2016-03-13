using System;
using System.Collections.Generic;
using Liq_UI.Analysis;

namespace Liq_UI.Translation
{
    internal class TranslationDBFetching
    {
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
                //Add Table Crear
                foreach (AnalysisTable)
                {

                }
                //Add Selection Statement

                segmentFormImpl.CodeLines.Add("ENDFORM                    \" " + abapFormImpl.FormName );
            }
            return segments;
        }
    }
}