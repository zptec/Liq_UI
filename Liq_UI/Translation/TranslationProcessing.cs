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

            segmentSplitter.CodeLines.Add("ENDFORM                    \" " + analysisResult.SplitterFormImpl.FormName);

            segments.Add(segmentSplitter);


            return segments;
        }
    }
}