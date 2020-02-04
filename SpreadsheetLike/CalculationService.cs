using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace SpreadsheetLike
{
    public class CalculationService : ICalculationService
    {
        public int Row { get; }

        public ReplaySubject<int> InputCell { get; }

        public IObservable<int> ResultValue { get; }

        public CalculationService(int row)
        {
            Row = row;

            ResultValue = InputCell.CombineLatest(
                GetPreviousResultValue(),
                (i, r) => i + r
                )
                .Publish().RefCount();

        }

        private IObservable<int> GetPreviousResultValue()
        {
            if (Row == 1)
            {
                return Observable.Return(0);
            }
            else
            {
                return Locator.Current.GetServices<ICalculationService>()
                        .Single(s => s.Row == this.Row - 1)
                        .ResultValue;
            };
        }
    }
}
