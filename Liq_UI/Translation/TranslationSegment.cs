using System.Collections.Generic;

namespace Liq_UI.Translation
{
    internal class TranslationSegment
    {
        //Segment Type
        TranslationSegmentType SegType = new TranslationSegmentType();

        //File Name
        string FileName = "";

        //Begin Line
        int BeginLine;

        //Line Count
        int LineCount
        {
            get { return CodeLines.Count; }
        }

        //End Line
        int EndLine
        {
            get { return BeginLine + LineCount + 1; }
        }

        //Code Lines
        List<string> CodeLines = new List<string>();
        private int v1;
        private string v2;

        public TranslationSegment(int v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}