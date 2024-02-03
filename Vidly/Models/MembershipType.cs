using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }        
    }
}