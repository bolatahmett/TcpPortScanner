using Dasync.Collections;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace PortScanTool.Model
{
    internal static class ParalelScan
    {
        internal static Task ParallelForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> funcBody, Guid taskGuid, int maxDop, CancellationToken cancellationToken)
        {
            async Task AwaitPartition(IEnumerator<T> partition)
            {
                using (partition)
                {
                    while (partition.MoveNext() && Scan.guid == taskGuid)
                    {
                        await Task.Yield();
                        await funcBody(partition.Current);
                    }
                }
            }

            return Task.WhenAll(
                Partitioner
                    .Create(source)
                    .GetPartitions(maxDop)
                    .AsParallel()
                    .Select(p => AwaitPartition(p)).WithDegreeOfParallelism(maxDop).WithCancellation(cancellationToken));
        }
    }
}
