public class House
{
    public int Id { get; set; }

    public List<Person> People { get; set; }

    public List<Animal> Animals { get; set; }

    public List<Device> Devices { get; set; }

    public House()
    {
        Id = 1;
        People = new List<Person>();
        Animals = new List<Animal>();
        Devices = new List<Device>();
    }
}
