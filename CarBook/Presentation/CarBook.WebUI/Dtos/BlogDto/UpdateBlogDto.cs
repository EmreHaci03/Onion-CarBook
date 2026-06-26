namespace CarBook.WebUI.Dtos.BlogDto
{
    public class UpdateBlogDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int BlogCategoryId { get; set; }
        public string BlogCategoryName { get; set; }
    }
}
