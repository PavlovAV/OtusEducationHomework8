using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusEducationHomework8
{
    static class ParallelLINQAggregation
    {
        public static long GetSum(int[] array)
        {
            return array.AsParallel().Sum(x => (long)x); ;
        }
    }
}
