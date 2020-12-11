using System;
using System.Threading.Tasks;

namespace Estudos.business.Models.Produtos.Services
{
    public interface IProdutoServices : IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}