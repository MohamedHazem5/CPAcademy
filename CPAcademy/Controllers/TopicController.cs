using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPAcademy.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPAcademy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : BaseAPIController
    {
        public TopicController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topic>>> Index()
        {
            var result = await _unitOfWork.Topic.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Topic>> Index(int Id)
        {
            var result = await _unitOfWork.Topic.GetFirstOrDefaultAsync(c => c.Id == Id);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Topic>> AddTopic(string topicName)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, obj = topicName });

            var result = await _unitOfWork.Topic.AddAsync(new Topic { Name = topicName });
            await _unitOfWork.Save();
            return Ok(result);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditTopic(Topic topic)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, obj = topic });

            _unitOfWork.Topic.Update(topic);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, obj = id });
            var category = await _unitOfWork.Topic.GetFirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
                return NotFound();

            _unitOfWork.Topic.Delete(category);
            await _unitOfWork.Save();
            return Ok();
        }
    }
}