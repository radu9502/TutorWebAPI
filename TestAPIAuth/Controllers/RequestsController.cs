
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestAPIAuth.Data.Interfaces;
using TestAPIAuth.Models;

namespace TestAPIAuth.Controllers
{

    public class RequestsController : Controller
    {
        private readonly IRequests _requests;

        public RequestsController(IRequests requests)
        {
            _requests = requests;
        }

        // GET: Requests
        [HttpGet("GetRequests")]
        public Task<IResult> GetRequests()
        {
            return _requests.GetRequests();
        }

        // GET: Requests/Details/5
        [HttpGet("Request/{id}")]
        public Task<IResult> GetRequestById(int? id)
        {
            return _requests.GetRequestById(id);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("CreateRequest")]

        public Task<IResult> CreateRequest([FromBody] Request request, [FromHeader] string authorization)
        {

            return _requests.CreateRequest(request, authorization, ModelState.IsValid);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("EditRequest")]
        public Task<IResult> EditRequest(int id, Request request, [FromHeader] string authorization)
        {


            return _requests.EditRequest(id, request, authorization, ModelState.IsValid);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // POST: Requests/Delete/5
        [HttpGet("DeleteRequest")]
        public Task<IResult> DeleteRequest(int id, [FromHeader] string authorization)
        {
            return _requests.DeleteRequest(id, authorization);
        }

    }
}
