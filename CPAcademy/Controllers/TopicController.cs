namespace CPAcademy.Controllers
{
    public class TopicController : BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;

        public TopicController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            var topic = await _unitOfWork.Topic.GetFirstOrDefaultAsync(c => c.Id == id);
            if (topic == null)
                return NotFound();

            _unitOfWork.Topic.Delete(topic);
            await _unitOfWork.Save();
            return Ok();
        }
    }
}