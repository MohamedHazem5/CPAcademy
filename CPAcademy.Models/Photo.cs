﻿namespace CPAcademy.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
