namespace Domain.Models
{
    public class Queue
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public int PersonRequestsId { get; set; }
        public PersonRequest PersonRequests { get; set; }
    }
}