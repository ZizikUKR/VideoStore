using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public bool IsSubscribedToNewsLater { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name ="Birthday")]
        [if18YearsOlder]
        public string CustomerBirthday { get; set; }
        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }
        
        public byte MembershipTypeId { get; set; }

        
    }
}