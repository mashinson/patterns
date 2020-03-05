using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_semester1_c
{
    class ComparerAdress: System.Collections.Generic.IComparer<Organization>
    {
        public int Compare(Organization a, Organization b)
        {
            return a.AdressOrg.CompareTo(b.AdressOrg);
        }
    }
 
class Organization: System.IComparable, System.Collections.Generic.IComparer<Organization>
{
    protected string nameOrg;
    protected string adressOrg;
    protected int yearRegOrg;

    public string NameOrg { get { return nameOrg; } set { nameOrg = value; } }
    public string AdressOrg { get { return adressOrg; } set { adressOrg = value; } }
    public int YearRegOrg
    {
        get
        {
            return yearRegOrg;
        }
        set
        {
            if (value > 2016) throw new ArgumentException("Год регестарции не может быть больше текущего года!");
            yearRegOrg = value;
        }
    }


    public Organization(string NameOrg, string AdressOrg, int YearRegOrg)
    {
        this.nameOrg = NameOrg;
        this.adressOrg = AdressOrg;
        this.yearRegOrg = YearRegOrg;
    }
    public Organization()
    {
        this.nameOrg = "Organization1";
        this.adressOrg = "Adress1";
        this.yearRegOrg = 1997;
    }

        // реализация интерфейса IComparable
        public int CompareTo(object obj)
        {   
            Organization p = obj as Organization;
            return NameOrg.CompareTo(p.NameOrg);           
        }
        // реализация интерфейса IComparer<Organization>
        public int Compare(Organization a, Organization b)
        {
            return a.YearRegOrg.CompareTo(b.YearRegOrg);              
        }

        public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (Object.ReferenceEquals(obj, this)) return true; //если они совпадают по ссылкам они точно равны

        Organization p = obj as Organization;
        if ((Object)p == null) return false; // если объект нельзя представить как Person

        return (NameOrg == p.NameOrg) && (AdressOrg == p.AdressOrg) && (YearRegOrg == p.YearRegOrg); //если выполнятся два условия вернется true
    }

    // Операции == и != переопределяются так как Equals
    public static bool operator ==(Organization a, Organization b)
    {
        if (((object)a == null) && ((object)b == null)) return false;

        if (Object.ReferenceEquals(a, b)) return true;

        return a.NameOrg == b.NameOrg && a.AdressOrg == b.AdressOrg && a.YearRegOrg == b.YearRegOrg;
    }
    public static bool operator !=(Organization a, Organization b)
    {
        return !(a == b);
    }

    public virtual object DeepCopy()
    {
        return new Organization(NameOrg, AdressOrg, YearRegOrg);
    }


    public override int GetHashCode()
    {
        return (NameOrg.GetHashCode() * 41 + AdressOrg.GetHashCode() * 37 + YearRegOrg.GetHashCode() * 31);
    }
    public override string ToString()
    {
        return "Название организации: " + NameOrg + "\n" + "Адресс: " + AdressOrg + "\n" + "Год регистрации: " + YearRegOrg + "\n";
    }


}
}
