using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab03Canada.Models;
using Lab03Canada.Models.Places;

namespace Lab03Canada.Controllers
{
    public class CitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cities
        public async Task<ActionResult> Index()
        {
            var cities = db.Cities.Include(c => c.Province);
            return View(await cities.ToListAsync());
        }

        // GET: Cities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cities cities = await db.Cities.FindAsync(id);
            if (cities == null)
            {
                return HttpNotFound();
            }
            return View(cities);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            ViewBag.ProvinceCode = new SelectList(db.Provinces, "ProvinceCode", "ProvinceName");
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CitiesId,CityName,Population,ProvinceCode")] Cities cities)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(cities);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinceCode = new SelectList(db.Provinces, "ProvinceCode", "ProvinceName", cities.ProvinceCode);
            return View(cities);
        }

        // GET: Cities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cities cities = await db.Cities.FindAsync(id);
            if (cities == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinceCode = new SelectList(db.Provinces, "ProvinceCode", "ProvinceName", cities.ProvinceCode);
            return View(cities);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CitiesId,CityName,Population,ProvinceCode")] Cities cities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cities).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinceCode = new SelectList(db.Provinces, "ProvinceCode", "ProvinceName", cities.ProvinceCode);
            return View(cities);
        }

        // GET: Cities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cities cities = await db.Cities.FindAsync(id);
            if (cities == null)
            {
                return HttpNotFound();
            }
            return View(cities);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cities cities = await db.Cities.FindAsync(id);
            db.Cities.Remove(cities);
            await db.SaveChangesAsync();
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
