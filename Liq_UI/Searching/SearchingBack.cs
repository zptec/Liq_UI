﻿using System;
using Liq_UI.Filter;
using Liq_UI.Source;
using Liq_UI.Target;

namespace Liq_UI.Searching
{
    internal class SearchingBack
    {
        /// <summary>
        /// Back Source Ralation to Filter
        /// </summary>
        /// <param name="sourceData">Source Data</param>
        /// <param name="filterData">Filter Data</param>
        internal static void SourceBackToFilter(SourceData sourceData, FilterData filterData)
        {
            foreach (FilterField Filter_Field in filterData.Fields)
            {
                //Each mapping weight item
                foreach (SearchingTableFieldWeight TableFieldWeightItem in Filter_Field.RefTableField.TableFieldWeightList)
                {
                    //Add to Source Data
                    TableFieldWeightItem.TableName = ;
                    TableFieldWeightItem.FieldName = ;
                }
            }
        }

        /// <summary>
        /// Back Source Ralation to Target
        /// </summary>
        /// <param name="sourceData">Source Data</param>
        /// <param name="targetData">Target Data</param>
        internal static void SourceBackToTarget(SourceData sourceData, TargetData targetData)
        {
            throw new NotImplementedException();
        }
    }
}