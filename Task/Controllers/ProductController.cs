using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Task.Models;

namespace Task.Controllers
{
    public class ProductController : Controller
    {
        Datacontext db=new Datacontext();
        // GET: Product
        public ActionResult ProductIndex(string searchString, int? filterId)
        {
            var products = db.products.AsQueryable();
            if (filterId.HasValue)
            {
                products = products.Where(model => model.Product_Id == filterId.Value);

            }
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(model => model.Name.Contains(searchString));
            }
            var productIds = db.products.Select(model => model.Product_Id).Distinct();
            ViewBag.ProductIdList = new SelectList(productIds);

            //List<Product> products = new List<Product>();
            //products=db.products.ToList();
            return View(products.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            Product products= new Product();
            products=db.products.Add(products);
            return View(products);
        }
        [HttpPost]

        public ActionResult Create(Product products)
        {
            if(ModelState.IsValid)
            {
                db.products.Add(products);
                db.SaveChanges();
                Response.Redirect("ProductIndex");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Product pdt = new Product();
            pdt = db.products.Find(Id);
            return View(pdt);
        }
        [HttpPost]
        public ActionResult Edit(Product pdt)
        {
            db.Entry(pdt).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ProductIndex");
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Product pdt=new Product();
            pdt = db.products.Find(Id);
            return View(pdt);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult postDelete(int Id)
        {
            Product pdt = db.products.Find(Id);
            db.products.Remove(pdt);
            db.SaveChanges();
            return RedirectToAction("ProductIndex");

        }
        [HttpGet]
        public ActionResult Details(int Id)
        {
            Product pdt=db.products.Find(Id);
            return View(pdt);
        }
    }
}