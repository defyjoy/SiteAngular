using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteAngular.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Create()
        {
            return PartialView("_Create");
        }

        public PartialViewResult List()
        {
            return PartialView("_List");
        }

        public PartialViewResult Edit()
        {
            return PartialView("_Edit");
        }
    }
}