using System;
using System.Collections.Generic;

namespace Liq_UI.Translation
{
    internal class TranslationHeading
    {
        //Report Name
        private string ReportName = "";

        private TranslationBase translationBase;

        public TranslationHeading()
        {
            //Set Report Name
            ReportName = "Z" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public TranslationHeading(TranslationBase translationBase) : this()
        {
            this.translationBase = translationBase;
        }

        //Generate Heading code
        internal List<TranslationSegment> GenerateCode()
        {
            List<TranslationSegment> segments = new List<TranslationSegment>();

            //Heading Top
            TranslationSegment segment = new TranslationSegment("Heading_Top", TranslationSegmentType.Heading);
            segment.CodeLines.Add("*&---------------------------------------------------------------------*");
            segment.CodeLines.Add("*& Report  " + ReportName);
            segment.CodeLines.Add("*&");
            segment.CodeLines.Add("*&---------------------------------------------------------------------*");
            segment.CodeLines.Add("*& Auto generated report");
            segment.CodeLines.Add("*&");
            segment.CodeLines.Add("*& Package: Z001");
            segment.CodeLines.Add("*& Program: " + ReportName);
            segment.CodeLines.Add("*& T-CODE: ZXXXXX");
            segment.CodeLines.Add("*& Author: Boris Town (HAND)");
            segment.CodeLines.Add("*& Created on: " + DateTime.Now.ToShortDateString());
            segment.CodeLines.Add("*&---------------------------------------------------------------------*");
            segment.CodeLines.Add("");
            segment.CodeLines.Add("report  " + ReportName + ".");
            segment.CodeLines.Add("");
            segments.Add(segment);
            
            return segments;
        }
    }
}