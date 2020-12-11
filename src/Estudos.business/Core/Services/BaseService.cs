using Estudos.business.Core.Models;
using FluentValidation;

namespace Estudos.business.Core.Services
{
    public abstract class BaseService
    {
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);
            return validator.IsValid;

        }
    }
}