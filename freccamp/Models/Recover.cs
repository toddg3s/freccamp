using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace freccamp.Models
{
  public class Recover
  {
    public string Email { get; set; }
    public List<Tuple<int,string>> Registrations { get; set; }
  }
}