using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace freccamp.Models
{
    public class Register : ModelBase
    {
      public Register()
      {
        CurrentReg = new Registration() { Campers = new List<Camper>(), Camps = new List<Camp>() };
      }
      public Registration CurrentReg { get; set; }
    }
}