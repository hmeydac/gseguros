namespace InsuranceBroker.Services.EntityServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using InsuranceBroker.Entities.Entities;
    using InsuranceBroker.Model;

    public class BrokerService : IEntityService<Broker>
    {
        private readonly InsuranceModel context = new InsuranceModel();

        public IEnumerable<Broker> GetList()
        {
            return (from broker in this.context.Brokers orderby broker.LastName, broker.FirstName select broker).ToList();
        }

        public Broker Add(Broker broker)
        {
            broker.Id = Guid.NewGuid();
            this.context.Brokers.Add(broker);
            this.context.SaveChanges();
            return broker;
        }

        public Broker GetById(Guid id)
        {
            return this.context.Brokers.FirstOrDefault(c => c.Id.Equals(id));
        }

        public void Delete(Guid id)
        {
            var broker = this.GetById(id);
            this.context.Brokers.Remove(broker);
            this.context.SaveChanges();
        }

        public Broker Update(Broker editedBroker)
        {
            var broker = this.GetById(editedBroker.Id);
            broker.FirstName = editedBroker.FirstName;
            broker.LastName = editedBroker.LastName;
            broker.Telephone = editedBroker.Telephone;
            broker.Email = editedBroker.Email;
            this.context.SaveChanges();
            return broker;
        }
    }
}
