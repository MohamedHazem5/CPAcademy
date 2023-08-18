using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPAcademy.Models.DTOs
{
    public class SectionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CDate { get; set; } 
        public ICollection<Lecture> Lectures { get; set; }

    }
}