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
            TranslationSegment segmentProcessing = new TranslationSegment("Processing_FormImpl", TranslationSegmentType.DBFetching);
            foreach (AnalysisFormImpl abapFormImpl in analysisResult.FormImpl)
            {
                //Add Form Header
                segmentProcessing.CodeLines.Add("*&---------------------------------------------------------------------*");
                segmentProcessing.CodeLines.Add("*&      Form  " + abapFormImpl.FormName);
                segmentProcessing.CodeLines.Add("*&---------------------------------------------------------------------*");
                segmentProcessing.CodeLines.Add("*       " + abapFormImpl.FormDesc);
                segmentProcessing.CodeLines.Add("*&---------------------------------------------------------------------*");
                segmentProcessing.CodeLines.Add("*  -->  p1        text");
                segmentProcessing.CodeLines.Add("*  <--  p2        text");
                segmentProcessing.CodeLines.Add("*&---------------------------------------------------------------------*");
                segmentProcessing.CodeLines.Add("FORM " + abapFormImpl.FormName + " .");
                segmentProcessing.CodeLines.Add("");
            }
            segments.Add(segmentProcessing);
            return segments;
        }
    }
}