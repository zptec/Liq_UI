using System;
using Liq_UI.Source;

namespace Liq_UI.Searching
{
    public class SearchingMatching
    {
        /// <summary>
        /// Field A eq B
        /// </summary>
        /// <param name="sourceTableField"></param>
        /// <param name="filterFieldValue"></param>
        /// <returns></returns>
        public static bool Equal(string sourceTableField, string filterFieldValue)
        {
            return sourceTableField.Equals(filterFieldValue);
        }
    }
}