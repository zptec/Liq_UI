using System;
using System.Collections.Generic;

namespace Liq_UI.Translation
{
    internal class TranslationDBFetching
    {
        private TranslationBase translationBase;

        public TranslationDBFetching(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        internal List<TranslationSegment> GenerateCode()
        {
            return new List<TranslationSegment>();
        }
    }
}