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
        #region Cell1
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
        #endregion
        #region Cell2
        private int? cell2TextBox;
        public int? Cell2TextBox
        {
            get => cell2TextBox;
            set
            {
                CalculationServices.Single(p => p.Row == 2).InputCell.OnNext(value);
                this.RaiseAndSetIfChanged(ref cell2TextBox, value);
            }
        }

        private ObservableAsPropertyHelper<int?> cell2TextBlock;
        public int? Cell2TextBlock
        {
            get => cell2TextBlock.Value;
        }
        #endregion
        #region Cell3
        private int? cell3TextBox;
        public int? Cell3TextBox
        {
            get => cell3TextBox;
            set
            {
                CalculationServices.Single(p => p.Row == 3).InputCell.OnNext(value);
                this.RaiseAndSetIfChanged(ref cell3TextBox, value);
            }
        }

        private ObservableAsPropertyHelper<int?> cell3TextBlock;
        public int? Cell3TextBlock
        {
            get => cell3TextBlock.Value;
        }
        #endregion
        #region Cell4
        private int? cell4TextBox;
        public int? Cell4TextBox
        {
            get => cell4TextBox;
            set
            {
                CalculationServices.Single(p => p.Row == 4).InputCell.OnNext(value);
                this.RaiseAndSetIfChanged(ref cell4TextBox, value);
            }
        }

        private ObservableAsPropertyHelper<int?> cell4TextBlock;
        public int? Cell4TextBlock
        {
            get => cell4TextBlock.Value;
        }
        #endregion
        #region Cell5
        private int? cell5TextBox;
        public int? Cell5TextBox
        {
            get => cell5TextBox;
            set
            {
                CalculationServices.Single(p => p.Row == 5).InputCell.OnNext(value);
                this.RaiseAndSetIfChanged(ref cell5TextBox, value);
            }
        }

        private ObservableAsPropertyHelper<int?> cell5TextBlock;
        public int? Cell5TextBlock
        {
            get => cell5TextBlock.Value;
        }
        #endregion



        private IEnumerable<ICalculationService> CalculationServices { get; }

        public MainWindowViewModel(IEnumerable<ICalculationService> calculationServices = null)
        {
            CalculationServices = calculationServices ?? Locator.Current.GetServices<ICalculationService>();

            CalculationServices.Single(p => p.Row == 1).ResultValue
                .ToProperty(this, vm => vm.Cell1TextBlock, out cell1TextBlock);

            CalculationServices.Single(p => p.Row == 2).ResultValue
                .ToProperty(this, vm => vm.Cell2TextBlock, out cell2TextBlock);

            CalculationServices.Single(p => p.Row == 3).ResultValue
                .ToProperty(this, vm => vm.Cell3TextBlock, out cell3TextBlock);

            CalculationServices.Single(p => p.Row == 4).ResultValue
                .ToProperty(this, vm => vm.Cell4TextBlock, out cell4TextBlock);

            CalculationServices.Single(p => p.Row == 5).ResultValue
                .ToProperty(this, vm => vm.Cell5TextBlock, out cell5TextBlock);

        }
    }
}
