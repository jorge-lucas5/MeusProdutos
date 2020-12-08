using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Estudos.business.Models.Fornecedores;
using Estudos.business.Models.Produtos;
using Estudos.Infra.Data.Mappings;

namespace Estudos.Infra.Data.Context
{
    public class Context : DbContext
    {
        public Context() : base("DbConnection")
        {

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(p => p
                .HasColumnType("varchar")
                .HasMaxLength(100)
            );

            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
    }
}