using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector
{
    public class CustomersController : Controller
    {
        ApplicationDbContext db;
        public CustomersController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        //GET: This gets a list of registered customers from the DB including the current user -- CHANGE THIS to just a view of the CustomerControllerHomeView
        public ActionResult CustomerDetails()
        {
            var currentUserId = User.Identity.GetUserId();
            var currentCustomer = db.Customers.Where(c => c.ApplicationId == currentUserId);
            return View(currentCustomer);
        }
        //GET: Customer Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        //GET: Create Customer
        public ActionResult Create()
        {
            ViewBag.ApplicationId = new SelectList(items: db.Users, "Id", "Email");
            return View();
        }
        //POST: Create Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, FirstName, LastName, StreetAddress, City, State, ZipCode, PickupDay")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.ApplicationId = User.Identity.GetUserId();
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("CustomerDetails");
            }

            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", customer.ApplicationId);
            return View(customer);
        }
        //GET: Edit Customer
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", customer.ApplicationId);
            return View(customer);
        }
        //POST: Edit Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, ApplicationId, FirstName, LastName, StreetAddress, City, State, ZipCode")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", customer.ApplicationId);
            return View(customer);
        }
        //GET: Delete Customer
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        //POST: Delete Customer
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
        //Change Pickup Date
        //public ActionResult ChangePickupDay(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", customer.ApplicationId);
        //    return View(customer);
        //}
        //POST: Change Pickup Date
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePickupDay([Bind(Include = "PickupDay")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.ApplicationId = User.Identity.GetUserId();
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CustomerDetails");
            }
            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", customer.ApplicationId);
            return View(customer);
        }

        public ActionResult ViewBalance(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer.MonthlyBalance);
        }
    }
}