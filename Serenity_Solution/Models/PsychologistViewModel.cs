﻿namespace Serenity_Solution.Models
{
    public class PsychologistViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string? Degree { get; set; }
        public string? Description { get; set; }
        public string Experience { get; set; }
        public decimal Price { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public IFormFile? ProfilePictureFile { get; set; }
        /*
         [Required]
        public string Degree { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
         */
    }
}
