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
                segmentStartOfSelection.CodeLines.Add("PERFORM " + abapFormCall.FromName + ".");
            }
            segments.Add(segmentStartOfSelection);

            //Add each of Form implementation
            foreach (AnalysisFormImpl abapFormImpl in analysisResult.FormImpl)
            {
                //

            }
            return segments;
        }
    }
}