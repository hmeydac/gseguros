namespace InsuranceBroker.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using InsuranceBroker.Model;
    using InsuranceBroker.Model.Entities;
    using InsuranceBroker.Web.Areas.Administration.Models;

    public class CustomerController : Controller
    {
        // GET: /Administration/Customer/
        public ActionResult Index()
        {
            this.ViewBag.ViewAction = "Details";
            this.ViewBag.NewAction = "New";
            var customers = this.GetCustomers();
            return this.View(customers.OrderBy(c => c.DisplayName).ToList());
        }

        public ActionResult New()
        {
            this.ViewBag.ListAction = "Index";
            return this.View();
        }

        [HttpPost]
        public ActionResult New(CustomerModel newCustomer)
        {
            if (this.ModelState.IsValid)
            {
                var customer = Mapper.Map<Customer>(newCustomer);
                customer.Id = Guid.NewGuid();
                var context = new InsuranceModel();
                context.Customers.Add(customer);
                context.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(newCustomer);
        }

        public ActionResult Details()
        {
            return this.View();
        }

        private IEnumerable<CustomerModel> GetCustomers()
        {
            var context = new InsuranceModel();
            var customers = context.Customers.ToList();
            var modelList = new List<CustomerModel>();
            customers.ForEach(c => modelList.Add(Mapper.Map<CustomerModel>(c)));
            return modelList;
        }
    }
}
