using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerApiBasica.Helpers
{
    public class DatabaseInitializer
    {
        public static void Inicializar(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<Models.TallerDbContext>();
            context.Database.EnsureCreated();


            context.SaveChanges();
        }
    }
}
