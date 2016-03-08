using System;

namespace Liq_UI.Translation
{
    internal class TranslationProcessing
    {
        private TranslationBase translationBase;

        public TranslationProcessing(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        internal TranslationSegment GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}