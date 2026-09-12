using System;
public class Client : IPrimary
{
    public int Id { get; }
    public string Fname { get; set; }
    public string Lname { get; set; }
    public string Mname { get; set; }
    public DateTime Birth { get; set; }
    public int Age
    {
        get
        {
            int age = DateTime.Today.Year - Birth.Year;
            if (DateTime.Today < Birth.AddYears(age)) //был ли др
                age--;
            return age;
        }
    }
    public Client(int id, string firstName, string lastName, string middleName, DateTime birthd)
    {
        Id = id;
        Fname = firstName;
        Lname = lastName;
        Mname = middleName;
        Birth = birthd;
    }
    public override string ToString()
    {
        return $"{Id};{Fname};{Lname};{Mname};{Birth:yyyy-MM-dd}";
    }
}