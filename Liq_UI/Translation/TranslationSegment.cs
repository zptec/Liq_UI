namespace Liq_UI.Translation
{
    internal class TranslationSegment
    {
        //Begin Line
        int BeginLine;

        //Line Count
        int LineCount;

        //End Line
        int EndLine
        {
            get { return BeginLine + LineCount + 1; }
        }
    }
}