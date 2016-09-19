using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPinterest.Models
{
    public class Pin
    {
        public int PinID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Title { get; set; }

        [StringLength(160, MinimumLength = 3)]
        public string Text { get; set; }

        [Required]
        public string Picture { get; set; }

        public virtual List<Tag> Tags { get; set; }

        public virtual User UserCreator { get; set; }

        public virtual List<User> Users { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<Like> Likes { get; set; }
    }
}