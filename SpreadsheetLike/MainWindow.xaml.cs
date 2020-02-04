using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpreadsheetLike
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewFor<MainWindowViewModel>
    {

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
            .Register(nameof(ViewModel), typeof(MainWindowViewModel), typeof(MainWindow));

        public MainWindowViewModel ViewModel
        {
            get => (MainWindowViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, (object)value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainWindowViewModel)value;
        }

        public MainWindow()
        {
            InitializeComponent();

            Locator.CurrentMutable.RegisterConstant(new CalculationService(1), typeof(ICalculationService));
            Locator.CurrentMutable.RegisterConstant(new CalculationService(2), typeof(ICalculationService));
            Locator.CurrentMutable.RegisterConstant(new CalculationService(3), typeof(ICalculationService));
            Locator.CurrentMutable.RegisterConstant(new CalculationService(4), typeof(ICalculationService));
            Locator.CurrentMutable.RegisterConstant(new CalculationService(5), typeof(ICalculationService));


            ViewModel = new MainWindowViewModel();

            this.WhenActivated(disposable =>
            {
                // Row1
                this.Bind(this.ViewModel, vm => vm.Cell1TextBox, v => v.Cell1TextBox.Text)
                    .DisposeWith(disposable);

                this.OneWayBind(this.ViewModel, vm => vm.Cell1TextBlock, x => x.Cell1TextBlock.Text)
                    .DisposeWith(disposable);

                // Row2
                this.Bind(this.ViewModel, vm => vm.Cell2TextBox, v => v.Cell2TextBox.Text)
                    .DisposeWith(disposable);

                this.OneWayBind(this.ViewModel, vm => vm.Cell2TextBlock, x => x.Cell2TextBlock.Text)
                    .DisposeWith(disposable);

                // Row3
                this.Bind(this.ViewModel, vm => vm.Cell3TextBox, v => v.Cell3TextBox.Text)
                    .DisposeWith(disposable);

                this.OneWayBind(this.ViewModel, vm => vm.Cell3TextBlock, x => x.Cell3TextBlock.Text)
                    .DisposeWith(disposable);

                // Row4
                this.Bind(this.ViewModel, vm => vm.Cell4TextBox, v => v.Cell4TextBox.Text)
                    .DisposeWith(disposable);

                this.OneWayBind(this.ViewModel, vm => vm.Cell4TextBlock, x => x.Cell4TextBlock.Text)
                    .DisposeWith(disposable);

                // Row5
                this.Bind(this.ViewModel, vm => vm.Cell5TextBox, v => v.Cell5TextBox.Text)
                    .DisposeWith(disposable);

                this.OneWayBind(this.ViewModel, vm => vm.Cell5TextBlock, x => x.Cell5TextBlock.Text)
                    .DisposeWith(disposable);
            });


            // Enter キーでフォーカス移動する
            this.KeyDown += (sender, e) =>
            {
                if (e.Key != Key.Enter)
                {
                    return; 
                }
                var direction = Keyboard.Modifiers == ModifierKeys.Shift ? FocusNavigationDirection.Up : FocusNavigationDirection.Down;
                (FocusManager.GetFocusedElement(this) as FrameworkElement)?.MoveFocus(new TraversalRequest(direction));
            };

        }
    }
}
