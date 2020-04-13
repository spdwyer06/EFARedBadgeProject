using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Models.ReviewViewModels
{
    public class ReviewCreate
    {
        public int GameID { get; set; }
        public virtual GS_Data.Game Game { get; set; }

        [Range(1, 5)]
        public int ReviewRating { get; set; }

        public string ReviewDescription { get; set; }

    }
}
