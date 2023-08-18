namespace CPAcademy.Controllers
{
    public class LectureController : BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LectureController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> index(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Lecture = await _unitOfWork.Lecture.GetFirstOrDefaultAsync(s => s.Id == id);
            if (Lecture == null)
                return NotFound();
            return Ok(Lecture);
        }
        [HttpGet("BySection/{id}")]
        public async Task<IActionResult> ByCourse(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Sections = await _unitOfWork.Lecture.GetAllAsync(s => s.SectionId == id);
            if (Sections == null)
                return NotFound();

            return Ok(Sections);
        }
    }
}