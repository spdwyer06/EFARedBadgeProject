using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Models.Review
{
    public class ReviewEdit
    {
        public int ReviewID { get; set; }

        public string GameTitle { get; set; }
        public virtual GS_Data.Game Game { get; set; }

        [Range(1,5)]
        public int ReviewRating { get; set; }

        public string ReviewDescription { get; set; }
    }
}
