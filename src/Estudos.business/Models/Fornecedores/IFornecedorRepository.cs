using System;
using System.Threading.Tasks;
using Estudos.business.Core.Data;

namespace Estudos.business.Models.Fornecedores
{
    public interface IFornecedorRepository:IRepository<Fornecedor>
    {
        /// <summary>
        /// retona o fornecedor e seu endereço
        /// </summary>
        /// <param name="id">id do fornecedor</param>
        /// <returns></returns>
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);

        /// <summary>
        /// retona o fornecedor, seu endereço e seus produtos
        /// </summary>
        /// <param name="id">id do forncedor</param>
        /// <returns></returns>
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}