using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COVID_19.DAL;
using COVID_19.Models;

namespace COVID_19.Controllers
{
    public class CaseController : Controller
    {
        private CovidContext db = new CovidContext();

        // GET: Case
        public ActionResult Index(String sortOrder, string searchString)
        {
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.ConfirmedSortParm = sortOrder == "Confirmed" ? "confirmed_desc" : "Confirmed";
            ViewBag.DeathsSortParm = sortOrder == "Deaths" ? "deaths_desc" : "Deaths";
            ViewBag.RecoveredSortParm = sortOrder == "Recovered" ? "recovered_desc" : "Recovered";
            ViewBag.ActiveSortParm = sortOrder == "Active" ? "active_desc" : "Active";
            var cases = from s in db.Cases select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                cases = cases.Where(s => s.Country.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    cases = cases.OrderByDescending(s => s.Country.Name);
                    break;
                case "Date":
                    cases = cases.OrderBy(s => s.Date);
                    break;
                case "Date_desc":
                    cases = cases.OrderByDescending(s => s.Date);
                    break;
                case "Confirmed":
                    cases = cases.OrderBy(s => s.Confirmed);
                    break;
                case "confirmed_desc":
                    cases = cases.OrderByDescending(s => s.Confirmed);
                    break;
                case "Deaths":
                    cases = cases.OrderBy(s => s.Deaths);
                    break;
                case "deaths_desc":
                    cases = cases.OrderByDescending(s => s.Deaths);
                    break;
                case "Recovered":
                    cases = cases.OrderBy(s => s.Recovered);
                    break;
                case "recovered_desc":
                    cases = cases.OrderByDescending(s => s.Recovered);
                    break;
                case "Active":
                    cases = cases.OrderBy(s => s.Active);
                    break;
                case "active_desc":
                    cases = cases.OrderByDescending(s => s.Active);
                    break;
                default:
                    cases = cases.OrderBy(s => s.Country.Name);
                    break;
            }
            return View(cases.ToList());
        }

        // GET: Case/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // GET: Case/Create
        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name");
            return View();
        }

        // POST: Case/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CountryID,Confirmed,Deaths,Recovered,Active,Date")] Case @case)
        {
            if (ModelState.IsValid)
            {
                db.Cases.Add(@case);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", @case.CountryID);
            return View(@case);
        }

        // GET: Case/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", @case.CountryID);
            return View(@case);
        }

        // POST: Case/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CountryID,Confirmed,Deaths,Recovered,Active,Date")] Case @case)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@case).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", @case.CountryID);
            return View(@case);
        }

        // GET: Case/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // POST: Case/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Case @case = db.Cases.Find(id);
            db.Cases.Remove(@case);
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
