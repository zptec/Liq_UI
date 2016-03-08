using System;
using System.Collections.Generic;

namespace Liq_UI.Translation
{
    internal class TranslationDefinition
    {
        private TranslationBase translationBase;

        public TranslationDefinition(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        internal List<TranslationSegment> GenerateCode()
        {
            return new List<TranslationSegment>();
        }
    }
}