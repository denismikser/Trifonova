using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Good> goods = RegistryMethods.InitGoods(); //создание товаров
        RegistryMethods.WriteGoods(goods); //запись
        goods = RegistryMethods.ReadGoods(); //чтение
        RegistryMethods.PrintGoods(goods); //вывод

        List<Client> clients = RegistryMethods.InitClients(); //клиенты
        RegistryMethods.WriteClients(clients);
        clients = RegistryMethods.ReadClients();
        RegistryMethods.PrintClients(clients);

        List<Shop> shops = RegistryMethods.InitShops(); //магазины
        RegistryMethods.WriteShops(shops);
        shops = RegistryMethods.ReadShops();
        RegistryMethods.PrintShops(shops);

        for (int i = 21; i <= 30; i++) //добавляем 10 товаров
            goods.Add(new Good(i, $"Новый товар {i}", $"G{i:000}"));
        RegistryMethods.WriteGoods(goods);

        clients.Add(new Client(6, "Сергей", "Орлов", "Андреевич", new DateTime(1990, 1, 10))); //добавляем клиентов
        clients.Add(new Client(7, "Елена", "Волкова", "Сергеевна", new DateTime(2001, 6, 15)));
        clients.Add(new Client(8, "Дмитрий", "Морозов", "Иванович", new DateTime(1997, 12, 5)));
        RegistryMethods.WriteClients(clients);

        shops.Add(new Shop(4, "Магазин №4", "S004")); //добавляем магазины
        shops.Add(new Shop(5, "Магазин №5", "S005"));
        RegistryMethods.WriteShops(shops);

        Console.WriteLine("Итог");
        Console.WriteLine();
        RegistryMethods.PrintGoods(goods);
        RegistryMethods.PrintClients(clients);
        RegistryMethods.PrintShops(shops);
    }
}