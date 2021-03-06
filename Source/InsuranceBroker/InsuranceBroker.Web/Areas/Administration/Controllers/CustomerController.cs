﻿namespace InsuranceBroker.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using InsuranceBroker.Entities.Entities;
    using InsuranceBroker.Services.EntityServices;
    using InsuranceBroker.Web.Areas.Administration.Models;

    using WebGrease.Css.Extensions;

    public class CustomerController : Controller
    {
        private readonly CustomerService entityService = new CustomerService();
        
        public ActionResult Index()
        {
            this.ViewBag.Controller = "Customer";
            this.ViewBag.ViewAction = "Details";
            this.ViewBag.NewAction = "New";
            var entitys = this.GetList();
            return this.View(entitys.OrderBy(c => c.DisplayName).ToList());
        }

        public ActionResult New()
        {
            this.ViewBag.Controller = "Customer";
            this.ViewBag.ListAction = "Index";
            return this.View();
        }


        [HttpPost]
        public ActionResult New(CustomerModel newCustomer)
        {
            if (this.ModelState.IsValid)
            {
                var entity = Mapper.Map<Customer>(newCustomer);
                this.entityService.Add(entity);
                return this.RedirectToAction("Index");
            }

            return this.View(newCustomer);
        }

        public ActionResult Details(Guid id)
        {
            this.ViewBag.Controller = "Customer";
            var entity = this.GetEntityDetails(id);
            if (entity == null)
            {
                throw new InvalidDataException("Cliente no encontrado. Id: " + id.ToString());
            }

            this.ViewBag.ListAction = "Index";
            this.ViewBag.EditAction = "Edit";
            this.ViewBag.DeleteAction = "Delete";
            return this.View(entity);
        }

        public ActionResult Edit(Guid id)
        {
            var entity = this.GetEntityDetails(id);
            if (entity == null)
            {
                throw new InvalidDataException("Cliente no encontrado. Id: " + id.ToString());
            }

            this.ViewBag.Controller = "Customer";
            this.ViewBag.ViewAction = "Details";
            return this.View(entity);
        }

        [HttpPost]
        public ActionResult Edit(CustomerModel editedCustomer)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.UpdateEntity(editedCustomer);
                return this.RedirectToAction("Details", new { entity.Id });
            }

            return this.View(editedCustomer);
        }

        public ActionResult Delete(Guid id)
        {
            var entity = this.GetEntityDetails(id);
            if (entity == null)
            {
                throw new InvalidDataException("Cliente no encontrado. Id: " + id.ToString());
            }

            this.ViewBag.Controller = "Customer";
            this.ViewBag.ViewAction = "Details";
            return this.View(entity);
        }

        [HttpPost]
        public ActionResult Delete(CustomerModel entity)
        {
            this.DeleteEntity(entity);
            return this.RedirectToAction("Index");
        }

        private Customer UpdateEntity(CustomerModel editedEntity)
        {
            var entity = Mapper.Map<Customer>(editedEntity);
            this.entityService.Update(entity);
            return entity;
        }

        private void DeleteEntity(CustomerModel entity)
        {
            this.entityService.Delete(entity.Id);
        }

        private CustomerModel GetEntityDetails(Guid id)
        {
            var entity = this.entityService.GetById(id);
            return Mapper.Map<CustomerModel>(entity);
        }

        private IEnumerable<CustomerModel> GetList()
        {
            var entities = this.entityService.GetList();
            var modelList = new List<CustomerModel>();
            entities.ForEach(c => modelList.Add(Mapper.Map<CustomerModel>(c)));
            return modelList;
        }
    }
}
