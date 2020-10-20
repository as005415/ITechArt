﻿namespace Storage
{
    public class PropertyInfo
    {
        public int Id { get; set; }
        public int Area { get; set; }
        public string TypeOfProperty { get; set; }
        public string StateOfProperty { get; set; }
        
        public int PersonRequestId { get; set; }
        public PersonRequests PersonRequest { get; set; }
    }
}