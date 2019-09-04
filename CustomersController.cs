using System;
using System.Collections.Generic;
using System.Linq;
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
        //GET: CUSTOMER
        public ActionResult Index()
        {
            return View();
        }
        //GET: Customer Details
        public ActionResult Details(int id)
        {
            return View();
        }
        //GET: Create Customer
        public ActionResult Create()
        {
            return View();
        }
        //POST: Create Customer
        public ActionResult Create(Customer customer)
        {
            try
            {
                db.customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(customer);
            }

        }

    }
}