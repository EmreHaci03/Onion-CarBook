namespace CarBook.WebUI.Dtos.BlogDto
{
    public class CreateBlogDto
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int BlogCategoryId { get; set; }

    }
}
