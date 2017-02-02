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
    public class ProvincesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Provinces
        public async Task<ActionResult> Index()
        {
            return View(await db.Provinces.ToListAsync());
        }

        // GET: Provinces/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provinces provinces = await db.Provinces.FindAsync(id);
            if (provinces == null)
            {
                return HttpNotFound();
            }
            return View(provinces);
        }

        // GET: Provinces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provinces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProvinceCode,ProvinceName")] Provinces provinces)
        {
            if (ModelState.IsValid)
            {
                db.Provinces.Add(provinces);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(provinces);
        }

        // GET: Provinces/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provinces provinces = await db.Provinces.FindAsync(id);
            if (provinces == null)
            {
                return HttpNotFound();
            }
            return View(provinces);
        }

        // POST: Provinces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProvinceCode,ProvinceName")] Provinces provinces)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provinces).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(provinces);
        }

        // GET: Provinces/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provinces provinces = await db.Provinces.FindAsync(id);
            if (provinces == null)
            {
                return HttpNotFound();
            }
            return View(provinces);
        }

        // POST: Provinces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Provinces provinces = await db.Provinces.FindAsync(id);
            db.Provinces.Remove(provinces);
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
