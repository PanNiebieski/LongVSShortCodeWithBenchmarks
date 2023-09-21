using System.Text;

var houses = new List<House>()
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



var list1 = Transform1(houses);
var list2 = Transform2(houses);



foreach (var item in list1)
{
    Console.WriteLine(item);
}

Console.WriteLine("\nTransform2\n");

foreach (var item in list2)
{
    Console.WriteLine(item);
}


List<string> Transform1(IEnumerable<House> houses)
{
    return houses.Where(h => h.Id != 0).Select(house =>
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

List<string> Transform2(IEnumerable<House> houses)
{
    List<string> list = new List<string>
        (houses.Count());

    foreach (var item in houses)
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
