using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_semester1_c
{
    interface IDateAndCopy
    {
        DateTime Date { get; } // поле для чтения 
        object DeepCopy();
    }


    class MagazineEnumerator : IEnumerator<Book>
    {
        private Publisher publisher;
        private int index;

        public MagazineEnumerator(Publisher publish)
        {
            publisher = publish;
            index = -1;
        }

        //Возвращает элемент коллекции, соответствующий текущей позиции перечислителя.
        public Book Current
        {
            get
            {
                return publisher.Books[index];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        //Устанавливает перечислитель в его начальное положение, т. е.перед первым элементом коллекции.(Наследуется от IEnumerator.)
        public void Reset()
        {
            index = -1;
        }

        //Выполняет определяемые приложением задачи, связанные с удалением, высвобождением или сбросом неуправляемых ресурсов.(Наследуется от IDisposable.)
        public void Dispose() { }

        //Перемещает перечислитель к следующему элементу коллекции.(Наследуется от IEnumerator.)
        public bool MoveNext()
        {
            ++index;
            while (index < publisher.Books.Count)
            {

                //Если автор книги есть в сотрудниках
                if (publisher.Staff.Contains(publisher.Books[index].Author))
                {
                    ++index;
                }
                else
                {

                    return true;

                }
            }
            return false;

        }
    }
    class Publisher : Organization, IDateAndCopy, IEnumerable
    {
        private DateTime licensedate;
        private List<Book> books; //список книг ()
        private List<Person> staff; // список сотрудников 
        public DateTime Date { get { return licensedate; } }

        public DateTime Licensedate { get { return licensedate; } set { licensedate = value; } }
        public List<Book> Books { get { return books; } set { books = value; } }
        public List<Person> Staff { get { return staff; } set { staff = value; } }

        // для интерфейса, который перебирает статьи, авторы которых не яв сотрудниками фирмы 
        public IEnumerator<Book> GetEnumerator() { return new MagazineEnumerator(this); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        public Organization Org
        {
            get
            {
                return new Organization(NameOrg, AdressOrg, YearRegOrg);
            }
            set
            {
                NameOrg = value.NameOrg;
                AdressOrg = value.AdressOrg;
                YearRegOrg = value.YearRegOrg;
            }
        }
        public double PocketBook
        {
            get
            {
                int count = 0; //кол книг в формате Pocket
                foreach (Book b in Books)
                {
                    if (b.Size == Size.Pocket) count += 1;
                }

                return (count / Books.Count) * 100;
            }
        }
        public Publisher(string publishinghouse, string adress, int registrationyear, DateTime licensedate)

        {
            this.NameOrg = publishinghouse;
            this.AdressOrg = adress;
            this.YearRegOrg = registrationyear;
            this.Licensedate = licensedate;
            Books = new List<Book>();
            Staff = new List<Person>();
        }
        public Publisher()
        {
            NameOrg = "АБАБАГАЛАМАГА";
            AdressOrg = "Adress";
            YearRegOrg = 1764;
            Licensedate = new DateTime(1864, 3, 6);
            Books = new List<Book>();
            Staff = new List<Person>();
        }

        public Book LastBook
        {
            get
            {
                if (Books == null)
                { return null; }
                int index = 0;
                DateTime max = new DateTime();
                for (int i = 0; i < Books.Count; i++)
                {
                    if (Books[i].Date > max)
                    {
                        max = Books[i].Date;
                        index = i;
                    }
                }
                return Books[index];
            }
        }

        public void AddBooks(params Book[] NewBooks)
        {
            books.AddRange(NewBooks); // Метод добавляет в конец списка книги NewBooks
        }
        public void AddEmployee(params Person[] NewEmployee)
        {
            staff.AddRange(NewEmployee);// Метод добавляет в конец списка книги NewEmployee
        }

        // Ищет книгу с годом издания дольше заданного года 
        public IEnumerable<Book> BookYear(int year)
        {
            foreach (Book b in Books)
            {
                if (b.Date.Year > year) yield return b;
            }
        }

        // Ищет книги указанного автора 
        public IEnumerable<Book> Author(string author)
        {
            string[] split = author.Split(new char[] { ' ', ',' });
            foreach (Book b in Books)
            {
                if (b.Author.Name == split[0] && b.Author.Surname == split[1]) yield return b;
            }
        }

        // * Выбрать книги авторы которых яв сотрудниками издательства 
        public IEnumerable<Book> Staff_Author()
        {
            foreach (Person p in Staff)
            {
                foreach (Book b in Books)
                {
                    if (p.Equals(b.Author)) yield return b;
                }
            }
        }
        public override object DeepCopy()
        {
            Publisher PublisherCopy;
            PublisherCopy = new Publisher(NameOrg, AdressOrg, YearRegOrg, Licensedate);
            foreach (Book b in Books) PublisherCopy.Books.Add((Book)b.DeepCopy());
            foreach (Person p in Staff) PublisherCopy.Staff.Add((Person)p.DeepCopy());
            return PublisherCopy;
        }


        public override string ToString()
        {
            string stroca = "Название издательства: " + NameOrg + "\n" + "Адресс: " + AdressOrg + "\n" + "Год регистрации: " + YearRegOrg + "\n" + "Дата окончания лицензии: " + Licensedate.ToShortDateString() + "\n";

            stroca = stroca + "Книги" + "\n";
            for (int i = 0; i < books.Count; i++)
            {
                stroca = stroca + "Книга: " + books[i] + "\n";
            }
            stroca = stroca + "Сотрудники" + "\n";
            foreach (Person p in Staff)
            {
                stroca = stroca + "Сотрудники: " + p + "\n";
            }
            return stroca + "\n";
        }
        public virtual string ToShortString()
        {
            return "Название издательства: " + NameOrg + "\n" + "Адресс: " + AdressOrg + "\n" + "Год регистрации: " + YearRegOrg + "\n" + "Дата окончания лицензии: " + Licensedate.ToShortDateString() + "\n" + "Количество книг: " + Books.Count + "\n";
        }

    }
}
