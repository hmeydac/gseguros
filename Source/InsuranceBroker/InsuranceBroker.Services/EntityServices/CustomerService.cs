namespace InsuranceBroker.Services.EntityServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using InsuranceBroker.Entities.Entities;
    using InsuranceBroker.Model;

    public class CustomerService : IEntityService<Customer>
    {
        private readonly InsuranceModel context = new InsuranceModel();

        public IEnumerable<Customer> GetList()
        {
            return (from customer in this.context.Customers orderby customer.LastName, customer.FirstName select customer).ToList();
        }

        public Customer Add(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            this.context.Customers.Add(customer);
            this.context.SaveChanges();
            return customer;
        }

        public Customer GetById(Guid id)
        {
            return this.context.Customers.FirstOrDefault(c => c.Id.Equals(id));
        }

        public void Delete(Guid id)
        {
            var customer = this.GetById(id);
            this.context.Customers.Remove(customer);
            this.context.SaveChanges();
        }

        public Customer Update(Customer editedCustomer)
        {
            var customer = this.GetById(editedCustomer.Id);
            customer.FirstName = editedCustomer.FirstName;
            customer.LastName = editedCustomer.LastName;
            customer.Telephone = editedCustomer.Telephone;
            customer.Email = editedCustomer.Email;
            this.context.SaveChanges();
            return customer;
        }
    }
}
