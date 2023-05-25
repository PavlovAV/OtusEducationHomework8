// See https://aka.ms/new-console-template for more information
using System.Diagnostics;


int count = 10000000;
Random rnd = new Random(); 
var intArray = new int[count];
for (int i = 0; i < count; i++)
{
    intArray[i] = rnd.Next(1,10);
}
var sw = new Stopwatch();

sw.Start();
long total = 0;
for (int i = 0; i < count; i++)
{
    total += intArray[i];
}

sw.Stop();
Console.WriteLine($"Standart aggregation {total}");
Console.WriteLine($"{sw.ElapsedMilliseconds / 1000.0}");

sw.Restart();
var listThreads = new List<Thread>();
int lenIntArray = intArray.Length;
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
                totalThread[(int)i] += intArray[j];
        }
    });
    listThreads.Add(thread);
    listThreads[i].Start(i);
}

for (int i = 0; i < countThread; i++)
{
    listThreads[i].Join();
}


total = totalThread.Sum(x => (long)x);
sw.Stop();
Console.WriteLine($"Parallel Thread aggregation {total}");
Console.WriteLine($"{sw.ElapsedMilliseconds / 1000.0}");

sw.Restart();
total = intArray.AsParallel().Sum(x => (long)x);
sw.Stop();
Console.WriteLine($"Parallel LINQ aggregation {total}");
Console.WriteLine($"{sw.ElapsedMilliseconds / 1000.0}");
