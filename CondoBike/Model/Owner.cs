using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CondoBike.Model
{
    public class Owner
    {
        public int OwnerID {get ; set;}
        [Required]
        public Residence OwnerResidence {get ; set;}
    
        [StringLength(11, ErrorMessage = "Identifier too long (11 characters limit)")]
        [Required]
        public string OwnerCPF {get ; set;}
        [Required]
        public List<Contact> OwnerContact { get; set; } = new List<Contact>();
        public List<Bicycle> OwnerBicycle { get ; set; } = new List<Bicycle>();
        
    }

    public class Contact 
    {
        public int ContactID {get; set;}
        public string ContactTelefone {get; set;}

    }

    public struct Residence {
        public int Apartment {get ; set; }
        public int Block {get ; set; }
        public Residence(int ap,int block)
        {
            Apartment = ap; 
            Block = block;
        }
    }
}