using Liq_UI.Analysis;
using Liq_UI.Filter;
using Liq_UI.Source;
using Liq_UI.Target;
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
        /// Source Data
        /// </summary>
        SourceData SourceData = new SourceData();

        /// <summary>
        /// Target Data
        /// </summary>
        TargetData TargetData = new TargetData();

        /// <summary>
        /// Filter Data
        /// </summary>
        FilterData FilterData = new FilterData();

        /// <summary>
        /// Analysis Base
        /// </summary>
        AnalysisBase AnalysisBase = new AnalysisBase();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //DataTable dt = GetExcelToDataTableBySheet(this.textBox.Text, "KNA1");
            SourceData = SourceData.GetSource();
            TargetData = TargetData.GetTarget();
            FilterData = FilterData.GetFilter();
            AnalysisBase = AnalysisBase.StartAnalysis();
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
