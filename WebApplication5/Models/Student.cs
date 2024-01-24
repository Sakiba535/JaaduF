using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId {  get; set; }
        [Required]
        [StringLength(50,MinimumLength =4)]
        public string StudentName { get; set; }
        [StringLength(250, MinimumLength = 4)]
        [DataType(DataType.MultilineText)]
        public string Address {  get; set; }
        [EmailAddress]
        [StringLength(50)]
        public string Email {  get; set; }
        [DisplayName("StudntPreference")]
        public int GenreId {  get; set; }
        public decimal MembershipFee {  get; set; }
        public bool IsStudent { get; set; }

        
        [ScaffoldColumn(false)]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [NotMapped]
        [ScaffoldColumn(true)]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual IList<Book> Books { get; set; }








    }
}