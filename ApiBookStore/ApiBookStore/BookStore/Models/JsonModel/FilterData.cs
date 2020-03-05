using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class FilterData
    {
        public FilterData()
        {
            AuthorID = -1;
            GenreID = -1;
            HouseID = -1;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int AuthorID { get; set; }
        public int GenreID { get; set; }
        public int HouseID { get; set; }
        public int? CreationDate { get; set; }
    }
}