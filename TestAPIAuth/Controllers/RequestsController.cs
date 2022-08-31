using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAPIAuth.Models;
using TestAPIAuth.Data;

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
          return  Requests.GetRequestById(id);
        }

        [HttpPost("CreateRequest")]
        public Task<IResult> CreateRequest(Request request)
        {
            return Requests.CreateRequest(request, ModelState.IsValid);
        }

        [HttpPost("EditRequest")]
        public Task<IResult> EditRequest(int id, Request request)
        {
            return Requests.EditRequest(id, request, ModelState.IsValid);
        }

  
        // POST: Requests/Delete/5
        [HttpGet("DeleteRequest")]
        public Task<IResult> DeleteRequest(int id)
        {
            return Requests.DeleteRequest(id);
        }

    }
}
