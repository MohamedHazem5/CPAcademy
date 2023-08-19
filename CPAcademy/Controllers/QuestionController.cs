using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CPAcademy.Controllers
{

    public class QuestionController : BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Question = await _unitOfWork.Question.GetFirstOrDefaultAsync(s => s.Id == id);
            if (Question == null)
                return NotFound();
            return Ok(Question);
        }
        [HttpGet("ByQuiz/{id}")]
        public async Task<IActionResult> ByQuiz(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Questions = await _unitOfWork.Question.GetAllAsync(s => s.QuizId == id);
            if (Questions == null)
                return NotFound();

            return Ok(Questions);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddQuestion(QuestionPostDto questionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, Question = questionDto });
            var question = await _unitOfWork.Question.AddAsync(_mapper.Map<Question>(questionDto));
            await _unitOfWork.Save();
            return Ok(question);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditQuestion(QuestionPutDto questionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { modelState = ModelState, Question = questionDto });
            var question = _mapper.Map<Question>(questionDto);
            _unitOfWork.Question.Update(question);
            await _unitOfWork.Save();
            return Ok(question);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var question = await _unitOfWork.Question.GetFirstOrDefaultAsync(c => c.Id == id);
            if (question == null)
                return NotFound();
            _unitOfWork.Question.Delete(question);
            await _unitOfWork.Save();
            return Ok(question);
        }
    }
}