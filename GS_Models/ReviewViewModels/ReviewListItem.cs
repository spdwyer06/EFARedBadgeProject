using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Models.ReviewViewModels
{
    public class ReviewListItem
    {
        public int ReviewID { get; set; }

        public string GameTitle { get; set; }
        public virtual GS_Data.Game Game { get; set; }

        public int ReviewRating { get; set; }

        public string ReviewDescription { get; set; }

    }
}
