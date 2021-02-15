namespace Storage.Models
{
    public class UsersPersonRequests
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public UserModel UserModel { get; set; }
        
        public int PersonRequestId { get; set; }
        public PersonRequests PersonRequest { get; set; }
    }
}