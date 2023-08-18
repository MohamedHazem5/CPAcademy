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
        public async Task<IActionResult> Index(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Lecture = await _unitOfWork.Lecture.GetFirstOrDefaultAsync(s => s.Id == id);
            if (Lecture == null)
                return NotFound();
            return Ok(Lecture);
        }
        [HttpGet("BySection/{id}")]
        public async Task<IActionResult> BySection(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Sections = await _unitOfWork.Lecture.GetAllAsync(s => s.SectionId == id);
            if (Sections == null)
                return NotFound();

            return Ok(Sections);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddLecture(LecturePostDto lectureDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, lecture = lectureDto });
            var lecture = _mapper.Map<Lecture>(lectureDto);
            lecture.Time = TimeSpan.FromSeconds(lectureDto.Time); // int to TimeSpan 
            await _unitOfWork.Lecture.AddAsync(lecture);
            await _unitOfWork.Save();
            return Ok(lecture);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditLecture(LecturePutDto lectureDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { modelState = ModelState, Lecture = lectureDto });
            var lecture = _mapper.Map<Lecture>(lectureDto);
            lecture.Time = TimeSpan.FromSeconds(lectureDto.Time); // int to TimeSpan 
            _unitOfWork.Lecture.Update(lecture);
            await _unitOfWork.Save();
            return Ok(lecture);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteLecture(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var lecture = await _unitOfWork.Lecture.GetFirstOrDefaultAsync(c => c.Id == id);
            if (lecture == null)
                return NotFound();
            _unitOfWork.Lecture.Delete(lecture);
            await _unitOfWork.Save();
            return Ok(lecture);
        }
    }
}