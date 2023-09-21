using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System.Text;

namespace ConsoleHouseBenchmark;

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

    private List<House> _houses = new List<House>();

    [GlobalSetup]
    public void Setup()
    {
        _houses = new List<House>()
        {
            new House()
            {
                Animals = new List<Animal>() { new Animal(), new Animal()  } ,
                People = new List<Person>() {new Person(), new Person()},
                Devices = new List<Device>() {new Device()} } ,
            new House()
            {
                Animals = new List<Animal>() { new Animal(), new Animal()  } ,
                People = new List<Person>() {new Person(), new Person()},
                Devices = new List<Device>() {new Device(), new Device() } } ,
            new House()
            {
                Animals = new List<Animal>() { null, new Animal()  } ,
                People = new List<Person>() {new Person(), null},
                Devices = new List<Device>() { null }
            }
        };
    }

    [Benchmark]
    public List<string> TransformLINQ()
    {
        return _houses.Where(h => h.Id != 0).Select(house =>
        {
            return
          string.Join(", ",
            house.People.Where(a => a != null).Select(a => a.Name)) + "," +
          string.Join(", ",
            house.Animals.Where(a => a != null).Select(a => a.Name)) +
          string.Join(",", house.
            Devices.Where(a => a != null).Select(a =>
            { return a.Name + " - " + a.Description; })
            );
        })
        .ToList();
    }

    [Benchmark]
    public List<string> TransformMyForeach()
    {
        List<string> list = new List<string>
            (_houses.Count());

        foreach (var item in _houses)
        {
            if (item.Id == 0)
                continue;

            StringBuilder sb = new StringBuilder();

            foreach (var person in item.People)
            {
                if (person != null)
                {
                    sb.Append(person.Name);
                    sb.Append(',');
                }
            }

            foreach (var animal in item.Animals)
            {
                if (animal != null)
                {
                    sb.Append(animal.Name);
                    sb.Append(',');
                }
            }

            foreach (var device in item.Devices)
            {
                if (device != null)
                {
                    sb.Append(device.Name);
                    sb.Append(" - ");
                    sb.Append(device.Description);
                    sb.Append(',');
                }
            }

            sb.Remove(sb.Length - 1, 1);

            list.Add(sb.ToString());
        }

        return list;
    }

}
