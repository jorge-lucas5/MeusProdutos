using System.Reflection;
using System.Web.Mvc;
using Estudos.business.Core.Notificacao;
using Estudos.business.Models.Fornecedores;
using Estudos.business.Models.Fornecedores.Services;
using Estudos.business.Models.Produtos;
using Estudos.business.Models.Produtos.Services;
using Estudos.Infra.Data.Context;
using Estudos.Infra.Data.Repository;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace Estudos.AppMVC
{
    public class DependencyInjectionConfig
    {
        public static void RegisterDIContainer()
        {
            var container = new Container();

            container.Options.DefaultLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            // Lifestyle.Singleton
            // Uma única instância por aplicação

            // Lifestyle.Transient
            // Cria uma nova instância para cada injeção

            //Lifestyle.Scoped - somente para aplicação web
            // Uma única instância por request

            container.Register<MyContext>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);
            container.Register<IFornecedorRepository, FornecedorRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);
            container.Register<IFornecedorService, FornecedorService>(Lifestyle.Scoped);
            container.Register<INotification, Notification>(Lifestyle.Scoped);

            container.RegisterSingleton(() => AutoMapperConfig.GetMapperConfiguration().CreateMapper(container.GetInstance));

        }
    }
}