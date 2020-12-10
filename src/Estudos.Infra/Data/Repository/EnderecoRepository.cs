using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Estudos.business.Models.Fornecedores;

namespace Estudos.Infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public async Task<Endereco> ObeterEnderecoPorFornecedor(Guid forncedorId)
        {
           return await ObeterPorId(forncedorId);
        }
    }
}