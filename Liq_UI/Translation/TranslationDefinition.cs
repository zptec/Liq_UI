using System;

namespace Liq_UI.Translation
{
    internal class TranslationDefinition
    {
        private TranslationBase translationBase;

        public TranslationDefinition(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        internal TranslationSegment GenerateCode()
        {
            return new TranslationSegment();
        }
    }
}