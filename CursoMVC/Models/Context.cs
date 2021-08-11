using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CursoMVC.Models
{
    public class Context : DbContext // Essa classe herda de uma interface do Entity framework chamada DbContext
    {
        private Action<SqlServerDbContextOptionsBuilder> connectionString;

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // responsável por configurar o entity framework
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CursoMVC;
            Integrated Security=true");
        }
    }
}
