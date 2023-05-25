// See https://aka.ms/new-console-template for more information
using OtusEducationHomework8;
using System.Diagnostics;


int count = 10000000;
Random rnd = new Random(); 
var intArray = new int[count];
for (int i = 0; i < count; i++)
{
    intArray[i] = rnd.Next(1,1000);
}

long total = 0;
var sw = new Stopwatch();

sw.Start();
total = StandardAggregation.GetSum(intArray);
sw.Stop();
Console.WriteLine($"Standart aggregation {total}");
Console.WriteLine($"{sw.ElapsedMilliseconds / 1000.0}");

sw.Restart();
total = ParallelThreadAggregation.GetSum(intArray);
sw.Stop();
Console.WriteLine($"Parallel Thread aggregation {total}");
Console.WriteLine($"{sw.ElapsedMilliseconds / 1000.0}");

sw.Restart();
total = ParallelLINQAggregation.GetSum(intArray);
sw.Stop();
Console.WriteLine($"Parallel LINQ aggregation {total}");
Console.WriteLine($"{sw.ElapsedMilliseconds / 1000.0}");
