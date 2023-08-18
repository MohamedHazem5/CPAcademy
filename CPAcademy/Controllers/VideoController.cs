using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CPAcademy.Controllers
{

    public class VideoController : BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VideoController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Video = await _unitOfWork.Video.GetFirstOrDefaultAsync(s => s.Id == id);
            if (Video == null)
                return NotFound();
            return Ok(Video);
        }
        [HttpGet("ByLecture/{id}")]
        public async Task<IActionResult> ByLecture(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Video = await _unitOfWork.Video.GetFirstOrDefaultAsync(s => s.LectureId == id);
            if (Video == null)
                return NotFound();

            return Ok(Video);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddVideo(VideoPostDto videoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { state = ModelState, Video = videoDto });
            var lecture = _mapper.Map<Video>(videoDto);
            await _unitOfWork.Video.AddAsync(lecture);
            await _unitOfWork.Save();
            return Ok(lecture);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditVideo(VideoPutDto videoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { modelState = ModelState, Video = videoDto });
            var video = _mapper.Map<Video>(videoDto);
            _unitOfWork.Video.Update(video);
            await _unitOfWork.Save();
            return Ok(video);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var video = await _unitOfWork.Video.GetFirstOrDefaultAsync(c => c.Id == id);
            if (video == null)
                return NotFound();
            _unitOfWork.Video.Delete(video);
            await _unitOfWork.Save();
            return Ok(video);
        }

    }
}