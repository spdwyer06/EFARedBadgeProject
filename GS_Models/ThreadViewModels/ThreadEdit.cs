using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Models.ThreadViewModels
{
    public class ThreadEdit
    {
        public int ThreadID { get; set; }

        [Required, Display(Name = "Title")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string ThreadTitle { get; set; }

        [Display(Name = "Description")]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string ThreadDescription { get; set; }
    }
}
