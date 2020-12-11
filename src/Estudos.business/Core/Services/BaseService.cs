using Estudos.business.Core.Models;
using Estudos.business.Core.Notificacao;
using FluentValidation;
using FluentValidation.Results;

namespace Estudos.business.Core.Services
{
    public abstract class BaseService
    {
        private readonly INotification _notification;

        protected BaseService(INotification notification)
        {
            _notification = notification;
        }
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid)
                return true;

            Notificar(validator);
            return false;
        }

        protected void Notificar(ValidationResult result)
        {
            foreach (var error in result.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notification.Handle(new Notificacao.Notificacao(mensagem));
        }
    }
}