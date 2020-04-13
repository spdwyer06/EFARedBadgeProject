using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Data
{
    public class PostReply
    {
        [Key]
        public int ReplyID { get; set; }

        [ForeignKey("Post")]
        public int PostID { get; set; }
        public virtual Post Post { get; set; }

        [Required, Display(Name = "Creator ID")]
        public Guid ReplyCreator { get; set; }

        [Required, Display(Name = "Created By")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string CreatorDisplayName { get; set; }

        [Required, Display(Name = "Content")]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string ReplyContent { get; set; }

        [Required, Display(Name = "Created")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTimeOffset ReplyCreated { get; set; }
    }
}
