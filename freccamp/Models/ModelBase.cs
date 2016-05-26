using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace freccamp.Models
{
    public class ModelBase
    {
      private List<Camp> _regcamps = null;

      public List<Camp> RegularCamps
      {
        get
        {
          if (_regcamps == null)
          {
            _regcamps = GetCamps().Where(c => !c.Advanced).OrderBy(c => c.StartDate).ToList();
          }
          return _regcamps;
        }
      }

        protected List<Camp> GetCamps()
        {
            if(HttpContext.Current.Cache["camps"]==null)
            {
                using(var ctx = new campdata())
                {
                    HttpContext.Current.Cache["camps"] = ctx.Camps.ToList();
                }
            }
            return (List<Camp>)HttpContext.Current.Cache["camps"];
        }
    }
}