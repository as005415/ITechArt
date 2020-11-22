using System;
using System.Collections.Generic;

namespace Storage.Models
{
    public class PersonRequests
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public DateTime DateTimeOfRequest { get; set; }
        public StateOfRequest StateOfRequest { get; set; }
        public ICollection<UsersPersonRequests> UsersPersonRequests { get; set; }
        public Persons Person { get; set; }
    }

    public enum StateOfRequest
    {
        Approved,
        Denied,
        InProgress
    }
}