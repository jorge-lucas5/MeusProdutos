using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Estudos.business.Models.Fornecedores;
using Estudos.Infra.Data.Context;

namespace Estudos.Infra.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MyContext context) : base(context) { }
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedor.AsNoTracking()
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedor.AsNoTracking()
                .Include(f => f.Endereco)
                .Include(f => f.Produtos)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public override async Task Remover(Guid id)
        {
            var fornecedor = await ObeterPorId(id);
            fornecedor.Ativo = false;
            await Atualizar(fornecedor);
        }
    }
}