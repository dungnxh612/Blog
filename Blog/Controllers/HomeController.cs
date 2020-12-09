using Blog.DataAccess;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult ListAllBlog()
        {
            Blogs blg = new Blogs();
            DataAccessLayer obj = new DataAccessLayer();
            blg.AllBlog = obj.SelectAllData();
            return View(blg);
        }

        [HttpGet]
        public ActionResult Search(string SearchString)
        {
            Blogs blg = new Blogs();
            DataAccessLayer obj = new DataAccessLayer();
            if (String.IsNullOrEmpty(SearchString))
            {
                blg.AllBlog = obj.SelectAllData();
            }
            else
            {
                blg.AllBlog = obj.SelectData(SearchString);
            }

            return View(blg);
        }

        [HttpGet]
        public ActionResult Create()
        {
            DataAccessLayer obj = new DataAccessLayer();
            ViewBag.Category = obj.SelectCategory();
            ViewBag.Position = obj.SelectPosition();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Blogs blg)
        {
            DataAccessLayer obj = new DataAccessLayer();
            string result = obj.InsertData(blg);
            if(result != "")
            {
                return RedirectToAction("ListAllBlog");
            }
            return View();
        }

    }
}