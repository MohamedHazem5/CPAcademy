namespace CPAcademy.Controllers
{
    public class QuizController : BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuizController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Quiz = await _unitOfWork.Quiz.GetFirstOrDefaultAsync(s => s.Id == id);
            if (Quiz == null)
                return NotFound();
            return Ok(Quiz);
        }
        [HttpGet("ByLecture/{id}")]
        public async Task<IActionResult> ByLecture(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Quiz = await _unitOfWork.Quiz.GetFirstOrDefaultAsync(s => s.LectureId == id);
            if (Quiz == null)
                return NotFound();

            return Ok(Quiz);
        }
        [HttpPost("Add/{lectureId}")]
        public async Task<IActionResult> AddQuiz(int lectureId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState });
            var IsExisting = await _unitOfWork.Lecture.AnyAsync(l => l.Id == lectureId);
            if (!IsExisting)
            {
                return NotFound("Lecture Not Found");
            }
            var quiz = new Quiz { LectureId = lectureId };
            await _unitOfWork.Quiz.AddAsync(quiz);
            await _unitOfWork.Save();
            return Ok(quiz);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var quiz = await _unitOfWork.Quiz.GetFirstOrDefaultAsync(c => c.Id == id);
            if (quiz == null)
                return NotFound();
            _unitOfWork.Quiz.Delete(quiz);
            await _unitOfWork.Save();
            return Ok(quiz);
        }
    }
}