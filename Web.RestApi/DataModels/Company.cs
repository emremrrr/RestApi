using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web.RestApi
{
    public class Company
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [StringLength(255)]
        public string CompanyName { get; set; }

        public ICollection<Assignment> Assignment { get; set; }
    }
}
