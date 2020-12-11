using System.Collections.Generic;

namespace Estudos.business.Core.Notificacao
{
    public interface INotification
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}