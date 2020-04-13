using GS_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Models.PostReplyViewModels
{
    public class PostReplyCreate
    {
        [ForeignKey("Post")]
        public int PostID { get; set; }
        public virtual Post Post { get; set; }

        [Required, Display(Name = "Content")]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string ReplyContent { get; set; }
    }
}
