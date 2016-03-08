using System;

namespace Liq_UI.Translation
{
    internal class TranslationTableReading
    {
        private TranslationBase translationBase;

        public TranslationTableReading(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        internal TranslationSegment GenerateCode()
        {
            return new TranslationSegment();
        }
    }
}