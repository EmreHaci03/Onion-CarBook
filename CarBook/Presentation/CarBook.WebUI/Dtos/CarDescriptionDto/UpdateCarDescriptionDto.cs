namespace CarBook.WebUI.Dtos.CarDescriptionDto
{
    public class UpdateCarDescriptionDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string DetailDescription { get; set; }
    }
}
