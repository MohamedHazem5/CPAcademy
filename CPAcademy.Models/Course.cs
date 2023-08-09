using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPAcademy.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string VideoUrl { get; set; }
        [Range(0, 5)]
        public int SkillLevel { get; set; }
        public DateTime Duration { get; set; }
        public double Price { get; set; }
        public double ListPrice { get; set; }
        public DateTime CDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public int InstructorId { get; set; }
        public User Instructor { get; set; }



    }
}
