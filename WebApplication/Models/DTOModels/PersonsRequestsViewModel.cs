using System;
using WebApplication.Models.DbModels;

namespace WebApplication.Models.DTOModels
{
    public class PersonsRequestsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PassportId { get; set; }
        public DateTime DateTimeOfRequest { get; set; }
        public StateOfRequest StateOfRequest { get; set; }
    }
}