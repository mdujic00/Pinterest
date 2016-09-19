using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPinterest.Models
{
    public class Comment
    {
        public int CommentID { get; set; }

        [Required]
        [StringLength(160, MinimumLength = 2)]
        public string Text { get; set; }

        public virtual User User { get; set; }

        public virtual Pin Pin { get; set; }

        public DateTime Vrijeme { get; set; }
    }
}