using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VerticalLiftBSIAssignment.Models
{
    public class Product
    {
        [Key]
        public Guid  id { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Count")]

        public int count { get; set; }
        [Display(Name = "Created On")]

        public DateTime createdOn { get; set; }
        [Display(Name = " Price")]

        public decimal price { get; set; }
        [Display(Name = " Description")]

        public string description { get; set; }


    }
}