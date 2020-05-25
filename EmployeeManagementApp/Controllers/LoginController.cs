using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementApp.Models;

namespace EmployeeManagementApp.Controllers
{
    public class LoginController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View(db.loginusers.ToList());
        }

        // GET: Login/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginuser loginuser = db.loginusers.Find(id);
            if (loginuser == null)
            {
                return HttpNotFound();
            }
            return View(loginuser);
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,password")] loginuser loginuser)
        {
            if (ModelState.IsValid)
            {
                db.loginusers.Add(loginuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginuser);
        }

        // GET: Login/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginuser loginuser = db.loginusers.Find(id);
            if (loginuser == null)
            {
                return HttpNotFound();
            }
            return View(loginuser);
        }

        // POST: Login/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,password")] loginuser loginuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginuser);
        }

        // GET: Login/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginuser loginuser = db.loginusers.Find(id);
            if (loginuser == null)
            {
                return HttpNotFound();
            }
            return View(loginuser);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            loginuser loginuser = db.loginusers.Find(id);
            db.loginusers.Remove(loginuser);
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
