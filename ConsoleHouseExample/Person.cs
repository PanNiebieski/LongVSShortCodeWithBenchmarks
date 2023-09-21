public class Person
{
    public string Name { get; set; }

    public Person()
    {
        Name = Tools.RandomString(5);
    }
}
