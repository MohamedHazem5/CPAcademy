using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CPAcademy.Controllers
{
    public class ArticleController : BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var article = await _unitOfWork.Article.GetFirstOrDefaultAsync(s => s.Id == id);
            if (article == null)
                return NotFound();
            return Ok(article);
        }
        [HttpGet("ByLecture/{id}")]
        public async Task<IActionResult> ByLecture(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var article = await _unitOfWork.Article.GetFirstOrDefaultAsync(s => s.LectureId == id);
            if (article == null)
                return NotFound();

            return Ok(article);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddArticle(ArticlePostDto articleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, Article = articleDto });
            var article = _mapper.Map<Article>(articleDto);
            await _unitOfWork.Article.AddAsync(article);
            await _unitOfWork.Save();
            return Ok(article);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditArticle(ArticlePutDto articleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { modelState = ModelState, Article = articleDto });
            var article = _mapper.Map<Article>(articleDto);
            _unitOfWork.Article.Update(article);
            await _unitOfWork.Save();
            return Ok(article);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var article = await _unitOfWork.Article.GetFirstOrDefaultAsync(c => c.Id == id);
            if (article == null)
                return NotFound();
            _unitOfWork.Article.Delete(article);
            await _unitOfWork.Save();
            return Ok(article);
        }

    }
}