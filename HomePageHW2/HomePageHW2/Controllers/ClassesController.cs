using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HomePageHW2.Models;
using Microsoft.AspNet.Identity;

namespace HomePageHW2.Controllers
{
  public class ClassesController : Controller
  {
    private ClassModel db = new ClassModel();

    // GET: Classes
    public ActionResult Index()
    {
      return View(db.Classes.ToList());
    }

    [Authorize(Roles = ("User"))]
    public ActionResult RegisteredClasses()
    {
      var user = Session["ClassUser"];

      if (user != null)
      {
        var dbUser = db.Users.Find(((User)user).UserId);
        return View(((User)dbUser).Classes.ToList());
      }
      else
      {
        return null;
      }
    }

    [Authorize(Roles = ("User"))]
    public ActionResult Enroll()
    {
      var user = Session["ClassUser"];

      if (user != null)
      {
        var dbUser = db.Users.Find(((User)user).UserId);
        return View(db.Classes.Where(t => !t.Users.Any(x => x.UserId == dbUser.UserId)).ToList());
      }
      else
      {
        return null;
      }
    }


    // POST: Classes/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

    [Authorize(Roles = "User")]
    public ActionResult CompleteEnroll(int? id)
    {
     // if (ModelState.IsValid)
     // {
        Class dbClass = db.Classes.Find(id);
        User sessUser = (User)Session["ClassUser"];
        User dbUser = db.Users.Find(sessUser.UserId);

        if (dbClass != null && dbUser != null)
        {
          dbClass.Users.Add(dbUser);
          db.Entry(dbClass).State = EntityState.Modified;
          db.SaveChanges();
          return RedirectToAction("RegisteredClasses");
        }


      //}

      return RedirectToAction("Enroll");
    }

    // GET: Classes/Edit/5
    public ActionResult EnrollConfirm(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Class @class = db.Classes.Find(id);
      if (@class == null)
      {
        return HttpNotFound();
      }
      return View(@class);
    }

   

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
