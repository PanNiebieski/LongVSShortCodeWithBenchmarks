public class Animal
{
    public string Name { get; set; }

    public Animal()
    {
        Name = Tools.RandomString(5);
    }
}
