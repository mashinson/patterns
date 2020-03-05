using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiBookStore.Models
{
    public class PublishingHome
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}