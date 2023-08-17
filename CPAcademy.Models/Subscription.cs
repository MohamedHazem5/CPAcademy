﻿namespace CPAcademy.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
        public int AccountId { get; set; }
        public User Account { get; set; }
    }
}
