namespace Liq_UI.Analysis
{
    public class AnalysisJoinType
    {
        internal AnalysisJoinTypeEnum JoinTypes = new AnalysisJoinTypeEnum();

        public override string ToString()
        {
            switch(JoinTypes)
            {
                case AnalysisJoinTypeEnum.InnerJoin: 
                    return "Inner Join";
                case AnalysisJoinTypeEnum.LeftJoin:
                    return "Left Join";
                case AnalysisJoinTypeEnum.RightJoin:
                    return "Right Join";

            }
            return "Inner Join";
        }
    }
}