using CarBook.WebUI.Dtos.BlogDto;

namespace CarBook.WebUI.Dtos.GetAllStatisticsDto
{
    public class GetAllStatisticDto
    {
        ////////////////////////
        public int CarCount { get; set; }

        ////////////////////////
        public string LastBlogName { get; set; }
        public string LastBlogAuthor { get; set; }

        ////////////////////////
        public string OldestCarBrandName { get; set; }
        public string OldestCarModel { get; set; }

        ////////////////////////
        
        public string NewestCarBrandName { get; set; }
        public string NewestCarModel { get; set; }


        ////////////////////////  
        
        public string MostCommentedBlogTitle { get; set; }
        public int MostCommentedBlogCommentCount { get; set; }
    


        ///////////////////////


        public string MostCarBrandName { get; set; }
        public int MostCarCount { get; set; }


        ////////////////////////
       
        public string HighestCarMileage { get; set; }
        public int MileageValue {  get; set; }



        /////////////////////////



        public string MostUsedFuelType { get; set; }
        public int FuelTypeCount { get; set; }
        /////////////////////////

        public string CarNameWithBrand { get; set; }
        public int CheapestCarPriceDay { get; set; }

        /////////////////////////

        public string HighestPriceCar { get; set; }
        public int HighestCarDailyPrice { get; set; }




        //////////////////////////
        
        public int GetReservationCount {  get; set; }


        /// ///////////////////////

        public int ManualCarCount { get; set; }
        public int AutomaticCarCount { get; set; }


        public Dictionary<string, int> CarFuelType { get; set; }



        public List<ResultBlogDto> Blogs { get; set; }




    }
}
