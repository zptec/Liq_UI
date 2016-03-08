using System;
using System.Collections.Generic;

namespace Liq_UI.Translation
{
    internal class TranslationProcessing
    {
        private TranslationBase translationBase;

        public TranslationProcessing(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        internal List<TranslationSegment> GenerateCode()
        {
            return new List<TranslationSegment>();
        }
    }
}