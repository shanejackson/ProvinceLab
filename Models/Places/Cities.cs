using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab03Canada.Models.Places { 
 public class Cities
{

    public int CitiesId { get; set; }
    [Display(Name = "City")]
    public string CityName { get; set; }
    public int Population { get; set; }

    public string ProvinceCode { get; set; }
    public Provinces Province { get; set; }
}
}