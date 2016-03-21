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

            //Add Fieldcatlog Form
            TranslationSegment segmentFieldcatlog = new TranslationSegment("ALV_FIELDCATLOG", TranslationSegmentType.ALV);

            //Add Form Header
            segmentFieldcatlog.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentFieldcatlog.CodeLines.Add("*&      Form  " + analysisResult.ALVSpecImpl.FormName);
            segmentFieldcatlog.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentFieldcatlog.CodeLines.Add("*       " + analysisResult.ALVSpecImpl.FormDesc);
            segmentFieldcatlog.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentFieldcatlog.CodeLines.Add("*  -->  p1        text");
            segmentFieldcatlog.CodeLines.Add("*  <--  p2        text");
            segmentFieldcatlog.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentFieldcatlog.CodeLines.Add("FORM " + analysisResult.ALVSpecImpl.FormName + " .");
            segmentFieldcatlog.CodeLines.Add("");

            segmentFieldcatlog.CodeLines.Add("\tIS_LAYOUT-COLWIDTH_OPTIMIZE = 'X'.");
            segmentFieldcatlog.CodeLines.Add("\tPERFORM APPEND_FIELDCAT USING:");

            //Add Fieldcatlogs
            for (int i = 0; i < analysisResult.OutputFields.Count; i++)
            {
                //Add \t\t
                string strCatlog = "\t\t";

                //Add catlog items
                for (int j = 0; j < analysisResult.OutputFields[i].CatlogProperties.Count; j++)
                {
                    strCatlog += "'" + analysisResult.OutputFields[i].CatlogProperties[j].CatlogValue + "' ";
                }
                if (i == analysisResult.OutputFields.Count - 1)
                    strCatlog += ".\t\"[" + i.ToString() + "]" + analysisResult.OutputFields[i].FieldDesc;
                else
                    strCatlog += ",\t\"[" + i.ToString() + "]" + analysisResult.OutputFields[i].FieldDesc;

                segmentFieldcatlog.CodeLines.Add(strCatlog);
            }
            segmentFieldcatlog.CodeLines.Add("ENDFORM                    \" " + analysisResult.ALVSpecImpl.FormName);
            
            segments.Add(segmentFieldcatlog);

            //Add Fieldcatlog Comments
            TranslationSegment segmentALVFieldComments = new TranslationSegment("ALV_Field_Comments", TranslationSegmentType.ALV);

            segmentFieldcatlog.CodeLines.Add("************************************************************************");
            segmentFieldcatlog.CodeLines.Add("*OUTPUT FIELDS");
            segmentFieldcatlog.CodeLines.Add("************************************************************************");
            
            //Add Fieldcatlog comments
            for (int i = 0; i < analysisResult.OutputFields.Count; i++)
                segmentFieldcatlog.CodeLines.Add("\"[" + i.ToString() + "]" + analysisResult.OutputFields[i].FieldDesc);
            
            segments.Add(segmentALVFieldComments);

            //Add Fieldcatlog APPEND_FIELDCAT Form
            TranslationSegment segmentAppendCatlog = new TranslationSegment("ALV_APPEND_CATLOG", TranslationSegmentType.ALV);

            //Add Form Header
            segmentAppendCatlog.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentAppendCatlog.CodeLines.Add("*&      Form  " + analysisResult.AppendFieldCatlogImpl.FormName);
            segmentAppendCatlog.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentAppendCatlog.CodeLines.Add("*       " + analysisResult.AppendFieldCatlogImpl.FormDesc);
            segmentAppendCatlog.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentAppendCatlog.CodeLines.Add("*  -->  p1        text");
            segmentAppendCatlog.CodeLines.Add("*  <--  p2        text");
            segmentAppendCatlog.CodeLines.Add("*&---------------------------------------------------------------------*");
            
            //Add Form USING Parameters
            for (int i = 0; i < analysisResult.AppendFieldCatlogImpl.CatlogProperties.Count; i++)
            {
                //First Line
                if(i == 0)
                    segmentAppendCatlog.CodeLines.Add("FORM " 
                        + analysisResult.AppendFieldCatlogImpl.FormName 
                        + " USING VALUE(" + analysisResult.AppendFieldCatlogImpl.CatlogProperties[i].CatlogName
                        + ")");
                //Last Line
                else if (i == analysisResult.AppendFieldCatlogImpl.CatlogProperties.Count - 1)
                    segmentAppendCatlog.CodeLines.Add("\t\t\t"
                        + analysisResult.AppendFieldCatlogImpl.FormName
                        + " USING VALUE(" + analysisResult.AppendFieldCatlogImpl.CatlogProperties[i].CatlogName
                        + ").");
                //Center Line
                else
                    segmentAppendCatlog.CodeLines.Add("\t\t\t"
                        + analysisResult.AppendFieldCatlogImpl.FormName
                        + " USING VALUE(" + analysisResult.AppendFieldCatlogImpl.CatlogProperties[i].CatlogName
                        + ")");
            }

            //Add Field catlog assign statement
            foreach (AnalysisFieldCatlog FieldcatProp in analysisResult.AppendFieldCatlogImpl.CatlogProperties)
            {
                string strCatlogPropAssign = "\t";
                foreach (AnalysisField PropTargetField in FieldcatProp.Targets)
                {
                    strCatlogPropAssign += "IT_FIELDCAT-" + PropTargetField.FieldName + " = "; 
                }
                strCatlogPropAssign += FieldcatProp.CatlogName;
            }

            //  APPEND IT_FIELDCAT.
            segmentAppendCatlog.CodeLines.Add("\tAPPEND IT_FIELDCAT.");

            //  CLEAR IT_FIELDCAT.
            segmentAppendCatlog.CodeLines.Add("\tCLEAR IT_FIELDCAT.");

            //ENDFORM
            segmentAppendCatlog.CodeLines.Add("ENDFORM                    \" " + analysisResult.AppendFieldCatlogImpl.FormName);

            //Add Append Fieldcatlog Form segment
            segments.Add(segmentAppendCatlog);

            //Add Fieldcatlog APPEND_FIELDCAT Form
            TranslationSegment segmentALVCALL = new TranslationSegment("ALV_CALL", TranslationSegmentType.ALV);

            segmentALVCALL.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentALVCALL.CodeLines.Add("*&      Form  " + analysisResult.ALVCallImpl.FormName);
            segmentALVCALL.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentALVCALL.CodeLines.Add("*       " + analysisResult.ALVCallImpl.FormDesc);
            segmentALVCALL.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentALVCALL.CodeLines.Add("*  -->  p1        text");
            segmentALVCALL.CodeLines.Add("*  <--  p2        text");
            segmentALVCALL.CodeLines.Add("*&---------------------------------------------------------------------*");
            segmentALVCALL.CodeLines.Add("FORM " + analysisResult.ALVCallImpl.FormName + " .");
            segmentALVCALL.CodeLines.Add("");

            //  CALL FUNCTION 'REUSE_ALV_GRID_DISPLAY'
            segmentALVCALL.CodeLines.Add("\tCALL FUNCTION 'REUSE_ALV_GRID_DISPLAY'");

            //    EXPORTING
            segmentALVCALL.CodeLines.Add("\t\tEXPORTING");

            //*     I_INTERFACE_CHECK                 = ' '
            segmentALVCALL.CodeLines.Add("*     I_INTERFACE_CHECK                 = ' '");

            //*     I_BYPASSING_BUFFER                = ' '
            segmentALVCALL.CodeLines.Add("*     I_BYPASSING_BUFFER                = ' '");

            //*     I_BUFFER_ACTIVE                   = ' '
            segmentALVCALL.CodeLines.Add("*     I_BUFFER_ACTIVE                   = ' '");

            //      I_CALLBACK_PROGRAM                = SY-CPROG
            segmentALVCALL.CodeLines.Add("\t\t\tI_CALLBACK_PROGRAM                = SY-CPROG");

            //*     I_CALLBACK_PF_STATUS_SET          = ' '
            segmentALVCALL.CodeLines.Add("*     I_CALLBACK_PF_STATUS_SET          = ' '");

            //*     I_CALLBACK_USER_COMMAND           = ' '
            segmentALVCALL.CodeLines.Add("*     I_CALLBACK_USER_COMMAND           = ' '");

            //*     I_CALLBACK_TOP_OF_PAGE            = ' '
            segmentALVCALL.CodeLines.Add("*     I_CALLBACK_TOP_OF_PAGE            = ' '");

            //*     I_CALLBACK_HTML_TOP_OF_PAGE       = ' '
            segmentALVCALL.CodeLines.Add("*     I_CALLBACK_HTML_TOP_OF_PAGE       = ' '");

            //*     I_CALLBACK_HTML_END_OF_LIST       = ' '
            segmentALVCALL.CodeLines.Add("*     I_CALLBACK_HTML_END_OF_LIST       = ' '");

            //*     I_STRUCTURE_NAME                  =
            segmentALVCALL.CodeLines.Add("*     I_STRUCTURE_NAME                  =");

            //*     I_BACKGROUND_ID                   = ' '
            segmentALVCALL.CodeLines.Add("*     I_BACKGROUND_ID                   = ' '");

            //*     I_GRID_TITLE                      =
            segmentALVCALL.CodeLines.Add("*     I_GRID_TITLE  ");

            //*     I_GRID_SETTINGS                   =
            segmentALVCALL.CodeLines.Add("*     I_GRID_SETTINGS                   =");

            //      IS_LAYOUT                         = IS_LAYOUT
            segmentALVCALL.CodeLines.Add("\t\t\tIS_LAYOUT                         = IS_LAYOUT");

            //      IT_FIELDCAT                       = IT_FIELDCAT[]
            segmentALVCALL.CodeLines.Add("\t\t\tIT_FIELDCAT                       = IT_FIELDCAT[]");

            //*     IT_EXCLUDING                      =
            segmentALVCALL.CodeLines.Add("*     IT_EXCLUDING                      =");

            //*     IT_SPECIAL_GROUPS                 =
            segmentALVCALL.CodeLines.Add("*     IT_SPECIAL_GROUPS                 =");

            //*     IT_SORT                           =
            segmentALVCALL.CodeLines.Add("*     IT_SORT                           =");

            //*     IT_FILTER                         =
            segmentALVCALL.CodeLines.Add("*     IT_FILTER                         =");

            //*     IS_SEL_HIDE                       =
            segmentALVCALL.CodeLines.Add("*     IS_SEL_HIDE                       =");

            //*     I_DEFAULT                         = 'X'
            segmentALVCALL.CodeLines.Add("*     I_DEFAULT                         = 'X'");

            //      I_SAVE                            = 'A'
            segmentALVCALL.CodeLines.Add("      I_SAVE                            = 'A'");

            //*     IS_VARIANT                        =
            segmentALVCALL.CodeLines.Add("*     IS_VARIANT                        =");

            //*     IT_EVENTS                         =
            segmentALVCALL.CodeLines.Add("*     IT_EVENTS                         =");

            //*     IT_EVENT_EXIT                     =
            segmentALVCALL.CodeLines.Add("*     IT_EVENT_EXIT                     =");

            //*     IS_PRINT                          =
            segmentALVCALL.CodeLines.Add("*     IS_PRINT                          =");

            //*     IS_REPREP_ID                      =
            segmentALVCALL.CodeLines.Add("*     IS_REPREP_ID                      =");

            //*     I_SCREEN_START_COLUMN             = 0
            segmentALVCALL.CodeLines.Add("*     I_SCREEN_START_COLUMN             = 0");

            //*     I_SCREEN_START_LINE               = 0
            segmentALVCALL.CodeLines.Add("*     I_SCREEN_START_LINE               = 0");

            //*     I_SCREEN_END_COLUMN               = 0
            segmentALVCALL.CodeLines.Add("*     I_SCREEN_END_COLUMN               = 0");

            //*     I_SCREEN_END_LINE                 = 0
            segmentALVCALL.CodeLines.Add("*     I_SCREEN_END_LINE                 = 0");

            //*     I_HTML_HEIGHT_TOP                 = 0
            segmentALVCALL.CodeLines.Add("*     I_HTML_HEIGHT_TOP                 = 0");

            //*     I_HTML_HEIGHT_END                 = 0
            segmentALVCALL.CodeLines.Add("*     I_HTML_HEIGHT_END                 = 0");

            //*     IT_ALV_GRAPHICS                   =
            segmentALVCALL.CodeLines.Add("*     IT_ALV_GRAPHICS                   =");

            //*     IT_HYPERLINK                      =
            segmentALVCALL.CodeLines.Add("*     IT_HYPERLINK                      =");

            //*     IT_ADD_FIELDCAT                   =
            segmentALVCALL.CodeLines.Add("*     IT_ADD_FIELDCAT                   =");

            //*     IT_EXCEPT_QINFO                   =
            segmentALVCALL.CodeLines.Add("*     IT_EXCEPT_QINFO                   =");

            //*     IR_SALV_FULLSCREEN_ADAPTER        =
            segmentALVCALL.CodeLines.Add("*     IR_SALV_FULLSCREEN_ADAPTER        =");

            //*   IMPORTING
            segmentALVCALL.CodeLines.Add("*   IMPORTING");

            //*     E_EXIT_CAUSED_BY_CALLER           =
            segmentALVCALL.CodeLines.Add("*     E_EXIT_CAUSED_BY_CALLER           =");

            //*     ES_EXIT_CAUSED_BY_USER            =
            segmentALVCALL.CodeLines.Add("*     ES_EXIT_CAUSED_BY_USER            =");

            //    TABLES
            segmentALVCALL.CodeLines.Add("\t\tTABLES");

            //      T_OUTTAB                          = T_ALV[]
            segmentALVCALL.CodeLines.Add("\t\t\tT_OUTTAB                          = " 
                + analysisResult.SplitterFormImpl.ALVTable.TableName + "[]");

            //    EXCEPTIONS
            segmentALVCALL.CodeLines.Add("\t\tEXCEPTIONS");

            //      PROGRAM_ERROR                     = 1
            segmentALVCALL.CodeLines.Add("\t\t\tPROGRAM_ERROR                     = 1");

            //      OTHERS                            = 2
            segmentALVCALL.CodeLines.Add("\t\t\tOTHERS                            = 2");

            //            .
            segmentALVCALL.CodeLines.Add("\t\t\t\t.");

            //  IF SY-SUBRC <> 0.
            segmentALVCALL.CodeLines.Add("\tIF SY-SUBRC <> 0.");

            //* MESSAGE ID SY-MSGID TYPE SY-MSGTY NUMBER SY-MSGNO
            segmentALVCALL.CodeLines.Add("* MESSAGE ID SY-MSGID TYPE SY-MSGTY NUMBER SY-MSGNO");

            //*         WITH SY-MSGV1 SY-MSGV2 SY-MSGV3 SY-MSGV4.
            segmentALVCALL.CodeLines.Add("*         WITH SY-MSGV1 SY-MSGV2 SY-MSGV3 SY-MSGV4.");

            //  ENDIF.
            segmentALVCALL.CodeLines.Add("\tENDIF.");
            
            segmentALVCALL.CodeLines.Add("\t");

            //ENDFORM
            segmentALVCALL.CodeLines.Add("ENDFORM                    \" " + analysisResult.ALVCallImpl.FormName);

            //Append ALV CALL Segment
            segments.Add(segmentALVCALL);

            return segments;
        }
    }
}