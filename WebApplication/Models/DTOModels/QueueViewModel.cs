using WebApplication.Models.DbModels;

namespace WebApplication.Models.DTOModels
{
    public class QueueViewModel
    {
        public int QueueId { get; set; }
        public int PersonRequestId { get; set; }
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PassportId { get; set; }
        public StateOfRequest StateOfRequest { get; set; }
    }
}