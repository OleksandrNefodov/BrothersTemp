using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrothersProjects.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<SelectListItem> GetEnumSelectList<T>()
        {
            return (Enum.GetValues(typeof(T)).Cast<int>().Select(e => new SelectListItem() { Text = Enum.GetName(typeof(T), e), Value = e.ToString() })).ToList();
        }

        public static byte[] DecodeUrlBase64(this string s)
        {
            s = s.Replace('-', '+').Replace('_', '/').PadRight(4 * ((s.Length + 3) / 4), '=');
            return Convert.FromBase64String(s);
        }
    }
}