using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }               

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}