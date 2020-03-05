using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_semester1_c
{
  
    enum Size
    {
        Pocket, Standard, Big
    }

    class Book: IDateAndCopy
    {
        public Person Author { get; set; }
        public string Title { get; set; }
        public Size Size { get; set; }
        public DateTime Date { get { return date; } }

        private DateTime date;
        public Book(Person author, string title, Size size, DateTime date)
        {
            this.Author = author;
            this.Title = title;
            this.Size = size;
            this.date = date;
        }
        public Book()
        {
            this.Author = new Person ("Adam", "Sandler", new DateTime(1000,1,1));
            this.Title = "Book1";
            this.Size = Size.Pocket;
            this.date = new DateTime(1025, 2, 4);
        }
        public override string  ToString()
        {
            return "Автор: " + Author + "\n" + "Название книги: " + Title + "\n" + "Формат книги: " + Size + "\n" + "Дата издания: " + Date.ToShortDateString() + "\n"; 
        }


        public virtual object DeepCopy()
        {
            return new Book(Author, Title, Size, date);
        }

    }
}
