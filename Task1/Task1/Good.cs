public class Good : IPrimary //описание товара
{
    public int Id { get; }
    public string Name { get; set; }
    public string Code { get; set; }
    public Good(int id, string name, string code)
    {
        Id = id;
        Name = name;
        Code = code;
    }
    public override string ToString() //объект в текст
    {
        return $"{Id};{Name};{Code}";
    }
}