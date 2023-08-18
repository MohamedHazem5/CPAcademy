namespace CPAcademy.Controllers
{
    public class SkillController : BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;

        public SkillController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> Index()
        {
            var result = await _unitOfWork.Skill.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Skill>> Index(int Id)
        {
            var result = await _unitOfWork.Skill.GetFirstOrDefaultAsync(c => c.Id == Id);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Skill>> AddSkill(string SkillName)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, obj = SkillName });

            var result = await _unitOfWork.Skill.AddAsync(new Skill { Name = SkillName });
            await _unitOfWork.Save();
            return Ok(result);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditSkill(Skill skill)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, obj = skill });

            _unitOfWork.Skill.Update(skill);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, obj = id });
            var skill = await _unitOfWork.Skill.GetFirstOrDefaultAsync(c => c.Id == id);
            if (skill == null)
                return NotFound();

            _unitOfWork.Skill.Delete(skill);
            await _unitOfWork.Save();
            return Ok();
        }


    }
}