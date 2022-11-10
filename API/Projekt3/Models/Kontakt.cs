using System.ComponentModel.DataAnnotations;

namespace Projekt3.Models
{
    public class Kontakt
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Tag { get; set; }
    }
}

        
    