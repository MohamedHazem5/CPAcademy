
using CPAcademy.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPAcademy.Controllers
{
    public class CategoryController : BaseAPIController
    {
        public CategoryController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Index()
        {
            var result = await _unitOfWork.Category.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Category>> Index(int Id)
        {
            var result = await _unitOfWork.Category.GetFirstOrDefaultAsync(c => c.Id == Id);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Category>> AddCategory(string categoryName)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, obj = categoryName });

            var result = await _unitOfWork.Category.AddAsync(new Category { Name = categoryName });
            await _unitOfWork.Save();
            return Ok(result);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditCategory(Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, obj = category });

            _unitOfWork.Category.Update(category);
            await _unitOfWork.Save();
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, obj = id });
            var category = await _unitOfWork.Category.GetFirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Delete(category);
            await _unitOfWork.Save();
            return Ok();
        }
    }
}