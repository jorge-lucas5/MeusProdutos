using System;
using System.Threading.Tasks;
using Estudos.business.Core.Data;

namespace Estudos.business.Models.Fornecedores
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        /// <summary>
        /// retorna o endereço do fornecedor
        /// </summary>
        /// <param name="forncedorId">id do fornecedor</param>
        /// <returns></returns>
        Task<Endereco> ObeterEnderecoPorFornecedor(Guid forncedorId);
    }
}