namespace CPAcademy.Controllers
{
    public class BlogController : BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlogController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> Index()
        {
            var result = await _unitOfWork.Blog.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("Details/{Id}")]
        public async Task<ActionResult<Blog>> Details(int Id)
        {
            var blog = await _unitOfWork.Blog.GetFirstOrDefaultAsync(c => c.Id == Id);
            return Ok(blog);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddBlog(BlogDto blogDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("THERE IS ERROR WHILE ADDING BLOG");

            var result= await _unitOfWork.Blog.AddAsync(
                new Blog
                {
                    Title = blogDto.Title,
                    Content = blogDto.Content,
                    CDate = blogDto.CDate,
                    ImageUrl = blogDto.ImageUrl,
                    AdminId = blogDto.AdminId,
                });
            await _unitOfWork.Save();
            return Ok(result);
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> EditBlog(int id, BlogDto blogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("There are errors in the provided data.");
            }

            var existingBlog = await _unitOfWork.Blog.GetFirstOrDefaultAsync(c => c.Id == id);
            if (existingBlog == null)
            {
                return NotFound();
            }

            _mapper.Map(blogDto, existingBlog);
            _unitOfWork.Blog.Update(existingBlog);
            await _unitOfWork.Save();

            return Ok(existingBlog);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("THERE IS ERROR WHILE ADDING BLOG");
            var blog = await _unitOfWork.Blog.GetFirstOrDefaultAsync(c => c.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            _unitOfWork.Blog.Delete(blog);
            await _unitOfWork.Save();
            return Ok();
        }


    }
}