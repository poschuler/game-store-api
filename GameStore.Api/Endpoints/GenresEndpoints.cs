using GameStore.Api.Data;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GenresEndpoints
{
    public static RouteGroupBuilder MapGenresEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("/genres");

        group.MapGet("/", async (GameStoreContext dbContext) =>
        {
            return await dbContext.Genres
                .Select(g => g.ToDto())
                .AsNoTracking()
                .ToListAsync();
        });

        return group;
    }


}
