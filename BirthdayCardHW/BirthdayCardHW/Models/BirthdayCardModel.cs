using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BirthdayCardHW.Models
{
  public class BirthdayCardModel
  {
    [Required(ErrorMessage = "Please enter who the wish is from")]
    public string From { get; set; }
    [Required(ErrorMessage = "Please enter who the wish is to")]
    public string To { get; set; }
    [Required(ErrorMessage = "Please enter the message for the birtday wish")]
    public string Message { get; set; }
  }
}