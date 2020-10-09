using FluentValidation;

namespace FirstProject.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FirstName).Length(2, 30).NotNull();
            RuleFor(x => x.LastName).Length(2, 30).NotNull();
            RuleFor(x => x.Email).EmailAddress().NotNull();
        }
    }
}