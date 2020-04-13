using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Models.PostViewModels
{
    public class PostEdit
    {
        public int PostID { get; set; }

        [Required, Display(Name = "Content")]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string PostContent { get; set; }
    }
}
