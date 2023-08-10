namespace CPAcademy.DataAccess.Repository.IRepository
{
    public class MailRepository : Repository<Mail>, IMailRepository
    {
        public MailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}