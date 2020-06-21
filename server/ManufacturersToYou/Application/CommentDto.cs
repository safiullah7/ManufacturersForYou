using System;

namespace Application
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}