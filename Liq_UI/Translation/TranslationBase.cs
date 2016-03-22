using Liq_UI.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Translation
{
    /// <summary>
    /// Translate Internal Relationship Into Source Code
    /// </summary>
    class TranslationBase
    {
        //Translate Status
        TranslationStatus Status = TranslationStatus.NotTranslated;

        //Final Code
        TranslationCode FinalCode = new TranslationCode();

        //Translate to final code
        int Translate2Code(ref AnalysisBase analysisResult)
        {
            //Translator for ABAP heading
            TranslationHeading HeadingTranslator = new TranslationHeading(analysisResult);

            //Translator for ABAP data definition
            TranslationDefinition DefTranslator = new TranslationDefinition(analysisResult);

            //Translator for ABAP selection screen
            TranslationSelection SelectionTranslator = new TranslationSelection(analysisResult);

            //Translator for ABAP DB fetching
            TranslationDBFetching DBFetchingTranslator = new TranslationDBFetching(analysisResult);

            //Translator for ABAP table reading
            TranslationTableReading ReadingTranslator = new TranslationTableReading(analysisResult);

            //Translator for ABAP internal table processing
            TranslationProcessing ProcessTranslator = new TranslationProcessing(analysisResult);

            //Translator for ABAP ALV
            TranslationALV ALVTranslator = new TranslationALV(analysisResult);

            //Generate ABAP data heading
            FinalCode.InsertCode( HeadingTranslator.GenerateCode() );

            //Generate ABAP data definition
            FinalCode.InsertCode( DefTranslator.GenerateCode() );

            //Generate ABAP selection screen
            FinalCode.InsertCode( SelectionTranslator.GenerateCode() );

            //Generate ABAP DB fetching
            FinalCode.InsertCode( DBFetchingTranslator.GenerateCode() );

            //Generate ABAP table reading
            FinalCode.InsertCode( ReadingTranslator.GenerateCode() );

            //Generate ABAP internal table processing
            FinalCode.InsertCode( ProcessTranslator.GenerateCode() );

            //Generate ABAP ALV
            FinalCode.InsertCode( ALVTranslator.GenerateCode() );

            //Change global status
            Status = TranslationStatus.TranslateFinished;

            return 1;
        }
    }
}
