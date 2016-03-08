using System;
using System.Collections.Generic;

namespace Liq_UI.Translation
{
    internal class TranslationTableReading
    {
        private TranslationBase translationBase;

        public TranslationTableReading(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        internal List<TranslationSegment> GenerateCode()
        {
            return new List<TranslationSegment>();
        }
    }
}