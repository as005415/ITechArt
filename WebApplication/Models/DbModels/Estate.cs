using System.Collections.Generic;
using FluentValidation;

namespace WebApplication.Models.DbModels
{
    public class Estate
    {
        public int Id { get; set; }
        public double CommonArea { get; set; }
        public double LivingArea { get; set; }
        public string Address { get; set; }
        public string TypeOfProperty { get; set; }
        public string StateOfProperty { get; set; }

        //public int PersonId { get; set; }
        public ICollection<Persons> Persons { get; set; }
    }

    public class EstateValidator : AbstractValidator<Estate>
    {
        public EstateValidator()
        {
            RuleFor(x => x.CommonArea).NotNull();
            RuleFor(x => x.LivingArea).NotNull();
            RuleFor(x => x.Address).NotNull();
            RuleFor(x => x.TypeOfProperty).NotNull();
            RuleFor(x => x.StateOfProperty).NotNull();
        }
    }
}