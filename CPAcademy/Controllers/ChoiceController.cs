using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CPAcademy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoiceController : BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChoiceController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var choice = await _unitOfWork.Choice.GetFirstOrDefaultAsync(s => s.Id == id);
            if (choice == null)
                return NotFound();
            return Ok(choice);
        }
        [HttpGet("ByQuestion/{id}")]
        public async Task<IActionResult> ByQuestion(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var choices = await _unitOfWork.Choice.GetAllAsync(s => s.QuestionId == id);
            if (choices == null)
                return NotFound();

            return Ok(choices);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddChoice(ChoicePostDto choiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, Choice = choiceDto });
            var choice = _mapper.Map<Choice>(choiceDto);
            _unitOfWork.Choice.Update(choice);
            await _unitOfWork.Save();
            return Ok(choice);
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> EditChoice(ChoicePutDto choiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { modelState = ModelState, Question = choiceDto });
            var choice = _mapper.Map<Choice>(choiceDto);
            _unitOfWork.Choice.Update(choice);
            await _unitOfWork.Save();
            return Ok(choice);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteChoice(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var choice = await _unitOfWork.Choice.GetFirstOrDefaultAsync(c => c.Id == id);
            if (choice == null)
                return NotFound();
            _unitOfWork.Choice.Delete(choice);
            await _unitOfWork.Save();
            return Ok(choice);
        }
    }
}