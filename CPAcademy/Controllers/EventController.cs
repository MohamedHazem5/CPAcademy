namespace CPAcademy.Controllers
{

    public class EventController : BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EventController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> EditEvent(int id, EventDto eventDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("There are errors in the provided data.");
            }

            var existingEvent = await _unitOfWork.Event.GetFirstOrDefaultAsync(c => c.Id == id);
            if (existingEvent == null)
            {
                return NotFound();
            }

            _mapper.Map(eventDto, existingEvent); 
            _unitOfWork.Event.Update(existingEvent);
            await _unitOfWork.Save();

            return Ok(existingEvent); 
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
