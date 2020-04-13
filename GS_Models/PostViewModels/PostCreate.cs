using GS_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Models.PostViewModels
{
    public class PostCreate
    {
        [ForeignKey("Thread")]
        public int ThreadID { get; set; }
        public virtual Thread Thread { get; set; }

        [Required, Display(Name = "Content")]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string PostContent { get; set; }
    }
}
