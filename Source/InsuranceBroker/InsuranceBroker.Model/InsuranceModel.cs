namespace InsuranceBroker.Model
{
    using System.Data.Entity;

    using InsuranceBroker.Model.Entities;

    public class InsuranceModel : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
