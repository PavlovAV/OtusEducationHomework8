using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusEducationHomework8
{
    static class ParallelThreadAggregation
    {
        public static long GetSum(int[] array)
        {
            var listThreads = new List<Thread>();
            int lenIntArray = array.Length;
            int countThread = 3;
            int countItemInOneThread = lenIntArray / countThread;
            if (countThread * countItemInOneThread < lenIntArray)
                countThread++;
            long[] totalThread = new long[countThread];

            for (var i = 0; i < countThread; i++)
            {
                var startIndex = (int)i * (lenIntArray / countThread);
                var endIndex = ((int)i + 1) * lenIntArray / countThread;
                var thread = new Thread((i) =>
                {
                    for (int j = startIndex; j < endIndex; j++)
                    {
                        totalThread[(int)i] += array[j];
                    }
                });
                listThreads.Add(thread);
                listThreads[i].Start(i);
            }

            for (int i = 0; i < countThread; i++)
            {
                listThreads[i].Join();
            }


            return totalThread.Sum(x => (long)x);

        }
    }
}
