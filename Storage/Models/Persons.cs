using System;
using System.Collections.Generic;

namespace Storage.Models
{
    public class Persons
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
        
        public ICollection<Estate> Estates { get; set; }
        public Norm Norm { get; set; }
    }
}