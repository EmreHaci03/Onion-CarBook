namespace CarBook.WebUI.Dtos.CommentDto
{
    public class ResultCommentDto
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
        public int BlogId { get; set; }
        public string BlogName { get; set; }
    }
}
