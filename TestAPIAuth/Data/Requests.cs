using TestAPIAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TestAPIAuth.Data
{
    public static class Requests
    {

            private static DataBaseContext _context = new DataBaseContext();

    
            public static IResult GetRequests()
            {
                return _context.requests != null ?
                            Results.Ok(_context.requests.ToList()) :
                            Results.BadRequest("Entity set 'DataBaseContext.requests'  is null.");
            }

            public static IResult GetRequestById(int? id)
            {
                if (id == null || _context.requests == null)
                {
                    return Results.NotFound();
                }

                Request request = _context.requests.FirstOrDefault(m => m.Id == id);
                if (request == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(request);
            }



            public static IResult CreateRequest(Request request, bool ModelState)
            {
                if (ModelState)
                {
                   var context = new DataBaseContext();
                    context.Add(request);
                    context.SaveChanges();
                    return Results.Ok(request);
                }
                return Results.BadRequest();
            }


            public static IResult EditRequest(int id, Request request, bool ModelState)
            {
                if (id != request.Id)
                {
                    return Results.NotFound();
                }

                if (ModelState)
                {
                    try
                    {
                    var context = new DataBaseContext();
                        context.Update(request);
                        context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        
                            return Results.NotFound();
                        
                    }

                }
                return Results.Ok(request);
            }


            public static IResult DeleteRequest(int id)
            {
                if (_context.requests == null)
                {
                    return Results.Problem("Invalid request");
                }
                var request = _context.requests.FirstOrDefault(x => x.Id == id);
                if (request != null)
                {
                    _context.requests.Remove(request);
                    _context.SaveChanges();
                     return Results.Ok("Deleted");

                }
                return Results.Problem("Invalid request");
            }

        
    }
    

}
