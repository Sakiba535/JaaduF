using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Genre
    {
        [Key] 
        public int Id { get; set; }
        [Required] 
        public string GenreType { get; set; }


    }
}