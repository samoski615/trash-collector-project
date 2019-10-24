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

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            return View();
        }

        // GET: Employees/Details/5
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

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, FirstName, LastName, Zipcode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationId = User.Identity.GetUserId();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", employee.ApplicationId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", employee.ApplicationId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirstName, LastName, Zipcode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", employee.ApplicationId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
        // GET: Employees Daily Route of Customers by ZipCode
        //public ActionResult CustomerIndex()
        //{
        //    var currentUId = User.Identity.GetUserId();
        //    var employee = db.Employees.Where(e => e.ApplicationId == currentUId).SingleOrDefault();
        //    var todaysPickups = db.Customers.Where(c => c.ZipCode == employee.ZipCode);

        //    if (todaysPickups.Equals(null))
        //    {
        //        return View("Index");
        //    }
        //    else
        //    {
        //        return View(todaysPickups.ToList());
        //    }
        //}
        //public ActionResult Search(System.DayOfWeek? dayOfWeek)
        //{
        //    var currentUId = User.Identity.GetUserId();
        //    var employee = db.Employees.Where(e => e.ApplicationId == currentUId).SingleOrDefault();
        //    var todaysPickups = db.Customers.Where(c => c.ZipCode == employee.ZipCode);
        //    var daysMatched = db.Customers.Where(c => c.DayOfWeek.Equals(dayOfWeek));

        //    if (todaysPickups.Equals(null))
        //    {
        //        return View("Index");
        //    }
        //    else
        //    {
        //        return View(daysMatched);
        //    }
        //}
        public ActionResult ServiceDetails(int? id)
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
        public ActionResult ConfirmPickup(Customer customer)
        {
            //var customer = db.Customers.Find(id);
            ViewBag.ConfirmPickup = customer.ConfirmPickup;
            if (customer.ConfirmPickup == true)
            {
                ChargeCustomer(customer);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View("ServiceDetails");
        }

        public void ChargeCustomer(Customer customer)
        {
            customer.WeeklyCharges += 25.00;
            db.SaveChanges();
        }
        
        //public ActionResult ConfirmCharges()
        //{
        //    return View();
        //}

        public ActionResult MapOfDailyCustomers()
        {
            return View();
        }

    }
}