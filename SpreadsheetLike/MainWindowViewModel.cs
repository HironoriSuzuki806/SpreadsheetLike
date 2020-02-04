using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace SpreadsheetLike
{
    public class MainWindowViewModel : ReactiveObject
    {
        private int? cell1TextBox;
        public int? Cell1TextBox
        {
            get => cell1TextBox;
            set
            {
                CalculationServices.Single(p => p.Row == 1).InputCell.OnNext(value);
                this.RaiseAndSetIfChanged(ref cell1TextBox, value);
            }
        }

        private ObservableAsPropertyHelper<int?> cell1TextBlock;
        public int? Cell1TextBlock
        {
            get => cell1TextBlock.Value;
        }


        private IEnumerable<ICalculationService> CalculationServices { get; }

        public MainWindowViewModel(IEnumerable<ICalculationService> calculationServices = null)
        {
            CalculationServices = calculationServices ?? Locator.Current.GetServices<ICalculationService>();

            CalculationServices.Single(p => p.Row == 1).ResultValue
                .ToProperty(this, vm => vm.Cell1TextBlock, out cell1TextBlock);
        }
    }
}
