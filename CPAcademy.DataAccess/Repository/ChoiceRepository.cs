namespace CPAcademy.DataAccess.Repository.IRepository
{
    public class ChoiceRepository : Repository<Choice>, IChoiceRepository
    {
        public ChoiceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}