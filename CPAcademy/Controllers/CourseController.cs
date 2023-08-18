namespace CPAcademy.Controllers
{
    public class CourseController : BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Index()
        {
            var courses = await _unitOfWork.Course.GetAllAsync(includeProperties: c => c.Reviews);
            var result = _mapper.Map<IEnumerable<CourseDto>>(courses);
            _unitOfWork.Course.AvrageRate(result);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CourseDto>> Index(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var course = await _unitOfWork.Course.GetFirstOrDefaultAsync(c => c.Id == Id, c => c.Instructor, c => c.Category, c => c.Topic);
            if (course == null)
                return NotFound();
            var result = _mapper.Map<CourseDto>(course);
            return Ok(result);
        }

        [HttpGet("ByCategory/{Id}")]
        public async Task<ActionResult> ByCategory(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var courses = await _unitOfWork.Course.GetAllAsync(c => c.CategoryId == Id);
            if (courses == null)
                return NotFound();
            return Ok(courses);
        }
        [HttpGet("ByTopic/{Id}")]
        public async Task<ActionResult> ByTopic(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var courses = await _unitOfWork.Course.GetAllAsync(c => c.TopicId == Id);
            if (courses == null)
                return NotFound();
            return Ok(courses);
        }
        [HttpGet("Details/{Id}")]
        public async Task<ActionResult<Course>> Details(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var course = await _unitOfWork.Course.GetFirstOrDefaultAsync(c => c.Id == Id, c => c.Instructor,
                                                                         c => c.Category, c => c.Topic, c => c.Reviews);
            if (course == null)
                return NotFound();
            return Ok(course);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCourse(CoursePostDto coursePostDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, course = coursePostDto });

            var course = _mapper.Map<Course>(coursePostDto);
            await _unitOfWork.Course.AddAsync(course);
            await _unitOfWork.Save();
            return Ok(course);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditCourse(Course course)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { modelState = ModelState, Course = course });
            _unitOfWork.Course.Update(course);
            await _unitOfWork.Save();
            return Ok(course);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var course = await _unitOfWork.Course.GetFirstOrDefaultAsync(c => c.Id == id);
            if (course == null)
                return NotFound();
            _unitOfWork.Course.Delete(course);
            await _unitOfWork.Save();
            return Ok(course);
        }

    }
}