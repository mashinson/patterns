using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_semester1_c
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добавить в коллекцию PublisherCollection элементы");
            PublisherCollection PubCol = new PublisherCollection();
            Publisher[] pub = new Publisher[] { new Publisher("House1", "Adress_1", 1678, new DateTime(1756, 5, 7)), new Publisher("House2", "Adress_2", 2015, new DateTime(2016, 4, 3)) };
            Person Avtor1 = new Person("Ray", "Bradbury", new DateTime(1920, 8, 22));
            Person Avtor2 = new Person("William", "Shakespeare", new DateTime(1564, 4, 26));

            pub[0].AddEmployee(new Person("Данил", "Воронин", new DateTime(1994, 11, 12)),  new Person ("Ray", "Bradbury", new DateTime(1920, 8, 22)));
            pub[0].AddBooks(new Book(Avtor1, "Dandelion Wine", Size.Pocket, new DateTime(1957, 2, 5)));

            pub[1].AddEmployee(new Person("Даша", "Таскаева", new DateTime(1998, 9, 5)));
            pub[1].AddBooks(new Book(Avtor2, "Romeo and Juliet", Size.Standard, new DateTime(1596, 6, 19)));

            PubCol.AddPublisher(pub);
            Console.WriteLine(PubCol);
            Console.WriteLine();

            Console.WriteLine("Сортировка по названию организации");
            Console.WriteLine(PubCol.SortNamePublisher);
            Console.WriteLine();

            Console.WriteLine("Сортировка по году регестрации");
            Console.WriteLine(PubCol.SortYearPublisher);
            Console.WriteLine();

            Console.WriteLine("Сортировка по адресу организации");
            Console.WriteLine(PubCol.SortAdressPublisher);
            Console.WriteLine();


            TestCollections TestCol = new TestCollections(1000);
            Publisher first = TestCollections.RandPublisher(0);
            Publisher mid = TestCollections.RandPublisher(499);
            Publisher last = TestCollections.RandPublisher(999);
            Publisher notInCol = TestCollections.RandPublisher(1001);

            Console.WriteLine("Время нахождения первого элемента коллекции");
            Console.WriteLine("List<Organization> - {0};", TestCol.timeSearchListOrg(first));
            Console.WriteLine("List<string> - {0};", TestCol.timeSearchListStr(first.ToString()));
            Console.WriteLine("Dictionary<Organization, Publisher>  - {0};", TestCol.timeSearchElementOrgPub(first));
            Console.WriteLine("Dictionary<string, Publisher> - {0};", TestCol.timeSearchElementStrPub(first.ToString()));
            Console.WriteLine();

            Console.WriteLine("Время нахождения среднего элемента коллекции");
            Console.WriteLine("List<Organization> - {0};", TestCol.timeSearchListOrg(mid));
            Console.WriteLine("List<string> - {0};", TestCol.timeSearchListStr(mid.ToString()));
            Console.WriteLine("Dictionary<Organization, Publisher>  - {0};", TestCol.timeSearchElementOrgPub(mid));
            Console.WriteLine("Dictionary<string, Publisher> - {0};", TestCol.timeSearchElementStrPub(mid.ToString()));
            Console.WriteLine();

            Console.WriteLine("Время нахождения последнего элемента коллекции");
            Console.WriteLine("List<Organization> - {0};", TestCol.timeSearchListOrg(last));
            Console.WriteLine("List<string> - {0};", TestCol.timeSearchListStr(last.ToString()));
            Console.WriteLine("Dictionary<Organization, Publisher>  - {0};", TestCol.timeSearchElementOrgPub(last));
            Console.WriteLine("Dictionary<string, Publisher> - {0};", TestCol.timeSearchElementStrPub(last.ToString()));
            Console.WriteLine();

            Console.WriteLine("Время нахождения того, что такого элемента в коллекции нет ");
            Console.WriteLine("List<Organization> - {0};", TestCol.timeSearchListOrg(notInCol));
            Console.WriteLine("List<string> - {0};", TestCol.timeSearchListStr(notInCol.ToString()));
            Console.WriteLine("Dictionary<Organization, Publisher>  - {0};", TestCol.timeSearchElementOrgPub(notInCol));
            Console.WriteLine("Dictionary<string, Publisher> - {0};", TestCol.timeSearchElementStrPub(notInCol.ToString()));
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
