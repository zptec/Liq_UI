using System.Collections.Generic;
using System.Data;

namespace Liq_UI.Source
{
    internal class SourceTable
    {
        //Upper Object
        SourceData Upper = new SourceData();
        //Table Fields
        List<string> TableFields = new List<string>();
        //Table Contents 
        List<SourceTableLine> TableContents = new List<SourceTableLine>();
    }
}
