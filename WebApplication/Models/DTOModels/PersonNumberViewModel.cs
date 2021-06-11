using WebApplication.Models.DbModels;

namespace WebApplication.Models.DTOModels
{
    public class PersonNumberViewModel
    {
        public int Number { get; set; }
        public string StateOfRequest { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PassportId { get; set; }
    }
}