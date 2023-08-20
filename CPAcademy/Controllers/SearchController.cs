namespace CPAcademy.Controllers
{

    public class SearchController : BaseAPIController
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("ByKeyword")]
        public async Task<ActionResult> ByKeyword(string name) 
        {
            var courses =await _unitOfWork.Course.GetAllAsync(c=>c.Title.ToLower().Contains(name.ToLower()) || c.About.ToLower()
            .Contains(name.ToLower()));

            return courses == null? NotFound() : Ok(courses);
        }

        [HttpGet("ByCategoryName")]
        public async Task<ActionResult> ByCategoryName(string categoryName)
        {
            var categories = await _unitOfWork.Category.GetAllAsync(c => c.Name.ToLower().Contains(categoryName.ToLower()));

            var courses = await _unitOfWork.Course.GetAllAsync();

            var coursesForMatchingCategories = courses.Where(course =>
                    categories.Any(category => category.Id == course.CategoryId));

            return courses == null ? NotFound() : Ok(courses);
        }

        [HttpGet("ByTopicName")]
        public async Task<ActionResult> ByTopicName(string TopicName)
        {
            var topics = await _unitOfWork.Category.GetAllAsync(c => c.Name.ToLower().Contains(TopicName.ToLower()));

            var courses = await _unitOfWork.Course.GetAllAsync();

            var coursesForMatchingCategories = courses.Where(course =>
                    topics.Any(topic => topic.Id == course.TopicId));

            return courses == null ? NotFound() : Ok(courses);
        }



    }
}
