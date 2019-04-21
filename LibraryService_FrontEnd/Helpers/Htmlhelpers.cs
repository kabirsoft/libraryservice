using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryService_FrontEnd.Helpers
{
    public static class Htmlhelpers
    {
        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            if (input.Length < length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }
    }
}