namespace InsuranceBroker.Model
{
    using System.Data.Entity;

    using InsuranceBroker.Entities.Entities;

    public class InsuranceModel : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Broker> Brokers { get; set; }
    }
}
