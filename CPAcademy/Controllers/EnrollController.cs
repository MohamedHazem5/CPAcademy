using CPAcademy.Models;
using CPAcademy.Models.DTO;
using Stripe.Checkout;

namespace CPAcademy.Controllers
{

    public class EnrollController : BaseAPIController
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public EnrollController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetEnrollCoursesByUser")]
        public async Task<IActionResult> GetEnrollCoursesByUser(int id)
        {
            var user = await _unitOfWork.Enroll.GetAllAsync(x => x.LearnerId == id, c => c.Course);

            return Ok(user);
        }
        [HttpGet("GetOrderByUser")]
        public async Task<IActionResult> GetOrderByUser(int id)
        {
            var user = await _unitOfWork.Order.GetAllAsync(x => x.UserId == id, c => c.Course);

            return Ok(user);
        }
/*        [HttpPost("BuyOrEnrollCourse")]
        public async Task<IActionResult> BuyOrEnrollCourse(EnrollDto enrollDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the learner is already enrolled in the course
            bool isEnrolled = await _unitOfWork.Enroll
                .AnyAsync(e => e.LearnerId == enrollDto.LearnerId && e.CourseId == enrollDto.CourseId);

            if (!isEnrolled)
            {
                var paymentSuccess = await ProcessStripePayment(enrollDto.LearnerId, enrollDto.CourseId);

                if (paymentSuccess==false)
                {
                    return BadRequest("Payment failed. Please try again.");
                }
            }

            var enrollment = _mapper.Map<Enroll>(enrollDto);

            enrollment.LearnerId = enrollDto.LearnerId;
            enrollment.CourseId = enrollDto.CourseId;

            // Add the enrollment to the database
            await _unitOfWork.Enroll.AddAsync(enrollment);

            // Commit the changes to the database
            await _unitOfWork.Save();

            // Return a success response
            return Ok("Enrollment created successfully.");
        }*/


        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        {
            bool flag = await _unitOfWork.Enroll.CheckCourse(orderDto.CourseId, orderDto.UserId);

            if (flag)
            {
                return BadRequest("User Already bought the course");
            }
            var order = await _unitOfWork.Order.CreateOrder(orderDto);

            var result = new Enroll
            {
                CourseId = orderDto.CourseId,
                LearnerId = orderDto.UserId,
            };

            var course = await _unitOfWork.Course.GetFirstOrDefaultAsync(x => x.Id == orderDto.CourseId);

            await _unitOfWork.Enroll.AddAsync(result);

            await _unitOfWork.Save();


            //stripe settings
            var domain = "http://127.0.0.1:5500/test.html";
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                  "card",
                },
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain + $"/suck.html",
                CancelUrl = domain + $"/fool.html",
            };

            var sessionLineItem = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(order.Price * 100),//20.00 -> 2000
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = course.Title,
                        
                    },
                },
                Quantity = 1,
            };
            options.LineItems.Add(sessionLineItem);


            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);

        }




    }
}
