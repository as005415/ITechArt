namespace Storage.Models
{
    public class Estate
    {
        public int Id { get; set; }
        public double CommonArea { get; set; }
        public double LivingArea { get; set; }
        public string Address { get; set; }
        public string TypeOfProperty { get; set; }
        public string StateOfProperty { get; set; }

        public int PersonId { get; set; }
        public Persons Person { get; set; }
    }
}