using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Estudos.business.Core.Models;

namespace Estudos.business.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObeterPorId(TEntity entity);
        Task<List<TEntity>> ObeterTodos();
        Task Atualizar(TEntity entity);
        Task Atualizar(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}