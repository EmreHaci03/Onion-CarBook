namespace CarBook.WebUI.Dtos.CarFeatureDto
{
    public class GetCarFeatureByCarIdDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public bool Avaliable { get; set; }
    }
}
