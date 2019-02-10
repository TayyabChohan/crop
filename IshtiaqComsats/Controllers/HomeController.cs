using IshtiaqComsats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IshtiaqComsats.Controllers
{
    public class HomeController : Controller
    {
        IshtiaqBhaiEntities1 db = new IshtiaqBhaiEntities1();

        public ActionResult Index()
        {
            var list = db.Person1.ToList();
                return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            DropdownBond();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person1 per)
        {
            db.Person1.Add(per);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            DropdownBond();
            Person1 per =db.Person1.Find(id);
                
            return View(per);
        }
        [HttpPost]
        public ActionResult Edit(Person1 person1, int id)
        {
            Person1 pr=db.Person1.SingleOrDefault(m => m.personId == id);
            pr.personId = person1.personId;
            pr.Name = person1.Name;
            pr.Adress = person1.Adress;
            pr.GenderId = person1.GenderId;
            pr.ReligionId = person1.ReligionId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Person1 pr=db.Person1.Find(id);
            if (pr == null)
            {
                HttpNotFound();
            }

            return View(pr);
        }
        public ActionResult Delete(int id)
        {
            Person1 per = db.Person1.Find(id);
            db.Person1.Remove(per);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public void DropdownBond()
        {
            var GenderList = db.Genders.ToList();
            List<SelectListItem> catList = new SelectList(GenderList, "GenderId", "Type").ToList();
            ViewBag.CategoryBag = catList;

            var category = db.Religions.ToList();
            List<SelectListItem> RegList = new SelectList(category, "ReligionId", "Name").ToList();
            ViewBag.RegListBag = RegList;
        }
    }
}