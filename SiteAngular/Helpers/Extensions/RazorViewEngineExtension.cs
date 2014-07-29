using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteAngular.Helpers.Extensions
{
    public class RazorViewEngineExtension : RazorViewEngine
    {
        public string[] PartialViewLocations = new string[] { "~/Views/{1}/Partials/{0}.cshtml" , "~/Views/Shared/Partials/{0}.cshtml" };
        public RazorViewEngineExtension()
        {
            this.PartialViewLocationFormats = this.PartialViewLocationFormats.Union(PartialViewLocations).ToArray();
        }
    }
}