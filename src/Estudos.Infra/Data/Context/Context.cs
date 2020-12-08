using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Estudos.business.Models.Fornecedores;
using Estudos.business.Models.Produtos;

namespace Estudos.Infra.Data.Context
{
    public class Context : DbContext
    {
        public Context() : base("DbConnection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
    }
}