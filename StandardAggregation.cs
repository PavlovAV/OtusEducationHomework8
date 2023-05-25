using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace OtusEducationHomework8
{
    static class StandardAggregation
    {
        public static long GetSum(int[] array)
        {
            var intArray = array;
            long total = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                total += intArray[i];
            }

            return total;
        }
    }
}
