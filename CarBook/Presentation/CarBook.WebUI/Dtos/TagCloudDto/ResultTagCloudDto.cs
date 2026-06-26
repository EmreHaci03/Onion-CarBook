using System.Reflection.Metadata;

namespace CarBook.WebUI.Dtos.TagCloudDto
{
    public class ResultTagCloudDto
    {
        public int TagCloudId { get; set; }
        public string TagCloudName { get; set; }
        public int BlogId { get; set; }
        public string BlogName { get; set; }
    }
}
