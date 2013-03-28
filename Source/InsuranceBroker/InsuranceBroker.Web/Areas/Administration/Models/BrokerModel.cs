namespace InsuranceBroker.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BrokerModel : ContentItem
    {
        private const string EmailRegex = @"($^)|([A-Za-z0-9_\.-]*@[A-Za-z0-9-]*\.[A-Za-z]*)";

        [Required(ErrorMessage = "Ingrese el nombre.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ingrese el apellido.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Ingrese el teléfono.")]
        public string Telephone { get; set; }

        [RegularExpression(EmailRegex, ErrorMessage = "Ingrese un email correcto.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public CustomerType CustomerType { get; set; }

        public override string DisplayName
        {
            get
            {
                return this.LastName + ", " + this.FirstName;
            }
        }

        public override string AdditionalInfo
        {
            get
            {
                return this.Telephone;
            }
        }
    }
}