﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liq_UI.Analysis;

namespace Liq_UI.Filter
{
    public class FilterData
    {
        /// <summary>
        /// Filter Field List
        /// </summary>
        public List<FilterField> Fields { get; public set; }

        public FilterData GetFilter()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Filter
        /// </summary>
        /// <param name="inputData">Input Data Set</param>
        /// <returns>Filter of Input Data</returns>
        public static FilterData GetFilter(DataSet inputData)
        {
            throw new NotImplementedException();
        }
    }
}
