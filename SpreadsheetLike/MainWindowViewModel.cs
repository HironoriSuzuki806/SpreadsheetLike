using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpreadsheetLike
{
    public class MainWindowViewModel : ReactiveObject
    {
        private int? cell1TextBox;
        public int? Cell1TextBox
        {
            get => cell1TextBox;
            set => this.RaiseAndSetIfChanged(ref cell1TextBox, value);
        }

        public MainWindowViewModel()
        {

        }
    }
}
