namespace CarBook.WebUI.Dtos.CarDescriptionDto
{
    public class ResultCarDescriptionDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public string MainImageUrl { get; set; }
        public string DetailDescription { get; set; }
    }
}

