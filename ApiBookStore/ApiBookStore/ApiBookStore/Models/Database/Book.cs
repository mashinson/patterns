using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiBookStore.Models
{
    public class Book
    {
        public  int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Year { get; set; }

        public int Author_ID { get; set; }
        public int Genre_ID { get; set; }
        public int PublishingHome_ID { get; set; }

        [ForeignKey("Author_ID")]
        public virtual Author Author { get; set; }

        [ForeignKey("Genre_ID")]
        public virtual Genre Genre { get; set; }
        [ForeignKey("PublishingHome_ID")]
        public virtual PublishingHome PublishingHome { get; set; }
    }
}