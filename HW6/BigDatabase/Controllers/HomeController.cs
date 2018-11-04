﻿using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using BigDatabase.Controllers;
using BigDatabase.Models;
using BigDatabase.Models.ViewModels;
using System.Web.Security;
using System.Data.Entity;

namespace BigDatabase.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db = new UserContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            string client = Request.QueryString["client"];
            if (client != null && client != "" && client != " ")
            {
                List<PersonVM> SearchResult = db.People.Where(person => person.FullName.Contains(client)).Where(p => p.PersonID
                            != 1).Select(person => new PersonVM { Name = person.FullName, PreferredName = person.PreferredName, PhoneNumber = person.PhoneNumber, FaxNumber = person.FaxNumber, EmailAddress = person.EmailAddress, ValidFrom = person.ValidFrom }).ToList();

                if (SearchResult.FirstOrDefault() == null)
                {
                    ViewBag.Toggle = 2;
                    return View(SearchResult);
                }
                else
                {
                    ViewBag.Toggle = 1;
                    return View(SearchResult);
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Details(string result)
        {
            if (result == null || result == "")
            {
                return (RedirectToAction("About"));
            }

            //Get's the default information for the details page.
            List<PersonVM> DetailPerson = db.People.Where(person => person.FullName == result).Select(person => new PersonVM { Name = person.FullName, PreferredName = person.PreferredName, PhoneNumber = person.PhoneNumber, FaxNumber = person.FaxNumber, EmailAddress = person.EmailAddress, ValidFrom = person.ValidFrom }).ToList();

            //Customer Company Details. See PersonVM.cs
            var CustomerDetails = db.People
                                    .Where(p => p.FullName == result)
                                    .Include("PrimaryContactPersonID")
                                    .SelectMany(p => p.Customers2).ToList();

            //Executes if CustomerDetails doesn't have any values.
            if (CustomerDetails.Count == 0)
            {// If the person is not a customer of World Wide Importers, return default details page.
                return View(DetailPerson); 
            }
            //Queries through System.Data.Entity.Core.EntityCommandExecutionException because they took too long so I put them in a try
            //catch. Solved the problem.
            try
            {
                //Items Purchased Details See PersonVM.cs. This query gets details on top 10 items sold to the customer.
                var ItemDetails = db.People.Where(person => person.FullName.Contains(result)).Include("PrimaryContactPersonID")
                                    .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
                                    .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices).Include("InvoiceID")
                                    .SelectMany(x => x.InvoiceLines).OrderByDescending(x => x.LineProfit).Take(10).ToList();

                //A list of salesman for the top 10 items sold to the customer.
                var SalesMen = db.People.Where(person => person.FullName.Contains(result)).Include("PrimaryContactPersonID")
                                             .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
                                             .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices).Include("InvoiceID")
                                             .SelectMany(x => x.InvoiceLines).OrderByDescending(x => x.LineProfit).Take(10)
                                             .Include("InvoiceID").Select(x => x.Invoice).Include("SalespersonID").Select(x => x.Person4)
                                             .ToList();
                //Items Purchased Details see PersonVM.cs

                List<ItemPurchased> Top10Items = new List<ItemPurchased>();

                //Intializes a list of ItemPurchased classes that contains the details for the top 10 items sold to the customer.
                for (int i = 0; i < 10; i++)
                {//Initializes ItemPurchased for each of the 10 items
                    Top10Items.Add(new ItemPurchased
                    {
                        StockItemID = ItemDetails.ElementAt(i).StockItemID,
                        ItemDescription = ItemDetails.ElementAt(i).Description,
                        LineProfit = ItemDetails.ElementAt(i).LineProfit,
                        SalesPerson = SalesMen.ElementAt(i).FullName
                    });

                }
                PersonVM Customer = new PersonVM
                {//Default Details See PersonVM.cs. Basic details about the person being searched.
                    Name = DetailPerson.First().Name,
                    PreferredName = DetailPerson.First().PreferredName,
                    PhoneNumber = DetailPerson.First().PhoneNumber,
                    FaxNumber = DetailPerson.First().FaxNumber,
                    EmailAddress = DetailPerson.First().EmailAddress,
                    ValidFrom = DetailPerson.First().ValidFrom,
                    //Customer Company Details; See PersonVM.cs. Details about the customer's company.
                    CompanyName = CustomerDetails.First().CustomerName,
                    CompanyPhone = CustomerDetails.First().PhoneNumber,
                    CompanyFax = CustomerDetails.First().FaxNumber,
                    CompanyWebsite = CustomerDetails.First().WebsiteURL,
                    CompanyValidFrom = CustomerDetails.First().ValidFrom,
                    //Purchase History Details; See PersonVM.cs. Total orders, GrossSales and Gross profit for those orders.
                    Orders = db.People.Where(person => person.FullName.Contains(result)).Include("PrimaryContactPersonID")
                               .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders).Count(),

                    GrossSales = db.People.Where(person => person.FullName.Contains(result)).Include("PrimaryContactPersonID")
                                   .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
                                   .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices)
                                   .Include("InvoiceID").SelectMany(x => x.InvoiceLines).Sum(x => x.ExtendedPrice),

                    GrossProfit = db.People.Where(person => person.FullName.Contains(result)).Include("PrimaryContactPersonID")
                                   .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
                                   .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices)
                                   .Include("InvoiceID").SelectMany(x => x.InvoiceLines).Sum(x => x.LineProfit),
                    //Items purchased details. A list of details about the top 10 most profitable items sold to the customer. See ItemPurchased.cs
                    ItemPurchaseSummary = Top10Items
                };



                /*Debug.WriteLine(Customer.Name);
                Debug.WriteLine(Customer.PreferredName);
                Debug.WriteLine(Customer.PhoneNumber);
                Debug.WriteLine(Customer.FaxNumber);
                Debug.WriteLine(Customer.EmailAddress);
                Debug.WriteLine(Customer.ValidFrom);
                Debug.WriteLine(Customer.CompanyName);
                Debug.WriteLine(Customer.CompanyPhone);
                Debug.WriteLine(Customer.CompanyFax);
                Debug.WriteLine(Customer.CompanyWebsite);
                Debug.WriteLine(Customer.CompanyValidFrom);
                Debug.WriteLine(Customer.Orders);
                Debug.WriteLine(Customer.GrossSales);
                Debug.WriteLine(Customer.GrossProfit);
                for (int x = 0; x < 10; x++)
                {
                    Debug.WriteLine(Customer.ItemPurchaseSummary.ElementAt(x).StockItemID);
                    Debug.WriteLine(Customer.ItemPurchaseSummary.ElementAt(x).ItemDescription);
                    Debug.WriteLine(Customer.ItemPurchaseSummary.ElementAt(x).LineProfit);
                    Debug.WriteLine(Customer.ItemPurchaseSummary.ElementAt(x).SalesPerson);

                }*/
                return View(DetailPerson);
            }
            catch (System.Data.Entity.Core.EntityCommandExecutionException)
            {
            }

            return View(DetailPerson);

        }
    }
}
