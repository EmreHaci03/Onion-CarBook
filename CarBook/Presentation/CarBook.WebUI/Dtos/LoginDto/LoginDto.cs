namespace CarBook.WebUI.Dtos
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class TokenResponseDto
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}