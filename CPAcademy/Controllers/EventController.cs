﻿using AutoMapper;
using CPAcademy.Models;
using CPAcademy.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace CPAcademy.Controllers
{

    public class EventController : BaseAPIController
    {
        public EventController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Index()
        {
            var result = await _unitOfWork.Event.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("Details/{Id}")]
        public async Task<ActionResult<Event>> Details(int Id)
        {
            var result = await _unitOfWork.Event.GetFirstOrDefaultAsync(c => c.Id == Id);
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddEvent(EventDto eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("THERE IS ERROR WHILE ADDING Event");

            var result = _mapper.Map<Event>(eventDto);
            await _unitOfWork.Event.AddAsync(result);
            await _unitOfWork.Save();
            return Ok(result);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditEvent(EventDto eventdto)
        {
            if (!ModelState.IsValid)
                return BadRequest("THERE IS ERROR WHILE ADDING Event");

            var result = _mapper.Map<Event>(eventdto);
            _unitOfWork.Event.Update(result);
            await _unitOfWork.Save();
            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("THERE IS ERROR WHILE ADDING Event");

            var result =await _unitOfWork.Event.GetFirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Event.Delete(result);
            await _unitOfWork.Save();
            return Ok(result);
        }




    }
}
