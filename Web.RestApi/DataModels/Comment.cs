using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.RestApi
{
    public class Comment
    {
        [Key]
        public long ID { get; set; }

        [Required]
        public long UserID { get; set; }

        [Required]
        [StringLength(255)]
        public string CommentText { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }

        public Assignment Assignment { get; set; }
    }
}
