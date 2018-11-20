﻿using AuctionHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using Microsoft.Ajax.Utilities;
using AuctionHouse.Models.ViewModels;
using System.Net;
using System.Data.Entity;

namespace AuctionHouse.Controllers
{
    public class HomeController : Controller
    {
        AuctionContext db = new AuctionContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {//gets all of the items from the database
            var Items = db.Items;
            //a new list of item view models for displaying in the view
            List<ItemVM> ItemList = new List<ItemVM>();
            //populates the list
            foreach (var item in Items)
            {
                ItemList.Add(new ItemVM { ItemId = item.ItemId, ItemName = item.ItemName, Description = item.Description, Seller = item.Seller1.SellerName });
            }    
                
            return View(ItemList);
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("List");
            }
            else
            {
                var item = db.Items.Find(id);
                ItemVM details = new ItemVM { ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    Description = item.Description,
                    Seller = item.Seller1.SellerName };
                return View(details);
            }   
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Seller = new SelectList(db.Sellers, "SellerId", "SellerName").AsEnumerable();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="ItemName, Description, Seller")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else if(!ModelState.IsValid)
            {
                ViewBag.Seller = new SelectList(db.Sellers, "SellerId", "SellerName");
                return View(item);
            }
            return View(item);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.Seller = new SelectList(db.Sellers, "SellerId", "SellerName", item.Seller);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include ="ItemId,ItemName,Description,Seller")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = item.ItemId });
            }
            ViewBag.Seller = new SelectList(db.Sellers, "SellerId", "SellerName", item.Seller);
            return View(item);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        /// <summary>
        /// Disposes of connection to database
        /// </summary>
        /// <param name="disposing"></param>
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