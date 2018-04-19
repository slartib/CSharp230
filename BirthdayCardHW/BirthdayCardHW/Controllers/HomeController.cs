using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirthdayCardHW.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Index(Models.BirthdayCardModel bdayCardResponse )
    {
      if (ModelState.IsValid)
      {
        return View("BirthdayCard", bdayCardResponse);
      }
      else
      {
        return View();
      }
    }

  }
}