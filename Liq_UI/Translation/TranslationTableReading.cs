using System;

namespace Liq_UI.Translation
{
    internal class TranslationALV
    {
        private TranslationBase translationBase;

        public TranslationALV(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        internal TranslationSegment GenerateCode()
        {
            return new TranslationSegment();
        }
    }
}