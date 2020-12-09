using System;
using Flunt.Notifications;

namespace Votador.Compartilhado.Entidades
{
    public abstract class Entidade : Notifiable
    {
        protected Entidade()
        {
            Id = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
        }
        public string Id { get; private set; }
    }
}