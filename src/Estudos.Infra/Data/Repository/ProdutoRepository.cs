using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Estudos.business.Models.Produtos;
using Estudos.Infra.Data.Context;

namespace Estudos.Infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MyContext context) : base(context) { }
        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Db.Produto.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produto.AsNoTracking().Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();
        }


    }
}