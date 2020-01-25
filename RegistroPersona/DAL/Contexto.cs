using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RegistroPersona.Entidades;

namespace RegistroPersona.DAL
{
    public class Contexto : DbContext
    {
       public  DbSet<Persona> persona { get; set;  }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = RegistroPersona; Trusted_Connection = True; ");
        }
    }
}
