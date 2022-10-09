
using Microsoft.AspNetCore.Mvc;
using TestAPIAuth.Data;
using TestAPIAuth.Models;

namespace TestAPIAuth.Controllers
{

    public class RequestsController : Controller
    {


        // GET: Requests
        [HttpGet("GetRequests")]
        public Task<IResult> GetRequests()
        {
            return Requests.GetRequests();
        }

        // GET: Requests/Details/5
        [HttpGet("Request/{id}")]
        public Task<IResult> GetRequestById(int? id)
        {
            return Requests.GetRequestById(id);
        }

        [HttpPost("CreateRequest")]

        public Task<IResult> CreateRequest(Request request, [FromHeader] string authorization)
        {

            return Requests.CreateRequest(request, authorization, ModelState.IsValid);
        }

        [HttpPost("EditRequest")]
        public Task<IResult> EditRequest(int id, Request request, [FromHeader] string authorization)
        {


            return Requests.EditRequest(id, request, authorization, ModelState.IsValid);
        }


        // POST: Requests/Delete/5
        [HttpGet("DeleteRequest")]
        public Task<IResult> DeleteRequest(int id, [FromHeader] string authorization)
        {
            return Requests.DeleteRequest(id, authorization);
        }

    }
}
