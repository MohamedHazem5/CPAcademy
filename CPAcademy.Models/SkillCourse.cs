using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPAcademy.Models
{
    public class SkillCourse
    {
        public int Id { get; set; }
        public int SkillsId { get; set; }
        public Skill Skill { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
