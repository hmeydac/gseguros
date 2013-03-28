namespace InsuranceBroker.Web.Areas.Administration.Controllers
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

    public class BrokerController : Controller
    {
        private readonly BrokerService entityService = new BrokerService();

        public ActionResult Index()
        {
            this.ViewBag.Controller = "Broker";
            this.ViewBag.ViewAction = "Details";
            this.ViewBag.NewAction = "New";
            var list = this.GetList();
            return this.View(list.OrderBy(c => c.DisplayName).ToList());
        }

        public ActionResult New()
        {
            this.ViewBag.Controller = "Broker";
            this.ViewBag.ListAction = "Index";
            return this.View();
        }


        [HttpPost]
        public ActionResult New(BrokerModel newBroker)
        {
            if (this.ModelState.IsValid)
            {
                var entity = Mapper.Map<Broker>(newBroker);
                this.entityService.Add(entity);
                return this.RedirectToAction("Index");
            }

            return this.View(newBroker);
        }

        public ActionResult Details(Guid id)
        {
            var entity = this.GetEntityDetails(id);
            if (entity == null)
            {
                throw new InvalidDataException("Cliente no encontrado. Id: " + id.ToString());
            }

            this.ViewBag.Controller = "Broker";
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
            
            this.ViewBag.Controller = "Broker";
            this.ViewBag.ViewAction = "Details";
            return this.View(entity);
        }

        [HttpPost]
        public ActionResult Edit(BrokerModel editedBroker)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.UpdateEntity(editedBroker);
                return this.RedirectToAction("Details", new { entity.Id });
            }

            return this.View(editedBroker);
        }

        public ActionResult Delete(Guid id)
        {
            var entity = this.GetEntityDetails(id);
            if (entity == null)
            {
                throw new InvalidDataException("Cliente no encontrado. Id: " + id.ToString());
            }

            this.ViewBag.Controller = "Broker";
            this.ViewBag.ViewAction = "Details";
            return this.View(entity);
        }

        [HttpPost]
        public ActionResult Delete(BrokerModel entity)
        {
            this.DeleteEntity(entity);
            return this.RedirectToAction("Index");
        }

        private Broker UpdateEntity(BrokerModel editedEntity)
        {
            var entity = Mapper.Map<Broker>(editedEntity);
            this.entityService.Update(entity);
            return entity;
        }

        private void DeleteEntity(BrokerModel entity)
        {
            this.entityService.Delete(entity.Id);
        }

        private BrokerModel GetEntityDetails(Guid id)
        {
            var entity = this.entityService.GetById(id);
            return Mapper.Map<BrokerModel>(entity);
        }

        private IEnumerable<BrokerModel> GetList()
        {
            var entities = this.entityService.GetList();
            var modelList = new List<BrokerModel>();
            entities.ForEach(c => modelList.Add(Mapper.Map<BrokerModel>(c)));
            return modelList;
        }
    }
}
