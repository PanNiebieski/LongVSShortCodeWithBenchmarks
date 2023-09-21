public class Device
{
    public string Name { get; set; }

    public string Description { get; set; }

    public Device()
    {
        Name = Tools.RandomString(5);
        Description = Tools.RandomString(15);
    }
}