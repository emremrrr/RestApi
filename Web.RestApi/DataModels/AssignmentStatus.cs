using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.RestApi
{
    public class AssignmentStatus
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string AssignmentStatusDisplayName { get; set; }

        public ICollection<Assignment> Assignment { get; set; }
    }
}
