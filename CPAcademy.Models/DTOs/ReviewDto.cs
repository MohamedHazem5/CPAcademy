using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPAcademy.Models.DTOs
{
    public class ReviewDto
    {
        public double Rate { get; set; }
        public string Comment { get; set; }
        public int CourseId { get; set; }
        public int LearnerId { get; set; }
    }
}
