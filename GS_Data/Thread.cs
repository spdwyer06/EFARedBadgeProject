using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Data
{
    public class Thread
    {
        [Key]
        public int ThreadID { get; set; }

        [Required, Display(Name = "Creator ID")]
        public Guid ThreadCreator { get; set; }

        [Required, Display(Name = "Created By")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string CreatorDisplayName { get; set; }

        [Required, Display(Name = "Title")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string ThreadTitle { get; set; }

        [Display(Name = "Description")]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string ThreadDescription { get; set; }

        [Required, Display(Name = "Created")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTimeOffset ThreadCreated { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
