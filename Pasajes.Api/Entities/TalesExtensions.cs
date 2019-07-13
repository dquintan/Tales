using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pasajes.Api.Entities
{
    public static class TalesExtensions
    {
        public static void EnsureSeedDataForContext(this TalesContext context)
        {
            if (context.Tales.Any())
            {
                return;
            }

            // init seed data
            var tales = new List<Tale>()
            {
                new Tale()
                {
                    Century = 16,
                    Title = "Antonio Pérez vs Felipe II",
                    Year = 1578,
                    TaleSources = new List<TaleSource>()
                    {
                        new TaleSource()
                        {
                            Priority = 3,
                            Url = "https://www.pasajesdelahistoria.es/assets/pasajes/files/f1754-dc1542-antonio-perez-vs-felipe-ii-lrv20061016.mp3"
                        }
                    }
                },
                new Tale()
                {
                    Century = 19,
                    Title = "Alejandro Dumas",
                    Year = 1802,
                    TaleSources = new List<TaleSource>()
                    {
                        new TaleSource()
                        {
                            Priority = 3,
                            Url = "https://www.youtube.com/watch?v=WUqJyeLKlO4"
                        }
                    }
                }
            };

            context.Tales.AddRange(tales);
            context.SaveChanges();
        }
    }
}
