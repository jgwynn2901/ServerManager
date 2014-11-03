using System;
using System.Web;
using WebSecurity;

namespace ServerManager.Models
{
  public class CookieStore
  {
    public static void SetCookie(string key, string value, TimeSpan expires)
    {
      var encodedCookie = HttpSecureCookie.Encode(new HttpCookie(key, value));

      if (HttpContext.Current.Request.Cookies[key] != null)
      {
        var cookieOld = HttpContext.Current.Request.Cookies[key];
        cookieOld.Expires = DateTime.Now.Add(expires);
        cookieOld.Value = encodedCookie.Value;
        HttpContext.Current.Response.Cookies.Add(cookieOld);
      }
      else
      {
        encodedCookie.Expires = DateTime.Now.Add(expires);
        HttpContext.Current.Response.Cookies.Add(encodedCookie);
      }
    }
    public static string GetCookie(string key)
    {
      var value = string.Empty;
      var cookie = HttpContext.Current.Request.Cookies[key];

      if (cookie == null) return value;
      // For security purpose, we need to encrypt the value.
      var decodedCookie = HttpSecureCookie.Decode(cookie);
      value = decodedCookie.Value;
      return value;
    }
  }
}