using Blog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class CommentDto : BaseDto
    {
        public string Content { get; set; }
        public int likeCounter { get; set; }
        public int UserId { get; set; }
        public int BlogContentId { get; set; }
    }
}
