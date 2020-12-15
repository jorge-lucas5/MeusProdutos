using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Estudos.AppMVC.ViewModels;
using Estudos.business.Models.Produtos;
using Estudos.business.Models.Produtos.Services;

namespace Estudos.AppMVC.Controllers
{
    [RoutePrefix("produtos")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoServices;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepository produtoRepository,
                                IProdutoService produtoServices,
                                IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _produtoServices = produtoServices;
            _mapper = mapper;
        }

        [HttpGet,
         Route("lista")]
        public async Task<ActionResult> Index()
        {
            var lista = await _produtoRepository.ObeterTodos();
            var produtosVM = _mapper.Map<IEnumerable<ProdutoViewModel>>(lista);
            return View();
        }
        [HttpGet, Route("detalhes/{id:guid}")]
        public async Task<ActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [HttpGet, Route("novo")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost, Route("novo")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = _mapper.Map<Produto>(produtoViewModel);
                await _produtoServices.Adicionar(produto);

                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }
        [HttpGet, Route("editar/{id:guid}")]
        public async Task<ActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [HttpPost, Route("editar/{id:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = _mapper.Map<Produto>(produtoViewModel);
                await _produtoServices.Atualizar(produto);
                return RedirectToAction("Index");
            }
            return View(produtoViewModel);
        }

        [Route("deletar/{id:guid}"), HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [Route("deletar/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            await _produtoServices.Remover(id);
            return RedirectToAction("Index");
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = await _produtoRepository.ObterProdutoFornecedor(id);
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(produto);
            return produtoViewModel;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _produtoRepository.Dispose();
                _produtoServices.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
