using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPAcademy.Models.DTOs
{
    public class VideoPutDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int LectureId { get; set; }

    }
}