using System;
using System.Collections.Generic;

namespace Liq_UI.Translation
{
    internal class TranslationCode
    {
        //Code type string
        string Code = "";

        //Code Segments
        List<TranslationSegment> CodeSegments = new List<TranslationSegment>();

        //Insert Code Segment
        internal void InsertCode(List<TranslationSegment> Segments)
        {
            CodeSegments.AddRange(Segments);
        }
    }
}