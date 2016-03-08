using System.Collections.Generic;

namespace Liq_UI.Translation
{
    internal class TranslationALV
    {
        private TranslationBase translationBase;

        public TranslationALV(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        internal List<TranslationSegment> GenerateCode()
        {
            return new List<TranslationSegment>();
        }
    }
}