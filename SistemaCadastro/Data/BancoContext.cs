﻿using Microsoft.EntityFrameworkCore;
using SistemaCadastro.Data.Map;
using SistemaCadastro.Models;

namespace SistemaCadastro.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions <BancoContext> options) : base(options)
        {

        }

        public DbSet<ContatoModel> Contatos { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
