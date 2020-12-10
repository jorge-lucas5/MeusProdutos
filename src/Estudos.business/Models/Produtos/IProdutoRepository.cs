using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Estudos.business.Core.Data;

namespace Estudos.business.Models.Produtos
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        /// <summary>
        /// retorna os produtos do fornecedor
        /// </summary>
        /// <param name="fornecedorId"></param>
        /// <returns></returns>
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        /// <summary>
        /// retorna os produtos e seu fornecedor
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();

        /// <summary>
        /// retorna o produto e seu fornecedor
        /// </summary>
        /// <param name="id">id do produto</param>
        /// <returns></returns>
        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}