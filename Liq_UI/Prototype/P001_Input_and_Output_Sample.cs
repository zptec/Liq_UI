using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liq_UI.Prototype
{
    /// <summary>
    /// Input And Output Sample of Rapid Prototype
    /// </summary>
    class P001_Input_and_Output_Sample
    {
        /// §1 First Sample

        /// §1.1 Input

        /// §1.1.1 Source Data

        /// <summary>
        /// §1.1.1.1 VBAK Table Data
        /// </summary>
        string[,] VBAK = new string[,]
        {
            { "VBELN",          "KUNNR"     },
            { "1200000249",     "LC00001"   },
            { "1200000315",     "CWC01"     },
            { "1300000096",     "LC00001"   }
        };

        /// <summary>
        /// §1.1.1.2 KNA1 Table Data
        /// </summary>
        string[,] KNA1 = new string[,]
        {
            { "KUNNR",          "LAND1",        "NAME1"                                 },
            { "CUST1400",       "TH",           "RTC (INTERNA"                          },
            { "CUST1500",       "HK",           "CUST1500 CWMJ"                         },
            { "CWC01",          "JP",           "CITIZEN WATCH CO., LTD."               },
            { "K836",           "JP",           "KUMAGAI CO., LTD."                     },
            { "LC00001",        "HK",           "KANKYOO KANTOKU (HONGKONG) CO.,LTD."   }
        };

        /// <summary>
        /// §1.1.2 Filter Data
        /// </summary>
        string[,] FilterData = new string[,]
        {
            { "Customer",       "LC00001"       }
        };

        /// <summary>
        /// §1.1.3 Target Data
        /// </summary>
        string[,] TargetData = new string[,]
        {
            { "Customer",       "Customer Name",                            "SO" },
            { "LC00001",        "KANKYOO KANTOKU (HONGKONG) CO.,LTD.",      "1200000249" },
            { "LC00001",        "KANKYOO KANTOKU (HONGKONG) CO.,LTD.",      "1300000096" }
        };

        /// §1.2 Output
        /// [Filter-Source]
        /// [Customer]LC00001 [VBAK]KUNNR,1,LC00001
        /// [Customer]LC00001 [VBAK]KUNNR,3,LC00001
        /// [Customer]LC00001 [KNA1]KUNNR,5,LC00001
        /// [Filter-Target]
        /// [Customer]LC00001 [Customer]1,LC00001
        /// [Customer]LC00001 [Customer]2,LC00001
        /// [Target-Source]
        /// [Customer]1
        /// 
    }
}
