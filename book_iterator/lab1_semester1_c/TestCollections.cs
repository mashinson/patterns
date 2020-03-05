using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_semester1_c
{
    class TestCollections
    {
        private System.Collections.Generic.List<Organization> Org;
        private System.Collections.Generic.List<string> str;
        private System.Collections.Generic.Dictionary<Organization, Publisher> searchOrg;
        private System.Collections.Generic.Dictionary<string, Publisher> searchStr;

        // метод который заполняет объект типо Publisher разными значениями в зависимости от параметра n
        public static Publisher RandPublisher(int n)
        {
            n = Math.Abs(n);
            Publisher pub1 = new Publisher();
            pub1.NameOrg = "RandomName" + n.ToString();
            pub1.AdressOrg = "RandomAdress" + n.ToString();
            pub1.YearRegOrg = n;

            pub1.Licensedate = new DateTime(n);
            Person Avtor1 = new Person("AutorName" + n.ToString(), "AutorLastName" + n.ToString(), new DateTime(n));
            pub1.AddEmployee(new Person("PersonName" + n.ToString(), "PersonLastName" + n.ToString(), new DateTime(n)));
            pub1.AddBooks(new Book(Avtor1, "Book" + n.ToString(), Size.Pocket, new DateTime(n)));

            return pub1;
        }

        //создание коллекций с заданым числом элементов
        public TestCollections(int n)
        {
            Org = new List<Organization>(n);
            str = new List<string>(n);
            searchOrg = new Dictionary<Organization, Publisher>(n);
            searchStr = new Dictionary<string, Publisher>(n);

            for (int i = 0; i < n; i++)
            {
                Publisher rand = RandPublisher(i);
                Org.Add(rand.Org);
                str.Add(rand.ToString());
                searchOrg.Add(rand.Org, rand);
                searchStr.Add(rand.ToString(), rand);
            }
        }

        // Время поиска элемента в списке List<Organization>
        public double timeSearchListOrg(Organization or)
        {
            
            double start = DateTime.Now.Ticks;
            int i = Org.IndexOf(or);
            return (DateTime.Now.Ticks - start)*1000;
        }

        // Время поиска элемента в списке List<string>
        public double timeSearchListStr(String s)
        {
            double start = DateTime.Now.Ticks;
            str.IndexOf(s);
            return (DateTime.Now.Ticks - start)*1000;
        }

        // Время поиска элемента по ключу в коллекции-словаре Dictionary<Organization, Publisher>
        public double timeSearchElementOrgPub(Organization OrgK)
        {
            Publisher publish;
            double start = DateTime.Now.Ticks;
            searchOrg.TryGetValue(OrgK, out publish);
            return (DateTime.Now.Ticks - start) * 1000;
        }

        //  Время поиска элемента по значению в коллекции-словаре Dictionary<string, Publisher> 
        public double timeSearchElementStrPub(String strK)
        {
            Publisher publish;
            double start = DateTime.Now.Ticks;
            searchStr.TryGetValue(strK, out publish);
            return (DateTime.Now.Ticks - start )*1000;
        }

    }
}
