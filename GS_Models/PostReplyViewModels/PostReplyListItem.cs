﻿using GS_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Models.PostReplyViewModels
{
    public class PostReplyListItem
    {
        public int ReplyID { get; set; }

        public int PostID { get; set; }
        public virtual Post Post { get; set; }

        public string ReplyContent { get; set; }

        public Guid ReplyCreator { get; set; }

        public DateTimeOffset ReplyCreated { get; set; }
    }
}