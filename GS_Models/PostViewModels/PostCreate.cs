using GS_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Models.PostViewModels
{
    public class PostCreate
    {
        public int ThreadID { get; set; }
        public virtual Thread Thread { get; set; }

        public string PostContent { get; set; }
    }
}
