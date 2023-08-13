using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CPAcademy.Models;
using CPAcademy.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CPAcademy.Controllers
{
    public class CourseController : BaseAPIController
    {
        public CourseController(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork,mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Index()
        {
            var courses = await _unitOfWork.Course.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CourseDto>> Index(int Id)
        {
            var courses = await _unitOfWork.Course.GetFirstOrDefaultAsync(c => c.Id == Id, c => c.Instructor, c => c.Category, c => c.Topic);
            var result = _mapper.Map<CourseDto>(courses);
            return Ok(result);
        }

        [HttpGet("Details/{Id}")]
        public async Task<ActionResult<Course>> Details(int Id)
        {
            var course = await _unitOfWork.Course.GetFirstOrDefaultAsync(c => c.Id == Id, c => c.Instructor,
                                                                         c => c.Category, c => c.Topic, c => c.Reviews);
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(CoursePostDto coursePostDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, course = coursePostDto });

            var course = _mapper.Map<Course>(coursePostDto);
            await _unitOfWork.Course.AddAsync(course);
            await _unitOfWork.Save();
            return Ok(course);
        }


    }
}