using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liq_UI.Filter;
using Liq_UI.Source;
using Liq_UI.Target;

namespace Liq_UI.Searching
{
    class SearchingBase
    {
        //Mapping Source to Target
        void Source2Target()
        {

        }

        //Mapping Source to Filter
        void Source2Filter()
        {

        }

        //Table key mapping
        void TableKeyMapping()
        {

        }

        //Get Join Relation
        void GetJoinRelation()
        {

        }

        //Get Union Relation
        void GetUnionRelation()
        {

        }

        /// <summary>
        /// Search the match fields between filter and source data
        /// </summary>
        /// <param name="filterData">Filter Data</param>
        /// <param name="sourceData">Source Data</param>
        public static void Filter2Source(FilterData filterData, SourceData sourceData)
        {
            foreach (FilterField Filter_Field in filterData.Fields)
            {
                foreach (SourceTable Source_Table in sourceData.TableList)
                {
                    foreach (SourceTableLine Source_Table_Line in Source_Table.TableContents)
                    {
                        for (int i = 0; i < Source_Table_Line.FieldDataList.Count; i++)
                        {
                            if (SearchingMatching.Equal(Source_Table_Line.FieldDataList[i].FieldValue, Filter_Field.FilterFieldValue))
                            {
                                Filter_Field.RefTableField.Add(Source_Table.TableName, Source_Table.TableFields[i]);
                            }
                        }
                    }
                }
            }
            SearchingBack.SourceBackToFilter(sourceData, filterData);
        }

        /// <summary>
        /// Search the match fields between target and source data
        /// </summary>
        /// <param name="targetData">Target Data</param>
        /// <param name="sourceData">Source Data</param>
        public static void Target2Source(TargetData targetData, SourceData sourceData)
        {
            for (int i = 0; i < targetData.TargetTable.TableContent.Count; i++)
            {
                for (int j = 0; j < targetData.TargetTable.TableContent[i].Fields.Count; j++)
                {
                    foreach(SourceTable Source_Table in sourceData.TableList)
                    {
                        foreach (SourceTableLine Source_Table_Line in Source_Table.TableContents)
                        {
                            for (int k = 0; k < Source_Table_Line.FieldDataList.Count; k++)
                            {
                                if (SearchingMatching.Equal(Source_Table_Line.FieldDataList[k].FieldValue, targetData.TargetTable.TableContent[i].Fields[j].FieldValue))
                                {
                                    targetData.TargetTable.TableContent[i].Fields[j].RefTableField.Add(Source_Table.TableName, Source_Table.TableFields[i]);
                                }
                            }
                        }
                    }
                }
            }
            SearchingBack.SourceBackToTarget(sourceData, targetData);
        }
    }
}
