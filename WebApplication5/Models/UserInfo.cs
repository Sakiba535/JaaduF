using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class UserInfo
    {
        [Key]
        [Required]
        [StringLength(50,MinimumLength =4)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50,MinimumLength =5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role {  get; set; }







    }
}