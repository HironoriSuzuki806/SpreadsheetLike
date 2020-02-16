using System;
using System.Collections.Generic;
using System.Text;

namespace SpreadsheetLikeListView
{
    public interface ISpreadsheetItemTemplateViewModel
    {
        int Row { get; }

        int? InputCell { get; }

        int? ResultValue { get; }

    }
}
