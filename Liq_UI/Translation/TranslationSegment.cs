using System.Collections.Generic;

namespace Liq_UI.Translation
{
    internal class TranslationSegment
    {
        //Begin Line
        int BeginLine;

        //Line Count
        int LineCount
        {
            get { return CodeLines.Count; }
            set { LineCount = value; }
        }

        //End Line
        int EndLine
        {
            get { return BeginLine + LineCount + 1; }
        }

        //Code Lines
        List<string> CodeLines = new List<string>();
    }
}