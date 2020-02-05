using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
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
                this.RaiseAndSetIfChanged(ref cell1TextBox, value);
            }
        }

        private int? cell1TextBlock;
        public int? Cell1TextBlock
        {
            get => cell1TextBlock;
            set
            {
                this.RaiseAndSetIfChanged(ref cell1TextBlock, value);
            }
        }

        public ReactiveCommand<Unit, Unit> Cell1 { get; }

        #endregion
        #region Cell2
        private int? cell2TextBox;
        public int? Cell2TextBox
        {
            get => cell2TextBox;
            set
            {
                this.RaiseAndSetIfChanged(ref cell2TextBox, value);
            }
        }

        private int? cell2TextBlock;
        public int? Cell2TextBlock
        {
            get => cell2TextBlock;
            set
            {
                this.RaiseAndSetIfChanged(ref cell2TextBlock, value);
            }
        }

        public ReactiveCommand<Unit, Unit> Cell2 { get; }

        #endregion
        #region Cell3
        private int? cell3TextBox;
        public int? Cell3TextBox
        {
            get => cell3TextBox;
            set
            {
                this.RaiseAndSetIfChanged(ref cell3TextBox, value);
            }
        }

        private int? cell3TextBlock;
        public int? Cell3TextBlock
        {
            get => cell3TextBlock;
            set
            {
                this.RaiseAndSetIfChanged(ref cell3TextBlock, value);
            }
        }

        public ReactiveCommand<Unit, Unit> Cell3 { get; }

        #endregion
        #region Cell4
        private int? cell4TextBox;
        public int? Cell4TextBox
        {
            get => cell4TextBox;
            set
            {
                this.RaiseAndSetIfChanged(ref cell4TextBox, value);
            }
        }

        private int? cell4TextBlock;
        public int? Cell4TextBlock
        {
            get => cell4TextBlock;
            set
            {
                this.RaiseAndSetIfChanged(ref cell4TextBlock, value);
            }
        }

        public ReactiveCommand<Unit, Unit> Cell4 { get; }

        #endregion
        #region Cell5
        private int? cell5TextBox;
        public int? Cell5TextBox
        {
            get => cell5TextBox;
            set
            {
                this.RaiseAndSetIfChanged(ref cell5TextBox, value);
            }
        }

        private int? cell5TextBlock;
        public int? Cell5TextBlock
        {
            get => cell5TextBlock;
            set
            {
                this.RaiseAndSetIfChanged(ref cell5TextBlock, value);
            }
        }

        public ReactiveCommand<Unit, Unit> Cell5 { get; }

        #endregion


        public MainWindowViewModel()
        {
            Cell1 = ReactiveCommand.Create(() =>
            {
                Cell1TextBlock = Cell1TextBox;

                Cell2TextBlock = Cell2TextBox + Cell1TextBlock;

                Cell3TextBlock = Cell3TextBox + Cell2TextBlock;

                Cell4TextBlock = Cell4TextBox + Cell3TextBlock;

                Cell5TextBlock = Cell5TextBox + Cell4TextBlock;
            });

            Cell2 = ReactiveCommand.Create(() =>
            {
                Cell2TextBlock = Cell2TextBox + Cell1TextBlock;

                Cell3TextBlock = Cell3TextBox + Cell2TextBlock;

                Cell4TextBlock = Cell4TextBox + Cell3TextBlock;

                Cell5TextBlock = Cell5TextBox + Cell4TextBlock;
            });

            Cell3 = ReactiveCommand.Create(() =>
            {
                Cell3TextBlock = Cell3TextBox + Cell2TextBlock;

                Cell4TextBlock = Cell4TextBox + Cell3TextBlock;

                Cell5TextBlock = Cell5TextBox + Cell4TextBlock;
            });

            Cell4 = ReactiveCommand.Create(() =>
            {
                Cell4TextBlock = Cell4TextBox + Cell3TextBlock;

                Cell5TextBlock = Cell5TextBox + Cell4TextBlock;
            });

            Cell5 = ReactiveCommand.Create(() =>
            {
                Cell5TextBlock = Cell5TextBox + Cell4TextBlock;
            });

        }
    }
}
