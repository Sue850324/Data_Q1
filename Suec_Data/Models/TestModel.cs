using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Suec_Data.Models
{
    public class TestModel
    {
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime Date1 { set; get; }

        [Display(Name = "Locale")]
        public string Locale { set; get; }

        [Display(Name = "Product Name")]
        public string Product_Name { set; get; }

        [Display(Name ="Price") ]      
        public string Price { set; get; }

        [Display(Name ="Promote Price")]
        public string Promote_Price { set; get; }
    }

}