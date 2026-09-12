using System;
using System.Collections.Generic;
using System.IO;
public static class RegistryMethods //все методы для работы, статик = объект создавать не нужно
{
    public static List<Good> InitGoods()
    {
        List<Good> goods = new List<Good>();
        for (int i = 1; i <= 20; i++)
        {
            Good good = new Good(i, $"Товар {i}", $"G{i:000}");
            goods.Add(good);
        }
        return goods;
    }
    public static void WriteGoods(List<Good> goods) //запись списка товаров
    {
        List<string> lines = new List<string>();
        foreach (Good good in goods)
            lines.Add(good.ToString()); //товар в строку
        File.WriteAllLines("goods.txt", lines);
    }
    public static List<Good> ReadGoods() //читает товары, возвращает список
    {
        List<Good> goods = new List<Good>();
        if (!File.Exists("goods.txt"))
            return goods;
        string[] lines = File.ReadAllLines("goods.txt");
        foreach (string line in lines)
        {
            string[] data = line.Split(';');
            Good good = new Good(int.Parse(data[0]), data[1], data[2]); //ид, нзв, код
            goods.Add(good);
        }
        return goods;
    }
    public static void PrintGoods(List<Good> goods) //вывод
    {
        Console.WriteLine("\nТовары");
        foreach (Good good in goods)
        {
            Console.WriteLine($"Id: {good.Id}, " + $"Название: {good.Name}, " + $"Код: {good.Code}");
        }
    }
    public static List<Client> InitClients() //список клиентов
    {
        List<Client> clients = new List<Client>();
        clients.Add(new Client(1,"Иван","Иванов","Иванович",new DateTime(2000, 2, 1)));
        clients.Add(new Client(2, "Петр", "Петров", "Петрович", new DateTime(1995, 5, 10)));
        clients.Add(new Client(3, "Анна", "Сидорова", "Ивановна", new DateTime(2005, 10, 20)));
        clients.Add(new Client(4, "Мария", "Смирнова", "Алексеевна", new DateTime(1998, 3, 15)));
        clients.Add(new Client(5, "Алексей", "Кузнецов", "Сергеевич", new DateTime(2002, 7, 25)));
        return clients;
    }
    public static void WriteClients(List<Client> clients) //запись клиентов
    {
        List<string> lines = new List<string>();
        foreach (Client client in clients)
            lines.Add(client.ToString());
        File.WriteAllLines("clients.txt", lines);
    }
    public static List<Client> ReadClients() //чтение клиентов
    {
        List<Client> clients = new List<Client>();
        if (!File.Exists("clients.txt"))
            return clients;
        string[] lines = File.ReadAllLines("clients.txt");
        foreach (string line in lines)
        {
            string[] data = line.Split(';');
            Client client = new Client(int.Parse(data[0]), data[1], data[2], data[3], DateTime.Parse(data[4]));
            clients.Add(client);
        }
        return clients;
    }
    public static void PrintClients(List<Client> clients) //вывод клиентов
    {
        Console.WriteLine("\nКлиенты");
        foreach (Client client in clients)
            Console.WriteLine($"Id: {client.Id}, " + $"ФИО: {client.Lname} {client.Fname} {client.Mname}, " + $"Дата рождения: {client.Birth:dd.MM.yyyy}, " + $"Возраст: {client.Age}");
    }
    public static List<Shop> InitShops() //создание
    {
        List<Shop> shops = new List<Shop>();
        shops.Add(new Shop(1, "Магазин №1", "S001"));
        shops.Add(new Shop(2, "Магазин №2", "S002"));
        shops.Add(new Shop(3, "Магазин №3", "S003"));
        return shops;
    }
    public static void WriteShops(List<Shop> shops) //запись
    {
        List<string> lines = new List<string>();
        foreach (Shop shop in shops)
            lines.Add(shop.ToString());
        File.WriteAllLines("shops.txt", lines);
    }
    public static List<Shop> ReadShops() //чтение
    {
        List<Shop> shops = new List<Shop>();
        if (!File.Exists("shops.txt"))
            return shops;
        string[] lines = File.ReadAllLines("shops.txt");
        foreach (string line in lines)
        {
            string[] data = line.Split(';');
            Shop shop = new Shop(int.Parse(data[0]), data[1], data[2]);
            shops.Add(shop);
        }
        return shops;
    }
    public static void PrintShops(List<Shop> shops) //вывод
    {
        Console.WriteLine("\nМагазины");
        foreach (Shop shop in shops)
            Console.WriteLine($"Id: {shop.Id}, " + $"Название: {shop.Name}, " + $"Код: {shop.Code}");
    }
}