using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_semester1_c
{
    class PublisherCollection
    {
        private System.Collections.Generic.List<Publisher> publish = new List<Publisher>();

        // сортирует publish используя интерфейс IComparable реализованного в классе Organization
        public PublisherCollection SortNamePublisher
        {
          get
            {
               publish.Sort();
               return this;
            }
        }

        // у нас объявленно два интерфейса IComparer, поэтому нужно указать из какого класса вызывать
        public PublisherCollection SortYearPublisher
        {
            get
            {
                Organization org = new Organization();
                publish.Sort(org);
                return this;
            }
        }
        // у нас объявленно два интерфейса IComparer, поэтому нужно указать из какого класса вызывать
        public PublisherCollection SortAdressPublisher
        {
            get
            {
                ComparerAdress ad = new ComparerAdress();
                publish.Sort(ad);
                return this;
            }
        }

        // Метод добавляет в конец списка два заданных обьекта издательства publisher
        public void AddDefaults()
        {
            Publisher pub1 = new Publisher();
            pub1.NameOrg = "Name1";
            pub1.AdressOrg = "Adress1";
            pub1.YearRegOrg = 1890;
            pub1.Licensedate = new DateTime(1892, 4, 7);
            Person Avtor1 = new Person("Ray", "Bradbury", new DateTime(1920, 8, 22));
            pub1.AddEmployee(new Person("Данил", "Воронин", new DateTime(1994, 11, 12)), new Person("Ray", "Bradbury", new DateTime(1920, 8, 22)));
            pub1.AddBooks(new Book(Avtor1, "Dandelion Wine", Size.Pocket, new DateTime(1957, 2, 5)));

            Publisher pub2 = new Publisher();
            pub2.NameOrg = "Name2";
            pub2.AdressOrg = "Adress2";
            pub2.YearRegOrg = 2015;
            pub2.Licensedate = new DateTime(2000, 7, 18);
            pub2.AddEmployee(new Person("Даша", "Таскаева", new DateTime(1998, 9, 5)));
            Person Avtor2 = new Person("William", "Shakespeare", new DateTime(1564, 4, 26));
            pub2.AddBooks(new Book(Avtor2, "Romeo and Juliet", Size.Standard, new DateTime(1596, 6, 19)));

            publish.Add(pub1);
            publish.Add(pub2);
        }

        // Метод добавляет в конец списка publish издательства publisher
        public void AddPublisher(params Publisher[] publisher)
        {
            this.publish.AddRange(publisher);
        }

        // Выводятся все элементы со всеми полями publish
        public override string ToString()
        {
            string s = "";
            foreach (Publisher p in publish)
            {
                s = s + p.ToString();
            }
            return s;
        }

        // Выводятся все элементы со всеми полями кроме списка книг и сотрудников publish
        public virtual string ToShortString()
        {
            string str = "";
            foreach (Publisher p in publish)
            {
                str = str + p.ToShortString();
            }
            return str;
        }


    }

}

