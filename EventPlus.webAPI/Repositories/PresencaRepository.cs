using EventPlus.webAPI.BdContextEvent;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EventPlus.webAPI.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {

        private readonly EventContext _eventContext;

        public PresencaRepository(EventContext eventContext)
        {
            _eventContext = eventContext;
        }

        public void Atualizar(Guid IdPresencaEvento
            )
        {
            Presenca presencaBuscada = _eventContext.Presencas.Find(IdPresencaEvento);

            if (presencaBuscada != null)
            {
                // Exemplo: confirmar presença
                presencaBuscada.Situacao = !presencaBuscada.Situacao;

                
                _eventContext.SaveChanges();
            }
        }

        public Presenca BuscarPorId(Guid id)
        {
            return _eventContext.Presencas
                .Include(p => p.IdEventoNavigation)
                .ThenInclude(e => e!.IdInstituicaoNavigation)
                .FirstOrDefault(p => p.IdPresenca == id)!;
        }

        public void Deletar(Guid id)
        {
            Presenca presencaBuscada = _eventContext.Presencas.Find(id)!;

            if (presencaBuscada != null)
            {
                _eventContext.Presencas.Remove(presencaBuscada);
                _eventContext.SaveChanges();
            }
        }

        public void Inscrever(Presenca Inscricao)
        {
            _eventContext.Presencas.Add(Inscricao);
            _eventContext.SaveChanges();
        }

        public List<Presenca> Listar()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lista de presencas de um usuario especifico
        /// </summary>
        /// <param name="IdUsuario">id do usuario para filtragem</param>
        /// <returns>uma Lista de presencas de um usuario especifico</returns>
        public List<Presenca> ListarMinhas(Guid IdUsuario)
        {
            return _eventContext.Presencas
                .Include(p => p.IdEventoNavigation)
                .ThenInclude(e => e!.IdInstituicaoNavigation)
                .Where(p => p.IdUsuario == IdUsuario)
                .ToList();
        }
    }
}