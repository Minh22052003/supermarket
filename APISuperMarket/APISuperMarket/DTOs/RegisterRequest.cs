namespace APISuperMarket.DTOs
{
    public class RegisterRequest
    {
        public bool IsGoogleRegistrantion { get; set; }
        public string? GoogleRegistrantToken { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Gmail { get; set; } 
    }
}
