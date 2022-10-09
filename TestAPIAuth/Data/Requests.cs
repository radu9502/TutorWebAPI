using Microsoft.EntityFrameworkCore;
using TestAPIAuth.Models;
using static TestAPIAuth.Utils.JwtInfo;

namespace TestAPIAuth.Data
{
    public static class Requests
    {

        private static DataBaseContext _context = new DataBaseContext();


        public static async Task<IResult> GetRequests()
        {
            using var context = new DataBaseContext();
            return context.requests != null ?
                        Results.Ok(await _context.requests.ToListAsync()) :
                        Results.BadRequest("Entity set 'DataBaseContext.requests'  is null.");
        }

        public static async Task<IResult> GetRequestById(int? id)
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



        public static async Task<IResult> CreateRequest(Request request, string authorization, bool ModelState)
        {


            if (ModelState)
            {
                //Validate if the user is allowed to make the changes
                if (!IsOwner(authorization, request)) return Results.BadRequest("Restricted");
                var context = new DataBaseContext();
                await context.AddAsync(request);
                await context.SaveChangesAsync();
                return Results.Ok(request);
            }
            return Results.BadRequest();
        }


        public static async Task<IResult> EditRequest(int id, Request request, string authorization, bool ModelState)
        {
            if (id != request.Id)
            {
                return Results.NotFound();
            }

            if (ModelState)
            {
                //Validate if the user is allowed to make the changes
                if (IsOwner(authorization, request) || IsAdmin(authorization, request) == false) return Results.BadRequest("Restricted");


                try
                {
                    var context = new DataBaseContext();
                    context.Update(request);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    return Results.NotFound();

                }

            }
            return Results.Ok(request);
        }


        public static async Task<IResult> DeleteRequest(int id, string authorization)
        {
            if (_context.requests == null)
            {
                return Results.Problem("Invalid request");
            }
            var request = await _context.requests.FirstOrDefaultAsync(x => x.Id == id);
            if (request != null)
            {
                //Validate if the user is allowed to make the changes
                if(IsOwner(authorization, request) || IsAdmin(authorization, request) == false) return Results.BadRequest("Restricted");

                _context.requests.Remove(request);
                await _context.SaveChangesAsync();
                return Results.Ok("Deleted");

            }
            return Results.Problem("Invalid request");
        }




    }


}
