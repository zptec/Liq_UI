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
            segments.Add(new TranslationSegment(1, "*&---------------------------------------------------------------------*"));
            segments.Add(new TranslationSegment(2, "*& Report  " + ReportName));
            segments.Add(new TranslationSegment(3, "*&"));
            segments.Add(new TranslationSegment(4, "*&---------------------------------------------------------------------*"));
            segments.Add(new TranslationSegment(5, "*& Auto generated report"));
            segments.Add(new TranslationSegment(6, "*&"));
            segments.Add(new TranslationSegment(7, "*& Package: Z001"));
            segments.Add(new TranslationSegment(8, "*& Program: " + ReportName));
            segments.Add(new TranslationSegment(9, "*& T-CODE: ZXXXXX"));
            segments.Add(new TranslationSegment(10, "*& Author: Boris Town (HAND)"));
            segments.Add(new TranslationSegment(11, "*& Created on: " + DateTime.Now.ToShortDateString()));
            segments.Add(new TranslationSegment(12, "*&---------------------------------------------------------------------*"));
            return segments;
        }
    }
}