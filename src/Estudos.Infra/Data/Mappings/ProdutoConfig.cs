using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Estudos.business.Models.Fornecedores;
using Estudos.business.Models.Produtos;

namespace Estudos.Infra.Data.Mappings
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(e => e.Id);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(500);

            Property(p => p.Imagem)
                .IsRequired()
                .HasMaxLength(100);

            HasRequired(p => p.Fornecedor)
                .WithMany(f => f.Produtos)// um fornecedor tem varios produtos
                .HasForeignKey(p => p.FornecedorId);

            ToTable("Produto");
        }
    }
}