using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text;

namespace SpreadsheetLike
{
    public interface ICalculationService
    {
        int Row { get; }

        ReplaySubject<int> InputCell { get; }

        IObservable<int> ResultValue { get; }

    }
}
