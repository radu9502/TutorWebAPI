using TestAPIAuth.Models;

namespace TestAPIAuth.Data.Interfaces
{
    public interface IRequests
    {
        Task<IResult> CreateRequest(Request request, string authorization, bool ModelState);
        Task<IResult> DeleteRequest(int id, string authorization);
        Task<IResult> EditRequest(int id, Request request, string authorization, bool ModelState);
        Task<IResult> GetRequestById(int? id);
        Task<IResult> GetRequests(Filter? filter);
    }
}