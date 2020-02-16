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
        private readonly IDisposable _cleanUp;
        private readonly ReadOnlyObservableCollection<SpreadsheetItemTemplateViewModel> _items;
        public ReadOnlyObservableCollection<SpreadsheetItemTemplateViewModel> Items => _items;

        public ObservableCollectionExtended<SpreadsheetItemTemplateViewModel> SourceList { get; }


        public MainWindowViewModel()
        {
            SourceList = new ObservableCollectionExtended<SpreadsheetItemTemplateViewModel>();

            Locator.CurrentMutable.RegisterConstant(new SpreadsheetItemTemplateViewModel(1), typeof(ISpreadsheetItemTemplateViewModel));
            Locator.CurrentMutable.RegisterConstant(new SpreadsheetItemTemplateViewModel(2), typeof(ISpreadsheetItemTemplateViewModel));
            Locator.CurrentMutable.RegisterConstant(new SpreadsheetItemTemplateViewModel(3), typeof(ISpreadsheetItemTemplateViewModel));
            Locator.CurrentMutable.RegisterConstant(new SpreadsheetItemTemplateViewModel(4), typeof(ISpreadsheetItemTemplateViewModel));
            Locator.CurrentMutable.RegisterConstant(new SpreadsheetItemTemplateViewModel(5), typeof(ISpreadsheetItemTemplateViewModel));

            var services = Locator.Current.GetServices<ISpreadsheetItemTemplateViewModel>();
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
