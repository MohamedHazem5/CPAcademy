using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPAcademy.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPAcademy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                return BadRequest(new { state = ModelState, course = categoryName });

            var result = await _unitOfWork.Category.AddAsync(new Category { Name = categoryName });
            await _unitOfWork.Save();
            return Ok(result);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditCategory(Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, course = category });

            _unitOfWork.Category.Update(category);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, course = id });
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