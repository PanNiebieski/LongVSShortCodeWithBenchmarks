using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace BenchmarkShortVSLong;

internal class Program
{
    static void Main(string[] args)
    {
        var results = BenchmarkRunner.Run<Demo>();
    }


}

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net70)]
public class Demo
{
    private readonly bool[] _array = { true, false, true, true };

    [Benchmark]
    public int CustomLoop()
    {
        int count = 0;

        foreach (bool item in _array)
        {
            if (item)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int CountWithLinq()
    {
        return _array.Count(item => item);
    }
}
