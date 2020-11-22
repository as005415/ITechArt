using System;

namespace Storage.Models
{
    public class Norm
    {
        public int Id { get; set; }
        public string AdministrativeUnit { get; set; }
        public float Value { get; set; }
        public float NewValue { get; set; }
        public DateTime DateNewValueApply { get; set; }
    }
}