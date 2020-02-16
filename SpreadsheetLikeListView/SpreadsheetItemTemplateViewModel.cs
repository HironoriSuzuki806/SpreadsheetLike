using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpreadsheetLikeListView
{
    public class SpreadsheetItemTemplateViewModel : ReactiveObject, ISpreadsheetItemTemplateViewModel
    {
        ICalculationService CalculationService { get; }

        public int Row { get; }

        private int? inputCell;
        public int? InputCell
        {
            get => inputCell; 
            set
            {
                CalculationService.InputCell.OnNext(value);
                this.RaiseAndSetIfChanged(ref inputCell, value);
            }
        }

        private readonly ObservableAsPropertyHelper<int?> resultValue;
        public int? ResultValue
        {
            get => resultValue.Value; 
        }


        public SpreadsheetItemTemplateViewModel(int row)
        {
            Row = row;
            CalculationService = CreateCalculationService();
            Locator.CurrentMutable.RegisterConstant(CalculationService, typeof(ICalculationService));

            CalculationService.ResultValue
                .ToProperty(this, vm => vm.ResultValue, out resultValue);
        }


        protected CalculationService CreateCalculationService()
        {
            return new CalculationService(Row);
        }

    }
}
