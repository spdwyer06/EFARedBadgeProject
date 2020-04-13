using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Data
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        [ForeignKey("Thread")]
        public int ThreadID { get; set; }
        public virtual Thread Thread { get; set; }

        [Required, Display(Name = "Created By")]
        public Guid PostCreator { get; set; }

        [Required, Display(Name = "Content")]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string PostContent { get; set; }

        [Required, Display(Name = "Created")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTimeOffset PostCreated { get; set; }

        public virtual ICollection<PostReply> Replies { get; set; }
    }
}
