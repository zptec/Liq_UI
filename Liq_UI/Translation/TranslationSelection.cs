using System;
using System.Collections.Generic;

namespace Liq_UI.Translation
{
    internal class TranslationSelection
    {
        private TranslationBase translationBase;

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