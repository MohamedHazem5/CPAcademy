namespace CPAcademy.Services.IServices
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);

        string DataFromToken(string token, Func<Claim, bool> selector);
    }
}