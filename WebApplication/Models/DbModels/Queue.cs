namespace WebApplication.Models.DbModels
{
    public class Queue
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public int PersonRequestsId { get; set; }
        public PersonRequests PersonRequests { get; set; }
    }
}