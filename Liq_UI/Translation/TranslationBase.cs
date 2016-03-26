using Liq_UI.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Translation
{
    /// <summary>
    /// Translate public Relationship Into Source Code
    /// </summary>
    public class TranslationBase
    {
        //Translate Status
        TranslationStatus Status = TranslationStatus.NotTranslated;

        //Final Code
        TranslationCode FinalCode = new TranslationCode();

        /// <summary>
        /// Translate analysis result into final code
        /// </summary>
        /// <param name="analysisResult">Analysis result</param>
        /// <returns>Final code detail</returns>
        public static TranslationBase Translate2Code(AnalysisBase analysisResult)
        {
            //Translation Base
            TranslationBase Process_Translate = new TranslationBase();

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

            //Translator for ABAP public table processing
            TranslationProcessing ProcessTranslator = new TranslationProcessing(analysisResult);

            //Translator for ABAP ALV
            TranslationALV ALVTranslator = new TranslationALV(analysisResult);

            //Generate ABAP data heading
            Process_Translate.FinalCode.InsertCode( HeadingTranslator.GenerateCode() );

            //Generate ABAP data definition
            Process_Translate.FinalCode.InsertCode( DefTranslator.GenerateCode() );

            //Generate ABAP selection screen
            Process_Translate.FinalCode.InsertCode( SelectionTranslator.GenerateCode() );

            //Generate ABAP DB fetching
            Process_Translate.FinalCode.InsertCode( DBFetchingTranslator.GenerateCode() );

            //Generate ABAP table reading
            Process_Translate.FinalCode.InsertCode( ReadingTranslator.GenerateCode() );

            //Generate ABAP public table processing
            Process_Translate.FinalCode.InsertCode( ProcessTranslator.GenerateCode() );

            //Generate ABAP ALV
            Process_Translate.FinalCode.InsertCode( ALVTranslator.GenerateCode() );

            //Change global status
            Process_Translate.Status = TranslationStatus.TranslateFinished;

            return Process_Translate;
        }
    }
}
