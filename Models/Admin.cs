using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCLSWebAPI.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string Address { get; set; }
        [ForeignKey("AdminType")]
        public int AdminTypeId { get; set; }
        public AdminType AdminType { get; set; }
    }
}
