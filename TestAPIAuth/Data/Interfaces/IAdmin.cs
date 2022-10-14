namespace TestAPIAuth.Data.Interfaces
{
    public interface IAdmin
    {
        Task<IResult> DeleteCategoryById(int id);
        Task<IResult> DeleteRequestById(int id);
        Task<IResult> DeleteSubCategoryById(int id);
        Task<IResult> DeleteUserById(int id);
        Task<IResult> GetCategories();
        Task<IResult> GetCategoryById(int id);
        Task<IResult> GetSubCategories();
        Task<IResult> GetSubCategoryById(int id);
        Task<IResult> GetUserById(int id, string authorization);
        Task<IResult> GetUsers();
    }
}