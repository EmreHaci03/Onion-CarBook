namespace CarBook.WebUI.Dtos.RentACarDto
{
    public class GetRentACarListDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string CarImageUrl { get; set; }
    }
}
