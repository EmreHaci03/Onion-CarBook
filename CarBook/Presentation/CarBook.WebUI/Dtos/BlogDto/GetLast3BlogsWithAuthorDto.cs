namespace CarBook.WebUI.Dtos.BlogDto
{
    public class GetLast3BlogsWithAuthorDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string BlogCategoryName { get; set; }
        public int CommentCount { get; set; }
    }
}
