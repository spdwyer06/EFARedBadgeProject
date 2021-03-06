﻿using GS_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Models.PostViewModels
{
    public class PostDetail
    {
        public int PostID { get; set; }

        [ForeignKey("Thread")]
        public int ThreadID { get; set; }
        public virtual Thread Thread { get; set; }

        //[Required, Display(Name = "Created By")]
        //public Guid PostCreator { get; set; }

        [Required, Display(Name = "Created By")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string CreatorDisplayName { get; set; }

        [Required, Display(Name = "Content")]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string PostContent { get; set; }

        [Required, Display(Name = "Created")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTimeOffset PostCreated { get; set; }

        [Display(Name = "Number of Replies")]
        public int NumberOfReplies
        {
            get
            {
                if (Replies != null)
                    return Replies.Count();

                return 0;
            }
        }


        public virtual IEnumerable<PostReply> Replies { get; set; }
    }
}
