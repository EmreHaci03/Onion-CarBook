using System.ComponentModel.DataAnnotations;

namespace CarBook.WebUI.Dtos.AboutDto
{
    public class CreateAboutDto
    {
        [Required(ErrorMessage = "Başlık boş olamaz.")]
        [MaxLength(200, ErrorMessage = "Başlık 200 karakterden fazla olamaz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama boş olamaz.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Resim URL boş olamaz.")]
        public string ImageUrl { get; set; }
    }
}
