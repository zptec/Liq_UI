using Liq_UI.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
