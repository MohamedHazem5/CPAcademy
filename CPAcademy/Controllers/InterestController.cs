using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPAcademy.Controllers
{

    public class InterestController : BaseAPIController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InterestController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interest>>> Index()
        {
            var result = await _unitOfWork.Interest.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("Details/{Id}")]
        public async Task<ActionResult<Interest>> Details(int Id)
        {
            var interest = await _unitOfWork.Interest.GetFirstOrDefaultAsync(c => c.Id == Id);
            return Ok(interest);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddInterest(Interest interest)
        {
            if (!ModelState.IsValid)
                return BadRequest("THERE IS ERROR WHILE ADDING Event");
 
            await _unitOfWork.Interest.AddAsync(interest);
            await _unitOfWork.Save();
            return Ok(interest);
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> EditInterest(int id, Interest interest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("There are errors in the provided data.");
            }

            var existingInterest = await _unitOfWork.Interest.GetFirstOrDefaultAsync(c => c.Id == id);
            if (existingInterest == null)
            {
                return NotFound();
            }

            _unitOfWork.Interest.Update(existingInterest);
            await _unitOfWork.Save();

            return Ok(existingInterest);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteInterest(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("There are errors in the provided data.");

            var interest = await _unitOfWork.Interest.GetFirstOrDefaultAsync(c => c.Id == id);
            if (interest == null)
            {
                return NotFound();
            }
            _unitOfWork.Interest.Delete(interest);
            await _unitOfWork.Save();
            return Ok();
        }


        [HttpPost("AddInterest/userId={userId}&interestId={interestId}")]
        public async Task<IActionResult> AddInterestToUser(int userId, int interestId)
        {
            var user = await _unitOfWork.User.GetFirstOrDefaultAsync(u=>u.Id == userId);
            var interest = await _unitOfWork.Interest.GetFirstOrDefaultAsync(i=>i.Id== interestId);

            if (user == null || interest == null)
            {
                return NotFound();
            }

            var userInterest = new LearnerInterest { LearnerId = userId, InterstId = interestId };

            await _unitOfWork.LearnerInterest.AddAsync(userInterest);

            await _unitOfWork.Save();

            return Ok(userInterest);
        }


        [HttpDelete("RemoveInterest/userId={userId}/interestId={interestId}")]
        public async Task<IActionResult> RemoveInterestFromUser(int userId, int interestId)
        {
            var user = await _unitOfWork.User.GetFirstOrDefaultAsync(u => u.Id == userId);
            var interest = await _unitOfWork.Interest.GetFirstOrDefaultAsync(i => i.Id == interestId);

            if (user == null || interest == null)
            {
                return NotFound("Not Found User or Interest");
            }

            var userInterest = await _unitOfWork.LearnerInterest.GetFirstOrDefaultAsync(ui => ui.LearnerId == userId && ui.InterstId == interestId);

            if (userInterest == null)
            {
                return NotFound("Not found in UserInterest ");
            }

            _unitOfWork.LearnerInterest.Delete(userInterest);
            await _unitOfWork.Save();

            return Ok();
        }

    }
}
