using System.Collections.Generic;
using Web.Data.Entities;
using Web.Services.Database;

namespace Web.Services.Seeds
{
    public static class SeedCommunities
    {
        public static void Init(PixelCityDbContext dbContext)
        {
            var defaultCommunities = new List<Community>
            {
                new Community
                {
                    Name = "Xunix",
                    Description = "Un proyecto para compartir conocimientos en el mundo de los sistemas operativos.",
                    PicturePath = "/img/communities/xunix.png"
                },
                new Community
                {
                    Name = "Monas Chinas",
                    Description = "Las monas chinas llenan nuestro corazon de felicidad.",
                    PicturePath = "/img/communities/anime.jpg"
                },
                new Community
                {
                    Name = "Desarrolladores",
                    Description = "Tutoriales, preguntas, respuesta y todo lo relacionado con el mundo del desarollo.",
                    PicturePath = "/img/communities/dev.jpg"
                },
                new Community
                {
                    Name = "Lobsters",
                    Description = "Un lugar para los amantes de los computadores y el emprendimiento.",
                    PicturePath = "/img/communities/lobsters.jpg"
                },
                new Community
                {
                    Name = "Comunidad WTF",
                    Description = "En este lugar le sabemos, crapeo sin limites.",
                    PicturePath = "/img/communities/wtf.png"
                },
                new Community
                {
                    Name = "Noticias Globales",
                    Description = "Mantente al tanto de todas las cosas que sucede en el mundo..",
                    PicturePath = "/img/communities/paper.jpg"
                },
                new Community
                {
                    Name = "Matemáticas",
                    Description = "Comunidad para discutir sobre las matemáticas.",
                    PicturePath = "/img/communities/math.jpg"
                },
                new Community
                {
                    Name = "Motocicletas",
                    Description = "Comparte tu aficion por los motores en este lugar y revoluciona tu corazon.",
                    PicturePath = "/img/communities/bike.jpg"
                },
                new Community
                {
                    Name = "RePacks",
                    Description = "Comparte y descarga los ultimos juegos sin limites.",
                    PicturePath = "/img/communities/games.jpg"
                }
            };
            
            dbContext.Communities.AddRange(defaultCommunities);
            dbContext.SaveChanges();
        }
    }
}