using Liq_UI.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liq_UI.Translation;
using System.Windows;

namespace Liq_UI.Training
{
    class TrainingBase
    {
        //Trainning Status
        TrainingStatus Status = new TrainingStatus();

        //Tranning List
        List<TrainingCase> TrainningList = new List<TrainingCase>();

        //Tranning Result
        List<AnalysisCase> TrainningResult = new List<AnalysisCase>();

        /// <summary>
        /// Final Code
        /// </summary>
        public string FinalCode { get; private set; }

        /// <summary>
        /// Probability
        /// </summary>
        public double Probability { get; private set; }

        /// <summary>
        /// Init Training Processer
        /// </summary>
        internal void Init()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update Training Data
        /// </summary>
        /// <param name="process_Analysis">Analysis Result</param>
        /// <param name="output_Translation">Translation Result</param>
        internal void Update(AnalysisBase process_Analysis, TranslationBase output_Translation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Output Training Result
        /// </summary>
        internal void OutputResult()
        {
            //Output Probability and Target Code
            MessageBox.Show(this.Probability + "%\n" + this.FinalCode);
        }
    }
}
