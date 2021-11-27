using System;
using Microsoft.EntityFrameworkCore;
using UsuarioAPI.Models;

namespace UsuarioAPI.Servicos
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
        : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}