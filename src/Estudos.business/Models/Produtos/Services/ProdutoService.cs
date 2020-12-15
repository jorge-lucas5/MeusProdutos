using System;
using System.Threading.Tasks;
using Estudos.business.Core.Notificacao;
using Estudos.business.Core.Services;
using Estudos.business.Models.Produtos.Validations;

namespace Estudos.business.Models.Produtos.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository,INotification notification
        ) : base(notification)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task Adicionar(Produto produto)
        {
            if (ExecutarValidacao(new ProdutoValidation(), produto)) return;
            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (ExecutarValidacao(new ProdutoValidation(), produto)) return;
            await _produtoRepository.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}