using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPAcademy.Models.DTOs
{
    public class LecturePutDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Time { get; set; }
        public int Points { get; set; }
        public int Order { get; set; } // Just for Ordering
        public int SectionId { get; set; }
    }
}