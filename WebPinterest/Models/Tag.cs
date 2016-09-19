using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPinterest.Models
{
    public class Tag
    {
        public int TagID { get; set; }

        [StringLength(30, MinimumLength = 2)]
        public string TagName { get; set; }

        public virtual List<Pin> Pins { get; set; }
    }
}