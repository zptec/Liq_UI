using Liq_UI.Analysis;
using Liq_UI.Filter;
using Liq_UI.Source;
using Liq_UI.Target;
using System.Collections.Generic;

namespace Liq_UI.Trainning
{
    internal class TrainningCase
    {
        //Upper Object
        TrainningBase UpperObject = new TrainningBase();

        //Source Data
        SourceData SourceData = new SourceData();

        //Target Data
        TargetData TargetDate = new TargetData();

        //Filter Data
        FilterData FilterData = new FilterData();

        //Analysis Case
        List<AnalysisCase> AnalysisCase = new List<AnalysisCase>();
    }
}