using System;

namespace Liq_UI.Translation
{
    internal class TranslationSelection
    {
        private TranslationBase translationBase;

        public TranslationSelection(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        internal TranslationSegment GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}