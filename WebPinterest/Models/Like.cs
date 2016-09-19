using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPinterest.Models
{
    public class Like
    {
        public int LikeID { get; set; }
        public bool Value { get; set; }

        public virtual User Liker { get; set; }
        public virtual Pin Pin { get; set; }
    }
}