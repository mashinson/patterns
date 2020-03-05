using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiBookStore.Models
{
    public class FiltersModel
    {
        public IEnumerable<AuthorModel> Authors { get; set; }
        public IEnumerable<GenreModel> Genges { get; set; }
        public IEnumerable<PublishingHomeModel> PublishingHouses { get; set; }
    }
}