using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using COVID_19.DAL;
using COVID_19.Models;
using Newtonsoft.Json;

namespace COVID_19.Controllers
{
    public class CountryController : Controller
    {
        private CovidContext db = new CovidContext();

        // GET: Country
        public ActionResult Index(String sortOrder, string searchString)
        {
            ViewBag.CodeSortParm = sortOrder == "Code" ? "code_desc" : "Code";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            var countries = from s in db.Countries select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                countries = countries.Where(s => s.Name.Contains(searchString) || s.Code.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "code_desc":
                    countries = countries.OrderByDescending(s => s.Code);
                    break;
                case "Name":
                    countries = countries.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    countries = countries.OrderByDescending(s => s.Name);
                    break;
                default:
                    countries = countries.OrderBy(s => s.Code);
                    break;
            }
            return View(countries.ToList());
        }

        // GET: Country/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Code,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(country);
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Country/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Code,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = db.Countries.Find(id);
            db.Countries.Remove(country);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
