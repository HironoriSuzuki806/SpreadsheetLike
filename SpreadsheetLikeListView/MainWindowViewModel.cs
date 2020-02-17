using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;

namespace SpreadsheetLikeListView
{
    public class MainWindowViewModel : ReactiveObject
    {
        private static readonly int numberOfRow = 5;

        private readonly IDisposable _cleanUp;
        private readonly ReadOnlyObservableCollection<SpreadsheetItemTemplateViewModel> _items;
        public ReadOnlyObservableCollection<SpreadsheetItemTemplateViewModel> Items => _items;

        public ObservableCollectionExtended<SpreadsheetItemTemplateViewModel> SourceList { get; }


        public MainWindowViewModel()
        {
            for (int row = 1; row <= numberOfRow; row++)
            {
                var cs = new CalculationService(row);
                Locator.CurrentMutable.RegisterConstant(cs, typeof(ICalculationService));
                Locator.CurrentMutable.RegisterConstant(new SpreadsheetItemTemplateViewModel(row, cs), typeof(ISpreadsheetItemTemplateViewModel));
            }

            var services = Locator.Current.GetServices<ISpreadsheetItemTemplateViewModel>();

            SourceList = new ObservableCollectionExtended<SpreadsheetItemTemplateViewModel>();
            SourceList.AddRange(services.Select(cs => (SpreadsheetItemTemplateViewModel)cs));

            var listLoader = SourceList.ToObservableChangeSet()
                .Sort(SortExpressionComparer<SpreadsheetItemTemplateViewModel>.Ascending(vm => vm.Row))
                .Bind(out _items)
                .DisposeMany()
                .Subscribe();

            var shared = SourceList.ToObservableChangeSet()
                .AutoRefresh()
                .StartWithEmpty()
                .Publish();

            var calc = SourceList.ToObservableChangeSet()
                .AutoRefresh(c => c.InputCell)
                .ToCollection()
                .Subscribe();


            _cleanUp = new CompositeDisposable(
                calc,
                shared.Connect()
                );
        }


        public void Dispose()
        {
            _cleanUp.Dispose();
        }

    }
}
