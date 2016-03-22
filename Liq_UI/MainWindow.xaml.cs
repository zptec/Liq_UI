using Liq_UI.Analysis;
using Liq_UI.Filter;
using Liq_UI.IO;
using Liq_UI.Source;
using Liq_UI.Target;
using Liq_UI.Training;
using Liq_UI.Translation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Liq_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Input File
        /// </summary>
        IOInputFile Input_File = new IOInputFile();

        /// <summary>
        /// Source Data
        /// </summary>
        SourceData Input_Source = new SourceData();

        /// <summary>
        /// Target Data
        /// </summary>
        TargetData Input_Target = new TargetData();

        /// <summary>
        /// Filter Data
        /// </summary>
        FilterData Input_Filter = new FilterData();

        /// <summary>
        /// Analysis Base
        /// </summary>
        AnalysisBase Process_Analysis = new AnalysisBase();

        /// <summary>
        /// Translation Base
        /// </summary>
        TranslationBase Output_Translation = new TranslationBase();

        /// <summary>
        /// Traning Base
        /// </summary>
        TrainingBase Process_Training = new TrainingBase();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //DataTable dt = GetExcelToDataTableBySheet(this.textBox.Text, "KNA1");

            //Init File Processer
            Input_File.Init();

            //Init Training Processer
            Process_Training.Init();
            
            //Read each File
            while (Input_File.ReadNextFile())
            {
                //Get Source Data
                Input_Source = SourceData.GetSource(Input_File.InputData);

                //Get Target Data
                Input_Target = TargetData.GetTarget(Input_File.InputData);

                //Get Filter
                Input_Filter = FilterData.GetFilter(Input_File.InputData);

                //Start Analysis
                Process_Analysis = AnalysisBase.StartAnalysis(Input_Source, Input_Target, Input_Filter);

                //Translate analysis result into final code
                Output_Translation = TranslationBase.Translate2Code(Process_Analysis);
                
                //Update Training Data
                Process_Training.Update(Process_Analysis, Output_Translation);
            }
            //Output Training Result
            Process_Training.OutputResult();
        }

        public static DataTable GetExcelToDataTableBySheet(string FileFullPath, string SheetName)
        {
            //string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + FileFullPath + ";Extended Properties='Excel 8.0; HDR=NO; IMEX=1'"; //此連接只能操作Excel2007之前(.xls)文件
            string strConn = "Provider=Microsoft.Ace.OleDb.15.0;" + "data source=" + FileFullPath + ";Extended Properties='Excel 15.0; HDR=NO; IMEX=1'"; //此連接可以操作.xls與.xlsx文件
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter odda = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", SheetName), conn); //("select * from [Sheet1$]", conn);
            odda.Fill(ds, SheetName);
            conn.Close();

            return ds.Tables[0];
        }
    }
}
