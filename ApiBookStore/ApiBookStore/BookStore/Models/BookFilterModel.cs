using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Models
{
    public class BookFilterModel
    {
        public BookFilterModel()
        {
            Authors = new List<SelectListItem>();
            Genres = new List<SelectListItem>();
            PublishingHouses = new List<SelectListItem>();
            Author ="-1";
            Genre = "-1";
            PublishingHouse = "-1";
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string PublishingHouse { get; set; }
        public string CreationDate { get; set; }

        public List<SelectListItem> Authors { get; set; }
        public List<SelectListItem> Genres { get; set; }
        public List<SelectListItem> PublishingHouses { get; set; }
    }
}