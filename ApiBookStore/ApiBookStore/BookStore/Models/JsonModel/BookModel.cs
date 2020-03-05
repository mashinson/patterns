using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class BookModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string PublishingHomeName { get; set; }
        public string GenreName { get; set; }
        public int Year { get; set; }
        public int AuthorID { get; set; }
        public int GenreID { get; set; }
        public int PublishingHomeID { get; set; }
    }
}