using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCLSWebAPI.Models
{
    [Table("AdminType")]
    public class AdminType
    {
        [Key]
        public int AdminTypeId { get; set; }
        public string AdminTypeName { get; set; }
        public ICollection<Admin> Admins { get; set; }
    }
}
