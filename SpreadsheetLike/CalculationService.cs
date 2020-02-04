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

        public ReplaySubject<int?> InputCell { get; } = new ReplaySubject<int?>(1);

        public IObservable<int?> ResultValue { get; }

        public CalculationService(int row)
        {
            Row = row;

            ResultValue = InputCell.CombineLatest(
                GetPreviousResultValue(),
                (i, r) => i + r
                )
                .Publish().RefCount();
        }

        private IObservable<int?> GetPreviousResultValue()
        {
            if (Row == 1)
            {
                return Observable.Return<int?>(0);
            }
            else
            {
                var services = Locator.Current.GetServices<ICalculationService>();

                return services
                        .Where(s => s.Row == (this.Row - 1))
                        .FirstOrDefault()
                        .ResultValue;
            };
        }
    }
}
