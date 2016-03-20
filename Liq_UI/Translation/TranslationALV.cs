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
            List<TranslationSegment> segments = new List<TranslationSegment>();

            //Add Mapping Form
            TranslationSegment segmentALVCALL = new TranslationSegment("ALV_CALL", TranslationSegmentType.DBFetching);

            segments.Add(segmentALVCALL);

            return segments;

        }
    }
}