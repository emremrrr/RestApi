using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web.RestApi
{
    public class Assignment
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [StringLength(150)]
        public string TaskTitle { get; set; }

        [Required]
        public long AssingTo { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime TaskCreatedDate { get; set; }


        public System.Nullable<DateTime> TaskClosedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public AssignmentStatus AssignmentStatus { get; set; }

        public Company Company { get; set; }
        public ICollection<Comment> Comment{ get; set; }
    }
}
