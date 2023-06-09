using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InteliWeb.DAL.InteliWebContext;
using Microsoft.EntityFrameworkCore;
//using InteliWeb.BLL.Interfaces;
//using InteliWeb.DAL.Interfaces;
//using InteliWeb.BLL.Implementaciones;
//using InteliWeb.DAL.Implementaciones;


namespace InteliWeb.IOC
{
    public static class Dependencia
    {

        public static void InyectarDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InteliWebContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CadenaSQL"));
            }
                );
        }

    }
}
