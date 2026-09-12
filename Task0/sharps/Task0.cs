using System;
using System.IO;
using System.Text;
using System.Diagnostics; //время

namespace Task0
{
    public class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public Person(string name, string city, int age, int height, int weight)
        {
            Name = name;
            City = city;
            Age = age;
            Height = height;
            Weight = weight;
        }
    }
    class Program
    {
        static Person Generate(Random random) //статик для присваивания классу програм
        {
            string[] names = { "Аристарх", "Мелисса", "Фёдор", "Гликерия", "Ратибор", "Инесса", "Лукьян", "Феоктиста", "Варлаам", "Афина", "Панкрат", "Руфина", "Еремей", "Цецилия", "Мирон" };
            string[] cities = { "Тула", "Владивосток", "Суздаль", "Норильск", "Псков", "Магадан", "Великий Новгород", "Орёл", "Мурманск", "Вологда", "Рязань", "Тобольск", "Смоленск", "Калининград", "Хабаровск" };
            string name = names[random.Next(names.Length)];
            string city = cities[random.Next(cities.Length)];
            int age = random.Next(18, 67);
            int height = random.Next(160, 200);
            int weight = random.Next(50, 100);
            return new Person(name, city, age, height, weight);
        }
        static void WriteText(int count, string fileName)
        {
            Random random = new Random(42341); //одинаковые случайные числа для бин и тхт
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                for (int i = 0; i < count; i++)
                {
                    Person person = Generate(random);
                    writer.WriteLine($"{person.Name},{person.City},{person.Age}," + $"{person.Height},{person.Weight}");
                }
            }
        }
        static void ReadText(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null) //построчно
                {
                    string[] data = line.Split(',');
                    Person person = new Person(data[0].Trim(), data[1].Trim(), int.Parse(data[2].Trim()), int.Parse(data[3].Trim()), int.Parse(data[4].Trim()));
                }
            }
        }
        static void WriteBinary(int count, string fileName)
        {
            Random random = new Random(42341);
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fileStream, Encoding.UTF8))
            {
                writer.Write(count); //для знания, сколько объектов нужно прочитать
                for (int i = 0; i < count; i++)
                {
                    Person person = Generate(random);
                    writer.Write(person.Name);
                    writer.Write(person.City);
                    writer.Write(person.Age);
                    writer.Write(person.Height);
                    writer.Write(person.Weight);
                }
            }
        }
        static void ReadBinary(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fileStream, Encoding.UTF8))
            {
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    string name = reader.ReadString();
                    string city = reader.ReadString();
                    int age = reader.ReadInt32();
                    int height = reader.ReadInt32();
                    int weight = reader.ReadInt32();
                    Person person = new Person(name, city, age, height, weight);
                }
            }
        }
        static void Main()
        {
            string textFile = "persons.txt";
            string binaryFile = "persons.bin";
            int[] counts = { 10, 1000, 100000, 1000000, 10000000, 100000000 };
            Console.WriteLine("Количество".PadRight(15) + "Запись TXT".PadRight(18) + "Чтение TXT".PadRight(18) + "Запись BIN".PadRight(18) + "Чтение BIN".PadRight(18));
            Console.WriteLine();
            foreach (int count in counts)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                WriteText(count, textFile);
                sw.Stop();
                double writeTextTime = sw.Elapsed.TotalSeconds; //сохранение времени

                sw.Reset();
                sw.Start();
                ReadText(textFile);
                sw.Stop();
                double readTextTime = sw.Elapsed.TotalSeconds;

                sw.Reset();
                sw.Start();
                WriteBinary(count, binaryFile);
                sw.Stop();
                double writeBinaryTime = sw.Elapsed.TotalSeconds;

                sw.Reset();
                sw.Start();
                ReadBinary(binaryFile);
                sw.Stop();
                double readBinaryTime = sw.Elapsed.TotalSeconds;

                Console.WriteLine(count.ToString().PadRight(15) + writeTextTime.ToString().PadRight(18) + readTextTime.ToString().PadRight(18) + writeBinaryTime.ToString().PadRight(18) + readBinaryTime.ToString().PadRight(18));
                
                if (File.Exists(textFile)) //удаление созданных
                    File.Delete(textFile);
                if (File.Exists(binaryFile))
                    File.Delete(binaryFile);
                GC.Collect(); //очистка памяти
                GC.WaitForPendingFinalizers();
            }
        }
    }
}