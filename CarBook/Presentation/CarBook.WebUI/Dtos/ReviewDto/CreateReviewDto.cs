namespace CarBook.WebUI.Dtos.ReviewDto
{
    public class CreateReviewDto
    {
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
        public int CleanlinessRating { get; set; }
        public int ComfortRating { get; set; }
        public int PriceRating { get; set; }
        public int DeliveryRating { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
