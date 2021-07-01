using System;
using FluentValidation;

namespace WebApplication.Models.DTOModels
{
    public class AddRequestViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public string PassportId { get; set; }
        public string AdministrativeUnit { get; set; }
        public string PhoneNumber { get; set; }
        public int FamilyComposition { get; set; }
        public double CommonArea { get; set; }
        public double LivingArea { get; set; }
        public string Address { get; set; }
        public string TypeOfProperty { get; set; }
        public string StateOfProperty { get; set; }
    }

    public class AddRequestValidator : AbstractValidator<AddRequestViewModel>
    {
        public AddRequestValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.MiddleName).NotNull();
            RuleFor(x => x.Birthday).NotNull();
            RuleFor(x => x.PassportId).NotNull();
            RuleFor(x => x.AdministrativeUnit).NotNull();
            RuleFor(x => x.PhoneNumber).NotNull();
            RuleFor(x => x.FamilyComposition).NotNull();
            RuleFor(x => x.CommonArea).NotNull();
            RuleFor(x => x.LivingArea).NotNull();
            RuleFor(x => x.Address).NotNull();
            RuleFor(x => x.TypeOfProperty).NotNull();
            RuleFor(x => x.StateOfProperty).NotNull();
        }
    }
}