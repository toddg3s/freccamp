using freccamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace freccamp.Controllers
{
  public class RegisterController : Controller
  {
    // GET: Register
    public ActionResult Index(int? id)
    {
      if (id.HasValue && id.Value != 0)
      {
        return View(new Register()
        {
          CurrentReg = new Registration()
          {
            RegistrationId = id.Value,
            ContactName = "Todd Gray",
            ContactEmail = "todd@g3s.net",
            ContactPhone = "425-555-1212",
            Camps = new List<Camp>()
              {
                new Camp() { Id="session1", Name = "Session 1", StartDate = DateTime.Now, EndDate=DateTime.Now}
              },
            Campers = new List<Camper>()
              {
                new Camper() {Id = 1, Name = "Jasmine Gray", Email = "jazzyg218@gmail.com", RiderLevel=5}
              }
          }
        });
      }
      else
      {
        return View(new Register());
      }
    }

    public ActionResult Recover()
    {
      var model = new Recover();
      if(Request.Form["email"]!=null)
      {
        model.Email = Request.Form["email"].Trim();
        using(var ctx = new campdata())
        {
          var regs = (from r in ctx.Registrations 
                      where r.ContactEmail.Trim().Equals(model.Email, StringComparison.InvariantCultureIgnoreCase) 
                      select new Tuple<int, string>(r.RegistrationId, r.GetSummary())).ToList();
          model.Registrations = regs.ToList();
        }
        if(model.Registrations.Count == 1)
        {
          Response.Redirect("/register/index/" + model.Registrations[0].Item1);
        }
      }
      return View(model);
    }

    public ActionResult Save()
    {
      var newreg = ParseRequest(Request.Form);
      var currentreg = new Registration();
      var model = new Save();
      using (var ctx = new campdata())
      {
        if (newreg.RegistrationId != 0)
        {
          currentreg = ctx.Registrations.Find(newreg.RegistrationId);
          currentreg.Update(newreg, ctx);
        }
        else
        {
          currentreg = Registration.CreateNew(newreg, ctx);
          ctx.Registrations.Add(currentreg);
        }
        model.CurrentReg = currentreg;
        ctx.SaveChanges();
      }
      return View(model);
    }


    private Registration ParseRequest(System.Collections.Specialized.NameValueCollection form)
    {
      var reg = new Registration();

      reg.RegistrationId = Int32.Parse(form["CurrentReg.RegistrationId"] ?? "0");
      reg.ContactName = form["CurrentReg.ContactName"];
      reg.ContactEmail = form["CurrentReg.ContactEmail"];
      reg.ContactPhone = form["CurrentReg.ContactPhone"];

      foreach(var camp in (new Register().RegularCamps))
      {
        if(form["camp_" + camp.Id].Check2Bool())
        {
          if (reg.Camps == null) { reg.Camps = new List<Camp>(); }
          reg.Camps.Add(camp);
        }
      }

      var camperids = (from k in form.AllKeys where k.StartsWith("campername_") select k.Replace("campername_", "")).ToList();
      if (reg.Campers == null) { reg.Campers = new List<Camper>(); }
      foreach(var id in camperids)
      {
        var camper = ParseCamper(id, form);
        if (camper.Id < 100)
        {
          camper.Id = 0;
        }
        reg.Campers.Add(camper);
      }

      return reg;
    }

    private Camper ParseCamper(string id, System.Collections.Specialized.NameValueCollection form)
    {
      var camper = new Camper() { Id = Int32.Parse(id) };

      camper.Name = form["campername_" + id];
      camper.Parentname = form["parentname_" + id];
      camper.Email = form["camperemail_" + id];
      camper.Phone = form["camperphone_" + id];
      int level = 1;
      if(Int32.TryParse(form["riderlevel_" + id],out level))
      {
        camper.RiderLevel = level;
      }
      else
      {
        camper.RiderLevel = 1;
      }
      camper.Notes = form["notes_" + id];

      return camper;
    }
  }
}