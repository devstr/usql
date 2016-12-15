using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Analytics.Interfaces;

namespace USQLCSharpDemo
{
    public class DateRangeReducer : IReducer
    {

        private const string Start = "start";
        private const string End = "end";
        public override IEnumerable<IRow> Reduce(IRowset input, IUpdatableRow output)
        {
            var i = 0;
            var start = DateTime.MinValue;
            var end = DateTime.MaxValue;
            foreach (var row in input.Rows)
            {
                if (i == 0)
                {
                    start = row.Get<DateTime>(Start);
                    end = row.Get<DateTime>(End);
                }
                else
                {
                    var nextStart = row.Get<DateTime>(Start);
                    var nextEnd = row.Get<DateTime>(End);
                    if (nextStart <= end)
                    {
                        if (nextEnd > end)
                        {
                            end = nextEnd;
                        }
                    }
                    else
                    {
                        output.Set<DateTime>(Start, start);
                        output.Set<DateTime>(End, end);
                        yield return output.AsReadOnly();
                        start = nextStart; end = nextEnd;
                    }
                }
                i++;
            }
            output.Set<DateTime>(Start, start);
            output.Set<DateTime>(End, end);
            yield return output.AsReadOnly();
        }
    }
}
