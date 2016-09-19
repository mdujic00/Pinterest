using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPinterest.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Nickname { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string Location { get; set; }

        public string UserPhoto { get; set; }

        public virtual List<Like> Likes { get; set; }
        public string Photo { get; set; }
    }
}