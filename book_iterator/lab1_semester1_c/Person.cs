using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_semester1_c
{
    class Person
    {
        private string name;
        private string surname;
        private System.DateTime birthday;

        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public System.DateTime Birthday { get { return birthday; } set { birthday = value; } }
        public int Year { get { return birthday.Year; } set { birthday = new DateTime(value, birthday.Month, birthday.Day); } }

        //Конструктор с параметрами
        public Person(string Name, string Surname, System.DateTime Birthday)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Birthday = Birthday;
        }

        //Конструктор без параметров
        public Person()
        {
            this.Name = "Vasya";
            this.Surname = "Vasilyev";
            this.Birthday = DateTime.Now;
            this.Year = 2000;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}\nDate of birth: {2}", Name, Surname, Birthday.ToShortDateString()); ;
        }

        public virtual string ToShortString()
        {
            return "Имя: " + Name + "\n" + "Фамилия: " + Surname;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (Object.ReferenceEquals(obj, this)) return true; //если они совпадают по ссылкам они точно равны

            Person p = obj as Person;
            if ((Object)p == null) return false; // если объект нельзя представить как Person

            return (Name == p.Name) && (Surname == p.Surname) && (Birthday == p.Birthday); //если выполнятся 3 условия вернется true
        }

        // Операции == и != переопределяются так как Equals
        public static bool operator ==(Person a, Person b)
        {
            if (((object)a == null) && ((object)b == null)) return false;

            if (Object.ReferenceEquals(a, b)) return true;

            return a.Name == b.Name && a.Surname == b.Surname && a.Birthday == b.Birthday;
        }
        public static bool operator !=(Person a, Person b)
        {
            return !(a == b);
        }

        // чтобы уменьшить количество повторяющихся хэш-кодов 
        public override int GetHashCode()
        {
            return (Name.GetHashCode() * 41 + Surname.GetHashCode() * 37 + Birthday.GetHashCode() * 31);
        }

        public object DeepCopy()
        {
            return new Person(Name, Surname, new DateTime(Birthday.Year, Birthday.Month, Birthday.Day));
        }
    }
}
