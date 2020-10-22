namespace Storage
{
    public class PropertyInfo
    {
        public int Id { get; set; }
        public int Area { get; set; }
        public string TypeOfProperty { get; set; }
        public string StateOfProperty { get; set; }
        
        public int PersonRequestId { get; set; }
        public PersonRequests PersonRequest { get; set; }
        
        public int PersonId { get; set; }
        public string PersonPassportId { get; set; }
        public Persons Person { get; set; }
    }
}