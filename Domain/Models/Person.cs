using System;
using System.Collections.Generic;
using FluentValidation;

namespace Domain.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public string PassportId { get; set; }
        public string AdministrativeUnit { get; set; }
        public string PhoneNumber { get; set; }
        public int FamilyComposition { get; set; }
        public Estate Estate { get; set; }
        public Norm Norm { get; set; }
        public ICollection<PersonRequest> PersonRequests { get; set; }
    }

    public class PersonsValidator : AbstractValidator<Person>
    {
        public PersonsValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.MiddleName).NotNull();
            RuleFor(x => x.Birthday).NotNull();
            RuleFor(x => x.PassportId).NotNull();
            RuleFor(x => x.AdministrativeUnit).NotNull();
            RuleFor(x => x.PhoneNumber).NotNull();
            RuleFor(x => x.FamilyComposition).NotNull();
        }
    }
}