namespace CPAcademy.Services.IServices
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
