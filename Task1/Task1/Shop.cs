public class Shop : IPrimary
{
    public int Id { get; }
    public string Name { get; set; }
    public string Code { get; set; }
    public Shop(int id, string name, string code)
    {
        Id = id;
        Name = name;
        Code = code;
    }
    public override string ToString()
    {
        return $"{Id};{Name};{Code}";
    }
}