using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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

/*        public async Task<IActionResult> Index(){
            var result = await _unitOfWork.Course.GetAllAsync();
            return Ok(result);
        }*/
    }
}