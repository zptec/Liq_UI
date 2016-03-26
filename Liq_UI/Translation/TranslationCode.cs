using System;
using System.Collections.Generic;

namespace Liq_UI.Translation
{
    public class TranslationCode
    {
        //Code type string
        string Code = "";

        //Code Segments
        List<TranslationSegment> CodeSegments = new List<TranslationSegment>();

        //Insert Code Segment
        public void InsertCode(List<TranslationSegment> Segments)
        {
            CodeSegments.AddRange(Segments);
        }
    }
}