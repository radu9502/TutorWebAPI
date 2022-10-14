namespace TestAPIAuth.Data.Interfaces
{
    public interface IAuthentication
    {
        Task<IResult> Login(string userName, string password);
        Task<IResult> Register(string userName, string password, string email);
    }
}