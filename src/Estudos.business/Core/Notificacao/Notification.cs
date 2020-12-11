using System.Collections.Generic;
using System.Linq;

namespace Estudos.business.Core.Notificacao
{
    public class Notification : INotification
    {
        private readonly List<Notificacao> _notificacoes;

        public Notification()
        {
            _notificacoes = new List<Notificacao>();
        }
        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }
    }
}