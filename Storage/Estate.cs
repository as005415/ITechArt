namespace Storage
{
    public class Estate
    {
        public int Id { get; set; }
        public int CommonArea { get; set; }
        public int LivingArea { get; set; }
        public string Address { get; set; }
        public string TypeOfProperty { get; set; }
        public string StateOfProperty { get; set; }
        
        public int PersonRequestId { get; set; }
        public PersonRequests PersonRequest { get; set; }
        
        public int PersonId { get; set; }
        public string PersonPassportId { get; set; }
        public Persons Person { get; set; }
    }
}