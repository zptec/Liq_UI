﻿using System;

namespace Liq_UI.Translation
{
    internal class TranslationHeading
    {
        private TranslationBase translationBase;

        public TranslationHeading(TranslationBase translationBase)
        {
            this.translationBase = translationBase;
        }

        //Generate code
        internal TranslationSegment GenerateCode()
        {
            return new TranslationSegment();
        }
    }
}