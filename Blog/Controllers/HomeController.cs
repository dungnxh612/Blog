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
            ViewBag.Category = obj.SelectCategory();
            ViewBag.Position = obj.SelectPosition();
            blg.AllBlog = obj.SelectAllData();
            return View(blg);
        }

        [HttpGet]
        public ActionResult Search(string SearchString)
        {
            Blogs blg = new Blogs();
            DataAccessLayer obj = new DataAccessLayer();
            ViewBag.Category = obj.SelectCategory();
            ViewBag.Position = obj.SelectPosition();
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
        public ActionResult Create(Blg blg)
        {
            DataAccessLayer obj = new DataAccessLayer();
            ViewBag.Category = obj.SelectCategory();
            ViewBag.Position = obj.SelectPosition();
            if (ModelState.IsValid)
            {
                string result = obj.InsertData(blg);
                return RedirectToAction("ListAllBlog");
            }
            return View(blg);
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            objDB.DeleteData(ID);

            return RedirectToAction("ListAllBlog");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            Blogs bl= new Blogs();
            DataAccessLayer obj = new DataAccessLayer();
            ViewBag.Category = obj.SelectCategory();
            ViewBag.Position = obj.SelectPosition();
            bl= obj.SelectDataById(ID);
            return View(bl);
        }

        [HttpPost]
        public ActionResult Edit(Blg bl)
        {
            DataAccessLayer obj = new DataAccessLayer();
            ViewBag.Category = obj.SelectCategory();
            ViewBag.Position = obj.SelectPosition();
            if (ModelState.IsValid)
            {
                obj.UpdateData(bl);
                return RedirectToAction("ListAllBlog");
            }
            return View();
        }
    }
}