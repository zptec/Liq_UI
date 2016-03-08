﻿using System;
using System.Collections.Generic;
using Liq_UI.Analysis;

namespace Liq_UI.Translation
{
    internal class TranslationSelection
    {
        //Analysis Result
        private AnalysisBase analysisResult;

        //Translation Base Info
        private TranslationBase translationBase;

        public TranslationSelection(AnalysisBase analysisResult)
        {
            this.analysisResult = analysisResult;
        }

        public TranslationSelection(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        internal List<TranslationSegment> GenerateCode()
        {
            return new List<TranslationSegment>();
        }
    }
}