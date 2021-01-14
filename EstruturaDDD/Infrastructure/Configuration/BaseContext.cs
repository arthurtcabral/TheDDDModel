using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Infrastructure.Configuration
{
    public class BaseContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        private static string CONNECTION_STRING = "Data Source =localhost;Initial Catalog=ciencia_computacao;Persist Security Info=True;Integrated Security=SSPI;";

        public BaseContext()
        {
        }

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
            //Cria a base de dados caso ela não exista. 
            //Como o projeto é code first (primeiro o código, e depois a base), isto precisa ser feito, 
            //porque quando o construtor for executado, será verificado se as tabelas referenciadas no código existem
            //no banco de dados.
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            //Se não estiver configurado na interface do usuário, seta-se a string de configuração aqui.
            if (!dbContextOptionsBuilder.IsConfigured)
                dbContextOptionsBuilder.UseSqlServer(CONNECTION_STRING);
            //dbContextOptionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString);
            base.OnConfiguring(dbContextOptionsBuilder);
        }

    }
}
