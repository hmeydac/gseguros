namespace InsuranceBroker.Entities.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Broker
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Telephone { get; set; }

        public string Email { get; set; }
    }
}
