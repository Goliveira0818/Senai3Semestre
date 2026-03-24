using EventPlus.webAPI.BdContextEvent;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.webAPI.Repositories
{
    /// <summary>
    /// Repositório responsável pelo gerenciamento dos comentários dos eventos.
    /// </summary>
    public class ComentarioRepository : IComentarioEventoRepository
    {
        private readonly EventContext _context;

        public ComentarioRepository(EventContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca um comentário de um usuário em um evento
        /// </summary>
        public ComentarioEvento BuscarPorIdUsuario(Guid IdUsuario, Guid IdEvento)
        {
            return _context.ComentarioEventos
                .FirstOrDefault(c => c.IdUsuario == IdUsuario && c.IdEvento == IdEvento)!;
        }

        /// <summary>
        /// Cadastra um novo comentário
        /// </summary>
        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            _context.ComentarioEventos.Add(comentarioEvento);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deleta um comentário
        /// </summary>
        public void Deletar(Guid id)
        {
            ComentarioEvento comentarioBuscado = _context.ComentarioEventos.Find(id)!;

            if (comentarioBuscado != null)
            {
                _context.ComentarioEventos.Remove(comentarioBuscado);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Lista todos os comentários de um evento
        /// </summary>
        public List<ComentarioEvento> Listar(Guid IdEvento)
        {
            return _context.ComentarioEventos
                .Include(c => c.IdUsuarioNavigation)
                .Where(c => c.IdEvento == IdEvento)
                .ToList();
        }

        /// <summary>
        /// Lista apenas comentários visíveis (exibidos)
        /// </summary>
        public List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento)
        {
            return _context.ComentarioEventos
                .Include(c => c.IdUsuarioNavigation)
                .Where(c => c.IdEvento == IdEvento && c.Exibe == true)
                .ToList();
        }
    }
}