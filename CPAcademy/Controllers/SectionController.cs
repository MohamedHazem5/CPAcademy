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

    public class SectionController : BaseAPIController
    {
        public SectionController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> index(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Section = await _unitOfWork.Section.GetFirstOrDefaultAsync(s => s.Id == id, s => s.Lectures);
            if (Section == null)
                return NotFound();
            return Ok(Section);
        }
        [HttpGet("ByCourse/{id}")]
        public async Task<IActionResult> ByCourse(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Sections = await _unitOfWork.Section.GetAllAsync(s => s.CourseId == id);
            if (Sections == null)
                return NotFound();

            return Ok(Sections);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddSection(SectionPostDto sectionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, section = sectionDto });
            var section = _mapper.Map<Section>(sectionDto);
            await _unitOfWork.Section.AddAsync(section);
            await _unitOfWork.Save();
            return Ok(section);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditSection(SectionPutDto sectionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { modelState = ModelState, Section = sectionDto });
            var section = await _unitOfWork.Section.GetFirstOrDefaultAsync(s => s.Id == sectionDto.Id);
            section.Title = sectionDto.Title;
            _unitOfWork.Section.Update(section);
            await _unitOfWork.Save();
            return Ok(section);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var section = await _unitOfWork.Section.GetFirstOrDefaultAsync(c => c.Id == id);
            if (section == null)
                return NotFound();
            _unitOfWork.Section.Delete(section);
            await _unitOfWork.Save();
            return Ok(section);
        }


    }
}