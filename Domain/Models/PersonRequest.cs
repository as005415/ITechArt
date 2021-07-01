using System;

namespace Domain.Models
{
    public class PersonRequest
    {
        public int Id { get; set; }
        public DateTime DateTimeOfRequest { get; set; }

        public StateOfRequest StateOfRequest { get; set; }

        //public ICollection<UsersPersonRequests> UsersPersonRequests { get; set; }
        public Person Person { get; set; }
    }

    public enum StateOfRequest
    {
        Approved,
        Denied,
        InProgress,
        Finished
    }
}