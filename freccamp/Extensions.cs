using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace freccamp
{
  public static class Extensions
  {
    public static string ToCustomDateString(this DateTime date)
    {
      var sb = new StringBuilder();
      sb.AppendFormat("{0:MMMM d}", date);
      switch(date.Day)
      {
        case 1:
        case 21:
        case 31:
          sb.Append("st");
          break;
        case 2:
        case 22:
          sb.Append("nd");
          break;
        case 3:
        case 23:
          sb.Append("rd");
          break;
        default:
          sb.Append("th");
          break;
      }
      return sb.ToString();
    }
  }
}