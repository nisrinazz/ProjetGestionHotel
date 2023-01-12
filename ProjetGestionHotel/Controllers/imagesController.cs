using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetGestionHotel.Models;

namespace ProjetGestionHotel.Controllers
{
    public class imagesController : Controller
    {
        private gestion_hotelEntities db = new gestion_hotelEntities();

        // GET: images
        public ActionResult Index()
        {
            var images = db.images.Include(i => i.chambre);
            return View(images.ToList());
        }

        // GET: images/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            images images = db.images.Find(id);
            if (images == null)
            {
                return HttpNotFound();
            }
            return View(images);
        }

        // GET: images/Create
        public ActionResult Create()
        {
            ViewBag.id_chambre = new SelectList(db.chambre, "id_chambre", "disponibilite");
            return View();
        }

        // POST: images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_img,id_chambre,image_file")] images images)
        {
            if (ModelState.IsValid)
            {
                db.images.Add(images);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_chambre = new SelectList(db.chambre, "id_chambre", "disponibilite", images.id_chambre);
            return View(images);
        }

        // GET: images/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            images images = db.images.Find(id);
            if (images == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_chambre = new SelectList(db.chambre, "id_chambre", "disponibilite", images.id_chambre);
            return View(images);
        }

        // POST: images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_img,id_chambre,image_file")] images images)
        {
            if (ModelState.IsValid)
            {
                db.Entry(images).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_chambre = new SelectList(db.chambre, "id_chambre", "disponibilite", images.id_chambre);
            return View(images);
        }

        // GET: images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            images images = db.images.Find(id);
            if (images == null)
            {
                return HttpNotFound();
            }
            return View(images);
        }

        // POST: images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            images images = db.images.Find(id);
            db.images.Remove(images);
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
