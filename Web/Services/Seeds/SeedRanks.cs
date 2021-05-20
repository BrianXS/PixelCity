using System.Collections.Generic;
using System.Linq;
using Web.Data.Entities;
using Web.Services.Database;

namespace Web.Services.Seeds
{
    public static class SeedRanks
    {
        public static void Init(PixelCityDbContext dbContext)
        {
            if (!dbContext.Ranks.Any())
            {
                var defaultRanks = new List<Rank>
                {
                    new Rank {Name = "Novato", Description = "Usuario recien registrado."},
                    new Rank {Name = "New Full", Description = "Novato que junto mas de 50 puntos en sus posts."},
                    new Rank {Name = "Full", Description = "New Full con mas de 200 puntos en sus posts."},
                    new Rank {Name = "Silver", Description = "Usuario que se encuentra en el top 50 del ranking de usuarios."},
                    new Rank {Name = "Gold", Description = "Usuario que se encuentra en el top 10 del ranking de usuarios"},
                    new Rank {Name = "Moderador", Description = "Ayudante del mantenenimiento de la paz y la tranquilidad en la comunidad."},
                    new Rank {Name = "Desarrollador", Description = "Colaborador en la creacion del sitio."}
                };
            
                dbContext.Ranks.AddRange(defaultRanks);
                dbContext.SaveChanges();
            }
        }
    }
}