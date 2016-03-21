using Liq_UI.Analysis;
using System.Collections.Generic;

namespace Liq_UI.Translation
{
    internal class TranslationALV
    {
        //Analysis Result
        private AnalysisBase analysisResult;

        private TranslationBase translationBase;
        
        public TranslationALV(AnalysisBase analysisResult)
        {
            this.analysisResult = analysisResult;
        }

        public TranslationALV(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        internal List<TranslationSegment> GenerateCode()
        {
            List<TranslationSegment> segments = new List<TranslationSegment>();

            //Add Mapping Form
            TranslationSegment segmentALVCALL = new TranslationSegment("ALV_CALL", TranslationSegmentType.DBFetching);
            segmentALVCALL.CodeLines.Add("\tIS_LAYOUT-COLWIDTH_OPTIMIZE = 'X'.");
            segmentALVCALL.CodeLines.Add("\tPERFORM APPEND_FIELDCAT USING:");
            //Add Fieldcatlogs
            for(int i; i < )
            segmentALVCALL.CodeLines.Add("");
            segments.Add(segmentALVCALL);

            return segments;

        }
    }
}