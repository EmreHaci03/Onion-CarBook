namespace CarBook.WebUI.Dtos.AuthorDto
{
    public class UpdateAuthorDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
