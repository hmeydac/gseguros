namespace InsuranceBroker.Web.Areas.Administration.Models
{
    using System;

    public class ContentItem
    {
        public Guid Id { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string AdditionalInfo { get; set; }

        public string IconUrl { get; set; }
    }
}