using System;
using System.Collections.Generic;

namespace WebApplication.Models.DbModels
{
    public class PersonRequests
    {
        public int Id { get; set; }
        public DateTime DateTimeOfRequest { get; set; }
        public StateOfRequest StateOfRequest { get; set; }
        //public ICollection<UsersPersonRequests> UsersPersonRequests { get; set; }
        public Persons Person { get; set; }
    }

    public enum StateOfRequest
    {
        Approved,
        Denied,
        InProgress,
        Finished
    }
}