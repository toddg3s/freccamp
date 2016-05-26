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
        public ActionResult Index()
        {
          return View(new Register()
          {
            CurrentReg = new Registration()
            {
              RegistrationId = 1,
              ContactName = "Todd Gray",
              ContactEmail = "todd@g3s.net",
              ContactPhone = "425-555-1212",
              Camps = new List<Camp>()
              {
                new Camp() { Id="session1", Name = "Session 1", StartDate = DateTime.Now, EndDate=DateTime.Now}
              },
                Campers = new List<Camper>()
              {
                new Camper() {Id = 1, Name = "Jasmine Gray", Email = "jazzyg218@gmail.com", RiderLevel=4}
              }
            }
          });
        }
    }
}