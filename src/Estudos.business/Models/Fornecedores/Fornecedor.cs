using System.Collections.Generic;
using Estudos.business.Core.Models;
using Estudos.business.Models.Produtos;

namespace Estudos.business.Models.Fornecedores
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
