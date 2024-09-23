﻿namespace APISuperMarket.DTOs
{
    public class ProfileUserDTO
    {
        public string? CustomerName { get; set; }
        public DateTime BirthDay { get; set; }
        public string? GenderName { get; set; }
        public IFormFile? ProfileImage { get; set; }
    }
}
