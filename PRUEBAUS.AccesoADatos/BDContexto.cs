﻿using Microsoft.EntityFrameworkCore;
using PRUEBAUS.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBAUS.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Planta> Plantas { get; set; }  


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=HENRYRAMOS;Initial Catalog=PRUEBA2;Integrated Security=True;TrustServerCertificate=True;");
        }

    }
}
