﻿using System.Collections.Generic;

namespace Liq_UI.Translation
{
    public class TranslationSegment
    {
        //Name of Segment
        private string SegName;

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
        public List<string> CodeLines = new List<string>();

        public TranslationSegment(string SegName, TranslationSegmentType SegType)
        {
            this.SegName = SegName;
            this.SegType = SegType;
        }
    }
}