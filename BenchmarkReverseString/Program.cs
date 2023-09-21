using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace ReverseStringBenchmark;

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
    private readonly string _input = "fjdscfgsdzhvcjhsvdjQAshAHdsvsajgcjsdhcjbjncgjuGSdha";

    [Benchmark]
    public string ReverseStringLong()
    {
        char[] charrArray = _input.ToCharArray();
        Array.Reverse(charrArray);
        return new string(charrArray);
    }

    [Benchmark]
    public string ReverseStringShort()
    {
        return new string(_input.Reverse().ToArray());
    }
}
