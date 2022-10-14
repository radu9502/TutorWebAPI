using Microsoft.EntityFrameworkCore;
using TestAPIAuth.Data.Interfaces;
using TestAPIAuth.Models;
using static TestAPIAuth.Utils.JwtInfo;

namespace TestAPIAuth.Data
{
    public class Requests : IRequests
    {

        private readonly IDataBaseContext _context;

        public Requests(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<IResult> GetRequests()
        {
            using var context = new DataBaseContext();
            return context.requests != null ?
                        Results.Ok(await _context.requests.ToListAsync()) :
                        Results.BadRequest("Entity set 'DataBaseContext.requests'  is null.");
        }

        public async Task<IResult> GetRequestById(int? id)
        {
            if (id == null || _context.requests == null)
            {
                return Results.NotFound();
            }

            Request request = await _context.requests.FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(request);
        }



        public async Task<IResult> CreateRequest(Request request, string authorization, bool ModelState)
        {


            if (ModelState)
            {
                //Validate if the user is allowed to make the changes
                if (!IsOwner(authorization, request)) return Results.BadRequest("Restricted");
                await _context.requests.AddAsync(request);
                await _context.SaveChangesAsync();
                return Results.Ok(request);
            }
            return Results.BadRequest();
        }


        public async Task<IResult> EditRequest(int id, Request request, string authorization, bool ModelState)
        {
            if (id != request.Id)
            {
                return Results.NotFound();
            }

            if (ModelState)
            {
                //Validate if the user is allowed to make the changes
                if (IsOwner(authorization, request) || IsAdmin(authorization) == false) return Results.BadRequest("Restricted");


                try
                {

                    _context.requests.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    return Results.NotFound();

                }

            }
            return Results.Ok(request);
        }


        public async Task<IResult> DeleteRequest(int id, string authorization)
        {
            if (_context.requests == null)
            {
                return Results.Problem("Invalid request");
            }
            var request = await _context.requests.FirstOrDefaultAsync(x => x.Id == id);
            if (request != null)
            {
                //Validate if the user is allowed to make the changes
                if (IsOwner(authorization, request) || IsAdmin(authorization) == false) return Results.BadRequest("Restricted");

                _context.requests.Remove(request);
                await _context.SaveChangesAsync();
                return Results.Ok("Deleted");

            }
            return Results.Problem("Invalid request");
        }




    }


}
