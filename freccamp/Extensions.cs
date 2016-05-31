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

    public static bool IsEqual(this string value, string compareto)
    {
      var val = value.Trim();
      var compare = compareto.Trim();
      return val.Equals(compare, StringComparison.InvariantCultureIgnoreCase);
    }

    public static bool Check2Bool(this string value)
    {
      if (String.IsNullOrEmpty(value))
        return false;

      var parts = value.Trim().Split(",;:/|\\^+*".ToCharArray());
      bool result = false;
      if (!Boolean.TryParse(parts[0], out result))
      {
        return false;
      }
      else
      {
        return result;
      }
    }

  }
}