
using Scalar.AspNetCore;
using RESTAssignment.Data;
using Microsoft.EntityFrameworkCore;
using RESTAssignment.DTO;
using RESTAssignment.Models;

namespace RESTAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddDbContext<RESTAssignmentDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //get all persons
            app.MapGet("/persons", async (RESTAssignmentDbContext context) =>
            {
                var persons = await context.Persons
                .Include(p => p.PersonInterests)
                .ThenInclude(pi => pi.Interest)
                .ToListAsync();

                if (persons == null || persons.Count == 0)
                {
                    return Results.NotFound("No persons found");
                }
                return Results.Ok(persons.Select(p => new PersonDetailDTO(p)));
            });


            //Get a person with a specific id and their interests
            app.MapGet("/persons/{id}/interests", async (RESTAssignmentDbContext context, int id) =>
            {
                var person = await context.Persons.Where(x => x.Id == id)
                    .Include(p => p.PersonInterests)
                    .ThenInclude(pi => pi.Interest)
                    .Select(p => new PersonDetailDTO(p))
                    .FirstOrDefaultAsync();

                if (person == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(person);
                }
                    
            });

            app.MapPost("/persons/interests", async (RESTAssignmentDbContext context, int personId, int interestId) =>
            {
                var personInterests = await context.PersonInterests.ToListAsync();

                var persons = await context.Persons.ToListAsync();

                var interests = await context.Interests.ToListAsync();

                if ((persons.Any(p => p.Id == personId) && interests.Any(i => i.Id == interestId)) && !personInterests.Any(pi => pi.PersonId == personId && pi.InterestId == interestId))
                {
                    var pi = new PersonInterest
                    {
                        PersonId = personId,
                        InterestId = interestId
                    };
                    context.PersonInterests.Add(pi);
                    await context.SaveChangesAsync();
                    return Results.Created();
                }
                else if(!persons.Any(p => p.Id == personId) || !interests.Any(i => i.Id == interestId))
                {
                    return Results.NotFound("PersonId or InterestId does not exist.");
                }
                else if (personInterests.Any(pi2 => pi2.PersonId == personId && pi2.InterestId == interestId))
                {
                     return Results.BadRequest("This interest is already added to the person.");
                }
                else
                {
                    return Results.BadRequest("Something went wrong");
                }
            });

            //Get all links for a specific person
            app.MapGet("/persons/{id}/links", async (RESTAssignmentDbContext context, int id) =>
            {
                if (!context.Persons.Any(p => p.Id == id))
                {
                    return Results.NotFound($"No person with id {id} exists");
                }

                var links = await context.Links.Where(x => x.PersonId == id)
                    .Include(l => l.Interest)
                    .Include(l => l.Person)
                    .ToListAsync();

                if (links == null || links.Count == 0)
                {
                    return Results.NotFound($"No links added by person with id {id}");
                }

                return Results.Ok(links.Select(l => new LinkDetailDTO(l)));
            });

            //add links for specific person and interest
            app.MapPost("/persons/{personId}/links/{interestId}", async (RESTAssignmentDbContext context, int personId, int interestId, string url) =>
            {
                if (!context.Persons.Any(p => p.Id == personId))
                {
                    return Results.NotFound($"No person with id {personId} exists");
                }
                else if (!context.Interests.Any(i => i.Id == interestId))
                {
                    return Results.NotFound($"No interest with id {interestId}");
                }

                var link = new Link
                    {
                        Url = url,
                        PersonId = personId,
                        InterestId = interestId
                    };

                if (string.IsNullOrEmpty(link.Url))
                {
                    return Results.BadRequest("URL cannot be empty");
                }

                context.Links.Add(link);
                await context.SaveChangesAsync();
                return Results.Created();
            });


            //Get all interests
            app.MapGet("/interests", async (RESTAssignmentDbContext context) =>
            {
                var interests = await context.Interests
                    .Include(i => i.LinksAdded)
                    .ThenInclude(l => l.Person)
                    .ToListAsync();

                if (interests == null || interests.Count == 0)
                {
                    return Results.NotFound("No interests found");
                }

                return Results.Ok(interests.Select(i => new InterestDetailDTO(i)));
            });

            app.Run();
        }
    }
}
