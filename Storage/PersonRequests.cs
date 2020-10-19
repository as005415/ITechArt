using System;
using System.Collections.Generic;

namespace Storage
{
    public class PersonRequests
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string MaritalStatus { get; set; }
        public string PassportId { get; set; }
        public string PhoneNumber { get; set; }
        public int FamilyComposition { get; set; }
        public int PropertyInfo { get; set; }
        public DateTime DateTimeOfRequest { get; set; }
        public StateOfRequest StateOfRequest { get; set; }
        
        public ICollection<PropertyInfo> PropertyInfos { get; set; }
        public ICollection<UsersPersonRequests> UsersPersonRequests { get; set; }
    }

    public enum StateOfRequest
    {
        Approved,
        Denied,
        InProgress
    }
}