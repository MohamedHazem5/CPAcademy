using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPAcademy.Models.DTOs
{
    public class SectionPostDto
    {
        public string Title { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
        public int CourseId { get; set; }


    }
}