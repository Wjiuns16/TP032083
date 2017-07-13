using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNetAppSqlDb.Models;using System.Diagnostics;

namespace DotNetAppSqlDb.Controllers
{
    public class TodosController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Description of Maersk Line";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Maersk Line Contact Page.";

            return View();
        }

        public ActionResult Faq()
        {
            ViewBag.Message = "Maersk Line Popular Questions.";

            return View();
        }
    }
}
